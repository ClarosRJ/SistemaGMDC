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
        public string? Telefono { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Estado { get; set; }
        [Required(ErrorMessage = "El campo Clave es requerido")]
        public string? Clave { get; set; }

        public byte[]? ImgBin { get; set; }

        public string? FileName { get; set; }

        public string? UrlImg { get; set; }

        public long? FileSize { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual RolUsuarioDTO? IdRolUsuarioNavigation { get; set; }


    }
}
