namespace Sis.Alcaldia.Shared.Models.Colaboradores
{
    public class PagosDTO
    {
		public int Idpago { get; set; }

		public int? Idfactura { get; set; }

		public DateTime? FechaPago { get; set; }

		public string? MetodoPago { get; set; }

		public decimal? MontoPago { get; set; }

		public decimal? Afp { get; set; }

		public decimal? Rciva { get; set; }

		public decimal? Descuentos { get; set; }

		public decimal? Bonos { get; set; }

        public decimal? SeguroM { get; set; }

        public string? Detalle { get; set; }

		public decimal? Total { get; set; }

	}
}
