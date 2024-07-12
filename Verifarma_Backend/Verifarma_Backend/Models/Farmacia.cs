using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Verifarma_Challenge_Backend.Models
{
    public class Farmacia
    {
        [Key]
        public int IdFarmacia { get; set; }

        [Required]
        [StringLength(16)]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(16)]
        public required string Direccion { get; set; }

        [Required]
        public required decimal Latitud { get; set; }

        [Required]
        public required decimal Longitud { get; set; }
    }
}
