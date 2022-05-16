using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sywordtech.Models;

namespace Sywordtech.Data;

public class ApplicationDbContext : IdentityDbContext<Usuario, Rol, string,
        IdentityUserClaim<string>, UsuarioRol, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
        
         public DbSet<Producto> Productos { get; set; }
        
         public DbSet<Categoria> Categorias { get; set; }
        
         public DbSet<Especificacion> Especificaciones { get; set; }
        
         public DbSet<Noticia> Noticias { get; set; }
         
         public DbSet<Tipo> Tipos { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Usuario>(b =>
        {
            b.HasMany(e => e.UsuariosRoles)
            .WithOne(e => e.Usuario)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        });

        builder.Entity<Rol>(b =>
        {
            b.HasMany(e => e.UsuariosRoles)
            .WithOne(e => e.Rol)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        });

    }
 }