namespace Sis.Alcaldia.Shared.Models.Colaboradores
{
    public class FacturasDTO 
	{
		public int Idfactura { get; set; }

		public string? NumeroFactura { get; set; }

		public int? Idcolaborador { get; set; }

		public DateTime? FechaEmision { get; set; }

		public DateTime? FechaVencimiento { get; set; }

		public string? Concepto { get; set; }

		public decimal? Monto { get; set; }

		public string? EstadoPago { get; set; }

		public virtual ICollection<PagosDTO> Pagos { get; set; }

	}

}
