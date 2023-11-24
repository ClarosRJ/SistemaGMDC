using System.ComponentModel.DataAnnotations;

namespace Sis.Alcaldia.Shared.Models.Colaboradores
{
    public class ColaboradoresDTO 
    {
		public int Idcolaborador { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
		public string? CI { get; set; }

        public string? Cargo { get; set; }

        public string? Departamento { get; set; }

        public string? CorreoElectronico { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public DateTime? FechaContratacion { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Genero { get; set; }

        public string? EstadoCivil { get; set; }

        public string? EstadoEmpleado { get; set; }

        public string? Nit { get; set; }

        public string? MetodoPago { get; set; }

        //public virtual ICollection<FacturasDTO> Facturas { get; set; } = new List<FacturasDTO>();
        public virtual ICollection<FacturasDTO>? Facturas { get; set; }

    }
}
