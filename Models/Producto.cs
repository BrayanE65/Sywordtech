using System;
using System.ComponentModel.DataAnnotations;
using Sywordtech.Models;

 namespace Sywordtech.Models
 {
     public class Producto
     {
         [Key]
        public int ID { get; set; } 

        public string Nombre { get; set; }
        public string? Codigo { get; set; }
        public double Precio { get; set; }
        public string Imagen { get; set; }
        public string? Color { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool EntregaDomicilio{ get; set; }
        public bool Disponible { get; set; }

        public int CategoriaID { get; set; }
        public Categoria? Categoria { get; set; }

        public int EspecificacionID { get; set; }
        public Especificacion? Especificacion { get; set; }
     }
 }