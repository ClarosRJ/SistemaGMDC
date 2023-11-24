using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class CliFactura
{
    public int Idfactura { get; set; }

    public string? NumeroFactura { get; set; }

    public int? Idcolaborador { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public string? Concepto { get; set; }

    public decimal? Monto { get; set; }

    public string? EstadoPago { get; set; }

    public virtual ICollection<CliPago> CliPagos { get; set; } = new List<CliPago>();

    public virtual CliColaboradore? IdcolaboradorNavigation { get; set; }
}
