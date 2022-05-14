using Microsoft.AspNetCore.Identity;

namespace Sywordtech.Models
{
    public class Rol : IdentityRole
    {
        public ICollection<UsuarioRol>? UsuariosRoles { get; set; }
    }
}