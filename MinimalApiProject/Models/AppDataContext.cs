using Microsoft.EntityFrameworkCore;
using projeto.Models;

namespace projeto
{
    public class AppDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Imc> Imcs { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
