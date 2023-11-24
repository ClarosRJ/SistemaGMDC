namespace Sis.Alcaldia.Shared.Models
{
	public class PisoDTO
    {
        public int IdPiso { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }
        public override bool Equals(object o)
        {
            var other = o as PisoDTO;
            return other?.IdPiso == IdPiso;
        }
        public override int GetHashCode() => IdPiso.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
