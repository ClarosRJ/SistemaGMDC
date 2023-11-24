using System.ComponentModel.DataAnnotations;

namespace Sis.Alcaldia.Shared.Models
{
	public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string? Descripcion { get; set; }


        public override bool Equals(object o)
        {
            var other = o as CategoriaDTO;
            return other?.IdCategoria == IdCategoria;
        }
        public override int GetHashCode() => IdCategoria.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }

    }
}
