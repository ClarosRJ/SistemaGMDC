﻿using System.ComponentModel.DataAnnotations;

namespace Sis.Alcaldia.Client.Utilidades
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "El correo es requerida.")]
        public string correo { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string clave { get; set; }
    }
}
