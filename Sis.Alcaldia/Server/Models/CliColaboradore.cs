using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class CliColaboradore
{
    public int Idcolaborador { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Ci { get; set; }

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

    public virtual ICollection<CliFactura> CliFacturas { get; set; } = new List<CliFactura>();
}
