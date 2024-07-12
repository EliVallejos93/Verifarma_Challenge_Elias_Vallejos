using System.ComponentModel.DataAnnotations;

namespace Verifarma_Challenge_Backend.DTOs
{
    //este DTO es solo de muestra ya que el sistema no lo requiere.
    //lo usaremos solo para mostrar el conocimiento.
    public class FarmaciaDto
    {
        public int IdFarmacia { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
    }
}
