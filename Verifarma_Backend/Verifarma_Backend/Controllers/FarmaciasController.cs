using Microsoft.AspNetCore.Mvc;
using Verifarma_Challenge_Backend.DTOs;
using Verifarma_Challenge_Backend.Models;
using Verifarma_Challenge_Backend.Services;

namespace Verifarma_Challenge_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciasController(IFarmaciaService farmaciaService, ILogger<FarmaciasController> logger) : ControllerBase
    {
        private readonly IFarmaciaService _farmaciaService = farmaciaService;
        private readonly ILogger<FarmaciasController> _logger = logger;

        [HttpGet("InsertarDatosAleatorios")]
        public async Task<IActionResult> InsertarDatosAleatorios()
        {
            try
            {
                _logger.LogInformation("Inicio de InsertarDatosAleatorios");
                await _farmaciaService.AgregarFarmaciaAleatoriaAsync();

                _logger.LogInformation("Datos aleatorios de Farmacia insertados correctamente");
                return Ok(new { code = 200, message = "Datos aleatorios de Farmacia insertados correctamente", data = new { } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al insertar datos aleatorios");
                return StatusCode(500, $"Error al insertar datos aleatorios: {ex.Message}");
            }
        }

        [HttpPost("CrearFarmacia")]
        public async Task<IActionResult> CrearFarmacia(Farmacia farmaciaNueva)
        {
            try
            {
                _logger.LogInformation("Inicio de CrearFarmacia");
                await _farmaciaService.CrearFarmaciaAsync(farmaciaNueva);

                FarmaciaDto farmaciaDto = new()
                {
                    IdFarmacia = farmaciaNueva.IdFarmacia,
                    Nombre = farmaciaNueva.Nombre,
                    Direccion = farmaciaNueva.Direccion
                };

                _logger.LogInformation("Farmacia ingresada correctamente");
                return Ok(new { code = 200, message = "Farmacia ingresada correctamente", data = new { farmaciaDto } });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear farmacia");
                return ex.HResult switch
                {
                    400 => BadRequest(ex.Message),
                    404 => NotFound(ex.Message),
                    _ => StatusCode(500, "Error interno del servidor"),
                };
            }
        }

        [HttpGet("BuscarFarmaciaById")]
        public async Task<IActionResult> BuscarFarmaciaById(int? id, string? nombre)
        {
            try
            {
                _logger.LogInformation("Inicio de BuscarFarmaciaById");
                Farmacia farm = await _farmaciaService.BuscarFarmaciaByIdAsync(id, nombre);

                _logger.LogInformation("Farmacia encontrada");
                return Ok(new { code = 200, message = "Farmacia encontrada", data = farm });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar farmacia por ID o nombre");
                return ex.HResult switch
                {
                    400 => BadRequest(ex.Message),
                    404 => NotFound(ex.Message),
                    _ => StatusCode(500, "Error interno del servidor"),
                };
            }
        }

        [HttpGet("BuscarFarmaciaCercana")]
        public async Task<IActionResult> BuscarFarmaciaCercana(decimal latitud, decimal longitud)
        {
            try
            {
                _logger.LogInformation("Inicio de BuscarFarmaciaCercana");
                Farmacia farm = await _farmaciaService.BuscarFarmaciaCercanaAsync(latitud, longitud);

                _logger.LogInformation("Farmacia cercana encontrada");
                return Ok(new { code = 200, message = "Farmacia cercana encontrada", data = farm });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al buscar farmacia cercana");
                return ex.HResult switch
                {
                    400 => BadRequest(ex.Message),
                    404 => NotFound(ex.Message),
                    _ => StatusCode(500, "Error interno del servidor"),
                };
            }
        }
    }
}
