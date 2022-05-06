using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sywordtech.Models
{
    public class Categoria
    {
        [Key]
        public int ID { get; set; }
        
        public string Nombre { get; set; }
        public bool Disponible { get; set; }

        public int TipoID { get; set; }
        public Tipo? Tipo { get; set; }

        public List<Producto>? Productos { get; set; }
}
}