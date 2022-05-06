using System.ComponentModel.DataAnnotations;

namespace Sywordtech.Models
{
    public class Noticia
    {
        [Key]
       public int ID { get; set; } 
       public string Titulo { get; set; }
       public string Subtitulo { get; set; }
       
       public string Descripción { get; set; }
       public DateTime Fecha { get; set; }
       public string Imagen { get; set; }
    }
}