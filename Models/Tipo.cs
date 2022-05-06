using System.ComponentModel.DataAnnotations;

namespace Sywordtech.Models
{
    public class Tipo
    {
        [Key]
        public int ID { get; set; }
        public string Titulo { get; set; }

        public List<Categoria>? Categorias { get; set; }
    }
    
}