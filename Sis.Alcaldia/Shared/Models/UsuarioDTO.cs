using System.ComponentModel.DataAnnotations;

namespace Sis.Alcaldia.Shared.Models
{
	public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage ="El campo Nombre Completo es requerido")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string? Correo { get; set; }

        public int? IdRolUsuario { get; set; }

        [Required(ErrorMessage = "El campo Clave es requerido")]
        public string? Clave { get; set; }

        public virtual RolUsuarioDTO? IdRolUsuarioNavigation { get; set; }
    }
}
