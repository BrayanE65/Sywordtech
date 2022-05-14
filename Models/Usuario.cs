using Microsoft.AspNetCore.Identity;

namespace Sywordtech.Models
{
    public class Usuario : IdentityUser
    {
        public ICollection<UsuarioRol>? UsuariosRoles { get; set; }
    }
}