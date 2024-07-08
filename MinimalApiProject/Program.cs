using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MinimalApiProject.Models;
using MinimalApiProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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

