using Api_ToDoLis.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_ToDoLis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoLista>()
                .HasOne(tipo => tipo.ToDoList)
                .WithOne(lista => lista.TipoLista)
                .HasForeignKey<ToDoList>(tipo => tipo.Tipo_Id);
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<TipoLista> TipoListas { get; set; }
        
    }
}
