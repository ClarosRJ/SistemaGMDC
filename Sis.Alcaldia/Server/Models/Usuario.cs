using System;
using System.Collections.Generic;

namespace Sis.Alcaldia.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdRolUsuario { get; set; }

    public string? Clave { get; set; }

    public string? Estado { get; set; }

    public byte[]? ImgBin { get; set; }

    public string? FileName { get; set; }

    public string? UrlImg { get; set; }

    public long? FileSize { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual RolUsuario? IdRolUsuarioNavigation { get; set; }
}
