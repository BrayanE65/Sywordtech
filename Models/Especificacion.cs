 using System;
 using System.ComponentModel.DataAnnotations;
 using Sywordtech.Models;

 namespace Sywordtech.Models
 {
     public class Especificacion
     {
         [Key]
        public int ID { get; set; } 

        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public List<Producto>? Productos { get; set; }
     }
 }