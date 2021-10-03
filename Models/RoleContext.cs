using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

namespace wapi.Models
{
    public partial class RoleContext : DbContext
    { 
        public virtual DbSet<RoleModel> RoleM { get; set; }         
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Host=localhost;Database=flutter_bd;Username=root;Password=;SslMode=none");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<RoleModel>()
            .ToTable("roles")
            .HasKey(r => r.roleid);

            /*modelBuilder
            .HasDefaultSchema("public")
            .Entity<RoleModel>()
            .ToTable("roles")
            .HasKey(r => r.roleid);*/
        }          
    } 
}