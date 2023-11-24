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

namespace Sis.Alcaldia.Server.Controllers.Colaborador
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        public ColaboradoresController(IColaboradorRepositorio colaboradorRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _colaboradorRepositorio = colaboradorRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ColaboradoresDTO>> _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>();

            try
            {
                List<ColaboradoresDTO> ListaUsuarios = new List<ColaboradoresDTO>();
                IQueryable<CliColaboradore> query = await _colaboradorRepositorio.Consultar();
                //query = query.Include(r => r.IdRolUsuarioNavigation);

                ListaUsuarios = _mapper.Map<List<ColaboradoresDTO>>(query.ToList());

                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = true, msg = "ok", value = ListaUsuarios };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ColaboradoresDTO request)
        {
            ResponseDTO<ColaboradoresDTO> _ResponseDTO = new ResponseDTO<ColaboradoresDTO>();
            try
            {
                CliColaboradore _colaborador = _mapper.Map<CliColaboradore>(request);

                CliColaboradore _usuarioCreado = await _colaboradorRepositorio.Crear(_colaborador);

                if (_usuarioCreado.Idcolaborador != 0)
                    _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = true, msg = "ok", value = _mapper.Map<ColaboradoresDTO>(_usuarioCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = "No se pudo crear el Colaborador" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ColaboradoresDTO request)
        {
            ResponseDTO<ColaboradoresDTO> _ResponseDTO = new ResponseDTO<ColaboradoresDTO>();
            try
            {
                CliColaboradore _colaborador = _mapper.Map<CliColaboradore>(request);
                CliColaboradore _colaboradorParaEditar = await _colaboradorRepositorio.Obtener(u => u.Idcolaborador == _colaborador.Idcolaborador);

                if (_colaboradorParaEditar != null)
                {

                    _colaboradorParaEditar.Nombre = _colaborador.Nombre;
                    _colaboradorParaEditar.CorreoElectronico = _colaborador.CorreoElectronico;
                    _colaboradorParaEditar.Ci = _colaborador.Ci;

                    bool respuesta = await _colaboradorRepositorio.Editar(_colaboradorParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = true, msg = "ok", value = _mapper.Map<ColaboradoresDTO>(_colaboradorParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = "No se pudo editar el Colaborador" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = "No se encontró el Colaborador" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = ex.Message };
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
                CliColaboradore _usuarioEliminar = await _colaboradorRepositorio.Obtener(u => u.Idcolaborador == id);

                if (_usuarioEliminar != null)
                {

                    bool respuesta = await _colaboradorRepositorio.Eliminar(_usuarioEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el Colaborador", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Obtener/{IdColaborador}")]
        public async Task<IActionResult> Obtener(int IdColaborador)
        {
            ResponseDTO<ColaboradoresDTO> _ResponseDTO = new ResponseDTO<ColaboradoresDTO>();

            try
            {
                ColaboradoresDTO Modelo = new ColaboradoresDTO();

                IQueryable<CliColaboradore> query = await _colaboradorRepositorio.Consultar(c => c.Idcolaborador == IdColaborador);
                query = query.Include(r => r.CliFacturas);

                Modelo = _mapper.Map<ColaboradoresDTO>(query.FirstOrDefault());

                _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = true, msg = "ok", value = Modelo };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ColaboradoresDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        
        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            ResponseDTO<List<ColaboradoresDTO>> _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>();
            try
            {
                List<ColaboradoresDTO> ListaColaborador = new List<ColaboradoresDTO>();
                List<CliColaboradore> query = await _colaboradorRepositorio.GetAllData();
                ListaColaborador = _mapper.Map<List<ColaboradoresDTO>>(query);
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = true, msg = "ok", value = ListaColaborador };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpGet("GetColFac/{id}")]
        public async Task<IActionResult> GetColFac(int Id)
        {
            ResponseDTO<List<ColaboradoresDTO>> _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>();
            try
            {
                List<ColaboradoresDTO> ListaColaborador = new List<ColaboradoresDTO>();
                List<CliColaboradore> query = await _colaboradorRepositorio.GetColFac(Id);
                ListaColaborador = _mapper.Map<List<ColaboradoresDTO>>(query);
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = true, msg = "ok", value = ListaColaborador };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("ConfigConta")]
        public async Task<IActionResult> ConfigConta()
        {
            ResponseDTO<ConfigContabilidadDTO> _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>();

            try
            {
                ConfigContabilidadDTO ListaConfig = new ConfigContabilidadDTO();
                ConfContabilidad query = await _colaboradorRepositorio.ConfigConta();

                ListaConfig = _mapper.Map<ConfigContabilidadDTO>(query);

                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = true, msg = "ok", value = ListaConfig };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ConfigContabilidadDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpGet("GetColFactPag/{IdCol}/{IdFac}")]
        public async Task<IActionResult> GetColFactPag(int IdCol, int IdFac)
        {
            ResponseDTO<List<ColaboradoresDTO>> _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>();
            try
            {
                List<ColaboradoresDTO> ListaColaborador = new List<ColaboradoresDTO>();
                List<CliColaboradore> query = await _colaboradorRepositorio.GetColFactPag(IdCol, IdFac);
                ListaColaborador = _mapper.Map<List<ColaboradoresDTO>>(query);
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = true, msg = "ok", value = ListaColaborador };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ColaboradoresDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        #region Facturas
        [HttpPost]
        [Route("CrearFacturas")]
        public async Task<IActionResult> CrearFacturas([FromBody] FacturasDTO request)
        {
            ResponseDTO<FacturasDTO> _ResponseDTO = new ResponseDTO<FacturasDTO>();
            try
            {
                CliFactura _facturas = _mapper.Map<CliFactura>(request);
                //Factura
                Random random = new Random();
                int numrandom = random.Next(0, 10);

                int año = _facturas.FechaEmision?.Year ?? 0;
                int mes = _facturas.FechaEmision?.Month ?? 0;

                var factura = $"F{año}{mes:D2}" + numrandom.ToString();
                _facturas.NumeroFactura = factura;

                CliFactura _facturaCreado = await _colaboradorRepositorio.CrearFacturas(_facturas);

                if (_facturaCreado.Idcolaborador != 0)
                    _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = true, msg = "ok", value = _mapper.Map<FacturasDTO>(_facturaCreado) };
                else
                    _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = false, msg = "No se pudo crear el Colaborador" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpPut]
        [Route("EditarFacturas")]
        public async Task<IActionResult> EditarFacturas([FromBody] FacturasDTO request)
        {
            ResponseDTO<FacturasDTO> _ResponseDTO = new ResponseDTO<FacturasDTO>();
            try
            {
                CliFactura _facturas = _mapper.Map<CliFactura>(request);
                CliFactura _facturasparaEditar = await _colaboradorRepositorio.ObtenerFacturas(u => u.Idfactura == _facturas.Idfactura);

                if (_facturasparaEditar != null)
                {
                    //Factura
                    Random random = new Random();
                    int numrandom = random.Next(0, 10);

                    int año = _facturasparaEditar.FechaEmision?.Year ?? 0;
                    int mes = _facturasparaEditar.FechaEmision?.Month ?? 0;

                    var factura = $"F{año}{mes:D2}" + numrandom.ToString();

                    _facturasparaEditar.NumeroFactura = factura;
                    _facturasparaEditar.Idcolaborador = _facturas.Idcolaborador;
                    _facturasparaEditar.FechaEmision = _facturas.FechaEmision;
                    _facturasparaEditar.FechaVencimiento = _facturas.FechaVencimiento;
                    _facturasparaEditar.Concepto = _facturas.Concepto;
                    _facturasparaEditar.Monto = _facturas.Monto;
                    _facturasparaEditar.EstadoPago = _facturas.EstadoPago;



                    bool respuesta = await _colaboradorRepositorio.EditarFacturas(_facturasparaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = true, msg = "ok", value = _mapper.Map<FacturasDTO>(_facturasparaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = false, msg = "No se pudo editar el Colaborador" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = false, msg = "No se encontró el Colaborador" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<FacturasDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }
        [HttpDelete]
        [Route("EliminarFacturas/{id:int}")]
        public async Task<IActionResult> EliminarFacturas(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                CliFactura _facturasEliminar = await _colaboradorRepositorio.ObtenerFacturas(u => u.Idfactura == id);

                if (_facturasEliminar != null)
                {

                    bool respuesta = await _colaboradorRepositorio.EliminarFacturas(_facturasEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la Factura", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        #endregion
        
        #region Pagos
        [HttpPost]
        [Route("CrearPagos")]
        public async Task<IActionResult> CrearPagos([FromBody] PagosDTO request)
        {
            ResponseDTO<PagosDTO> _ResponseDTO = new ResponseDTO<PagosDTO>();
            try
            {
                CliPago _pagos = _mapper.Map<CliPago>(request);

                CliPago _pagosCreado = await _colaboradorRepositorio.CrearPagos(_pagos);

                if (_pagosCreado.Idcolaborador != 0)
                    _ResponseDTO = new ResponseDTO<PagosDTO>() { status = true, msg = "ok", value = _mapper.Map<PagosDTO>(_pagosCreado) };
                else
                    _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = "No se pudo crear el Pago" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("EditarPagos")]
        public async Task<IActionResult> EditarPagos([FromBody] PagosDTO request)
        {
            ResponseDTO<PagosDTO> _ResponseDTO = new ResponseDTO<PagosDTO>();
            try
            {
                CliPago _pagos = _mapper.Map<CliPago>(request);
                CliPago _pagosparaEditar = await _colaboradorRepositorio.ObtenerPagos(u => u.Idcolaborador == _pagos.Idcolaborador);

                if (_pagosparaEditar != null)
                {

                    _pagosparaEditar.FechaPago = _pagos.FechaPago;
                    _pagosparaEditar.MetodoPago = _pagos.MetodoPago;
                    _pagosparaEditar.Descuentos = _pagos.Descuentos;
                    _pagosparaEditar.Bonos = _pagos.Bonos;
                    _pagosparaEditar.Detalle = _pagos.Detalle;

                    bool respuesta = await _colaboradorRepositorio.EditarPagos(_pagosparaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<PagosDTO>() { status = true, msg = "ok", value = _mapper.Map<PagosDTO>(_pagosparaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = "No se pudo editar el Pago" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = "No se encontró el Colaborador" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }
        [HttpDelete]
        [Route("EliminarPagos/{id:int}")]
        public async Task<IActionResult> EliminarPagos(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                CliPago _pagosEliminar = await _colaboradorRepositorio.ObtenerPagos(u => u.Idcolaborador == id);

                if (_pagosEliminar != null)
                {

                    bool respuesta = await _colaboradorRepositorio.EliminarPagos(_pagosEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el detalle del Pago", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet("ListaPagos/{id}")]
        public async Task<IActionResult> ListaPagos(int Id)
        {
            ResponseDTO<PagosDTO> _ResponseDTO = new ResponseDTO<PagosDTO>();
            try
            {
                PagosDTO listapagos = new PagosDTO();
                CliPago query = await _colaboradorRepositorio.ListaPagos(Id);
                listapagos = _mapper.Map<PagosDTO>(query);
                _ResponseDTO = new ResponseDTO<PagosDTO>() { status = true, msg = "ok", value = listapagos };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PagosDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        #endregion

    }
}
