using Verifarma_Challenge_Backend.Models;

namespace Verifarma_Challenge_Backend.Services
{
    public interface IFarmaciaService
    {
        Task AgregarFarmaciaAleatoriaAsync();
        Task CrearFarmaciaAsync(Farmacia farmacia);
        Task<Farmacia> BuscarFarmaciaByIdAsync(int? id, string? nombre);
        Task<Farmacia> BuscarFarmaciaCercanaAsync(decimal latitud, decimal longitud);
    }
}
