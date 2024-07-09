using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinimalApiProject.Models;
using MinimalApiProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using projeto.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlite("Data Source=projeto_projeto.db"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AcessoTotal",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.MapGet("/", () => "Api Academia");

app.MapPost("/academia/aluno/cadastrar", async ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{
    var existingAluno = await ctx.Alunos.FirstOrDefaultAsync(p => p.Nome == aluno.Nome && p.CPF == aluno.CPF);
    if (existingAluno != null)
    {
        return Results.Ok("Aluno já cadastrado");
    }
    else
    {
        ctx.Alunos.Add(paciente);
        await ctx.SaveChangesAsync();
    }

    return Results.Created($"/academia/aluno/{aluno.Id}", aluno);
});

app.MapGet("/academia/aluno/listar", async ([FromServices] AppDataContext ctx) =>
{
    var alunos = await ctx.Aluno.ToListAsync();
    return Results.Ok(alunos);
});

app.MapPut("/academia/aluno/alterar/{id}", async (HttpContext context, int id, [FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{
    var existingAluno = await ctx.Aluno.FindAsync(id);
    if (existingAluno == null)
    {
        return Results.NotFound($"{id} não foi encontrado.");
    }

    existingAluno.Nome = Aluno.Nome;
    existingAluno.DataNascimento = Aluno.DataNascimento;

    await ctx.SaveChangesAsync();

    return Results.Ok(existingAluno);
});