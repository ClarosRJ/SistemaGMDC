using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using Sis.Alcaldia.Shared.BaseModels;
using Sis.Alcaldia.Shared.Models;

namespace Sis.Alcaldia.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IWebHostEnvironment _webHost;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper, IWebHostEnvironment webHost)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
            _webHost = webHost;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<UsuarioDTO>> _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
                IQueryable<Usuario> query = await _usuarioRepositorio.Consultar();
                query = query.Include(r => r.IdRolUsuarioNavigation);

                ListaUsuarios = _mapper.Map<List<UsuarioDTO>>(query.ToList());

                _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = true, msg = "ok", value = ListaUsuarios };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                UsuarioDTO _usuario = new UsuarioDTO();
                IQueryable<Usuario> query = await _usuarioRepositorio.Consultar(u => u.Correo == correo && u.Clave == clave);
                query = query.Include(r => r.IdRolUsuarioNavigation);

                _usuario = _mapper.Map<UsuarioDTO>(query.FirstOrDefault());

                if (_usuario != null)
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _usuario };
                else
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "no encontrado", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO request)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);

                Usuario _usuarioCreado = await _usuarioRepositorio.Crear(_usuario);

                if (_usuarioCreado.IdUsuario != 0)
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioCreado) };
                else
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO request)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);
                Usuario _usuarioParaEditar = await _usuarioRepositorio.Obtener(u => u.IdUsuario == _usuario.IdUsuario);

                if (_usuarioParaEditar != null)
                {

                    _usuarioParaEditar.NombreCompleto = _usuario.NombreCompleto;
                    _usuarioParaEditar.Correo = _usuario.Correo;
                    _usuarioParaEditar.Telefono = _usuario.Telefono;
                    _usuarioParaEditar.IdRolUsuario = _usuario.IdRolUsuario;
                    _usuarioParaEditar.Clave = _usuario.Clave;
                    _usuarioParaEditar.Estado = _usuario.Estado;
                    _usuarioParaEditar.FileName = _usuario.FileName;
                    _usuarioParaEditar.FileSize = _usuario.FileSize;
                    _usuarioParaEditar.ImgBin = _usuario.ImgBin;
                    _usuarioParaEditar.UrlImg = _usuario.UrlImg;
                    
                    
                    

                    bool respuesta = await _usuarioRepositorio.Editar(_usuarioParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se pudo editar el usuario" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se encontró el usuario" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                Usuario _usuarioEliminar = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);

                if (_usuarioEliminar != null)
                {

                    bool respuesta = await _usuarioRepositorio.Eliminar(_usuarioEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el usuario", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet("UserEmailName/{username}/{correo}")]
        public async Task<IActionResult> UserEmailName(string username, string correo)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                UsuarioDTO _usuario = new UsuarioDTO();
                Usuario query = await _usuarioRepositorio.TraerUser(username, correo);

                _usuario = _mapper.Map<UsuarioDTO>(query);

                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _usuario };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        //subir imagen
        [HttpPost]
        [Route("SaveToPhysicalLocation")]
        public async Task<IActionResult> SaveToPhysicalLocation([FromBody] SaveFile saveFile)
        {
            string filePaths = "";
            string filePathsdelete = "";
            foreach (var file in saveFile.Files)
            {
                if (file.FileName != "271120231718_default.png")
                {

                    string uploadsFolders = Path.Combine(_webHost.WebRootPath, "images");
                    var fileName = Path.GetFileName(file.FileName.ToString().Trim('"'));
                    filePaths = Path.Combine(uploadsFolders, fileName);
                    // Verifica si el archivo ya existe en la ruta
                    if (file.ImagenInicio != "271120231718_default.png")
                    {
                        var filedelete = Path.GetFileName(file.ImagenInicio.ToString().Trim('"'));
                        filePathsdelete = Path.Combine(uploadsFolders, filedelete);
                        if (System.IO.File.Exists(filePathsdelete))
                        {
                            // Elimina el archivo existente
                            System.IO.File.Delete(filePathsdelete);
                        }
                    }

                    using (var fileStream = System.IO.File.Create(filePaths))
                    {
                        await fileStream.WriteAsync(file.ImageBytes);
                    }
                }
            }
            return Ok(filePaths);
        }

    }
}
