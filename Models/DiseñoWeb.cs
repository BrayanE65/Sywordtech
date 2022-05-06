using System.ComponentModel.DataAnnotations;

namespace Sywordtech.Models
{
    public class DiseñoWeb
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }

        public List<Categoria>? Categorias { get; set; }
    }
    
}