using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class ConfContabilidad
{
    public int IdConfig { get; set; }

    public decimal? Afp { get; set; }

    public decimal? Rciva { get; set; }

    public decimal? Caja { get; set; }

    public decimal? SueldoBas { get; set; }

    public string? DetConfig { get; set; }

    public string? Gestion { get; set; }
}
