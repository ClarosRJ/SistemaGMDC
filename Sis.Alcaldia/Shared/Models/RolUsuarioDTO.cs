namespace Sis.Alcaldia.Shared.Models
{
	public class RolUsuarioDTO
    {
        public int IdRolUsuario { get; set; }

        public string? Descripcion { get; set; }

        public override bool Equals(object o)
        {
            var other = o as RolUsuarioDTO;
            return other?.IdRolUsuario == IdRolUsuario;
        }
        public override int GetHashCode() => IdRolUsuario.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
