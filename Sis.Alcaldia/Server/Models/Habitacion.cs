using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public string? Numero { get; set; }

    public string? Detalle { get; set; }

    public decimal? Precio { get; set; }

    public int? IdEstadoHabitacion { get; set; }

    public int? IdPiso { get; set; }

    public int? IdCategoria { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual EstadoHabitacion? IdEstadoHabitacionNavigation { get; set; }

    public virtual Piso? IdPisoNavigation { get; set; }

    public virtual ICollection<Recepcion> Recepcions { get; set; } = new List<Recepcion>();
}
