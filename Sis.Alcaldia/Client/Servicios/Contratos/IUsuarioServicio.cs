﻿using Sis.Alcaldia.Shared.BaseModels;
using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Client.Servicios.Contratos
{
    public interface IUsuarioServicio
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista();
        Task<ResponseDTO<UsuarioDTO>> IniciarSesion(string correo, string clave);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad);
        Task<bool> Editar(UsuarioDTO entidad);
        Task<bool> Eliminar(int id);
        //usuarioeditprofile
        Task<ResponseDTO<UsuarioDTO>> UserEmailName(string username,string correo);

        //imagen,
        Task SaveToServer(SaveFileDTO saveFile);
    }
}
