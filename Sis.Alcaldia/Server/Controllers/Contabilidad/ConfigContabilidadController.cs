using AutoMapper;
using Azure.Core;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sis.Alcaldia.Server.Models;
using Sis.Alcaldia.Server.Repositorio.Contratos;
using Sis.Alcaldia.Server.Repositorio.Implementacion;
using Sis.Alcaldia.Shared.Models;
using Sis.Alcaldia.Shared.Models.Colaboradores;

namespace Sis.Alcaldia.Server.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigContabilidadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfigContabilidad _configContabilidad;
        public ConfigContabilidadController(IConfigContabilidad configContabilidad, IMapper mapper)
        {
            _mapper = mapper;
            _configContabilidad = configContabilidad;
        }
        [HttpGet]
        [Route("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            ResponseDTO<List<ConfigContabilidadDTO>> _ResponseDTO = new ResponseDTO<List<ConfigContabilidadDTO>>();

            try
            {
                List<ConfigContabilidadDTO> ListaConfConta = new List<ConfigContabilidadDTO>();
                List<ConfContabilidad> query = await _configContabilidad.GetAllData();
                //query = query.Include(r => r.IdRolUsuarioNavigation);

                ListaConfConta = _mapper.Map<List<ConfigContabilidadDTO>>(query.ToList());

                _ResponseDTO = new ResponseDTO<List<ConfigContabilidadDTO>>() { status = true, msg = "ok", value = ListaConfConta };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ConfigContabilidadDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpGet("ItemId/{id}")]
        public async Task<IActionResult> ItemId(int Id)
        {
            ResponseDTO<ConfigContabilidadDTO> _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>();
            try
            {
                ConfigContabilidadDTO listapagos = new ConfigContabilidadDTO();
                ConfContabilidad query = await _configContabilidad.ItemId(Id);
                listapagos = _mapper.Map<ConfigContabilidadDTO>(query);
                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = true, msg = "ok", value = listapagos };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> Crear([FromBody] ConfigContabilidadDTO request)
        {
            ResponseDTO<ConfigContabilidadDTO> _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>();
            try
            {
                ConfContabilidad _confConta = _mapper.Map<ConfContabilidad>(request);

                ConfContabilidad _configContaCreado = await _configContabilidad.Crear(_confConta);

                if (_configContaCreado.IdConfig != 0)
                    _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = true, msg = "ok", value = _mapper.Map<ConfigContabilidadDTO>(_configContaCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = "No se pudo crear el Colaborador" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ConfigContabilidadDTO request)
        {
            ResponseDTO<ConfigContabilidadDTO> _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>();
            try
            {
                ConfContabilidad _confConta = _mapper.Map<ConfContabilidad>(request);
                var respuesta = await _configContabilidad.Editar(_confConta);

                if (respuesta)
                    _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = true, msg = "ok", value = _mapper.Map<ConfigContabilidadDTO>(_confConta) };
                else
                    _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = "No se pudo editar el Colaborador" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }
        [HttpDelete]
        [Route("Eliminar/{Id}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                ConfContabilidad _configEliminar = await _configContabilidad.Filtrar(u => u.IdConfig == Id);

                if (_configEliminar != null)
                {

                    bool respuesta = await _configContabilidad.Eliminar(_configEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la Configuracion", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
