using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nexos.Cliente.Domain.Core.Models;
using Nexos.Cliente.Domain.Core.Services.InterfaceService;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nexos.Cliente.Core.API.Controllers
{
    /// <summary>
    /// Cantrolador para el manejo de autores
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AutorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReadableAutorService _readableAutorService;
        private readonly IWriteableAutorService _writeableAutorService;
        private readonly IRemovableAutorService _removableAutorService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="readableAutorService"></param>
        /// <param name="writeableAutorService"></param>
        /// <param name="removableAutorService"></param>
        public AutorController(IMapper mapper, IReadableAutorService readableAutorService, IWriteableAutorService writeableAutorService, IRemovableAutorService removableAutorService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _readableAutorService = readableAutorService ?? throw new ArgumentNullException(nameof(readableAutorService));
            _writeableAutorService = writeableAutorService ?? throw new ArgumentNullException(nameof(writeableAutorService));
            _removableAutorService = removableAutorService ?? throw new ArgumentNullException(nameof(removableAutorService));
        }

        /// <summary>
        /// Crear autor
        /// </summary>
        /// <param name="autor"></param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("PostAutor")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAutor(BindingModel.AutorDTO autor)
        {
            try
            {
                var autorM = _mapper.Map<Autor>(autor);

                var result = await _writeableAutorService.PostAutor(autorM);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }

        /// <summary>
        /// Obtener listado de autores
        /// </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("GetAutores")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAutores()
        {
            try
            {
                var result = await _readableAutorService.GetAutores();
                if (!result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }

        /// <summary>
        /// Obtener autor por id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("GetAutor")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAutor(int id)
        {
            try
            {
                var result = await _readableAutorService.GetAutorById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }

        /// <summary>
        /// Editar autor
        /// </summary>
        /// <param name="autor"></param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("PutAutor")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PutAutor(BindingModel.AutorDTO autor)
        {
            try
            {
                var autorM = _mapper.Map<Autor>(autor);

                var result = await _writeableAutorService.PutAutor(autorM);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }

        /// <summary>
        /// Eliminar autor
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">InternalServerError. Error en el servidor.</response>
        /// <returns></returns>
        [HttpPost("DeleteAutor")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            try
            {
                var result = await _removableAutorService.DeleteAutor(id);
                if (result == 0)
                    return BadRequest();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Code = 500, Message = "Algo salió mal. Por favor inténtelo de nuevo o contacte a su administrador.", DevMessage = e.Message });
            }
        }
    }
}
