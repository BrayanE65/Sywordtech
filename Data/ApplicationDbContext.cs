using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sywordtech.Models;

namespace Sywordtech.Data;

public class ApplicationDbContext : IdentityDbContext
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



}