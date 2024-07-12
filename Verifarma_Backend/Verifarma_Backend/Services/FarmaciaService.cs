using Microsoft.EntityFrameworkCore;
using Verifarma_Challenge_Backend.Data.UnitOfWork;
using Verifarma_Challenge_Backend.Models;

namespace Verifarma_Challenge_Backend.Services
{
    public class FarmaciaService : IFarmaciaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FarmaciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AgregarFarmaciaAleatoriaAsync()
        {
            _unitOfWork.FarmaciaRepository.InsertarDatosAleatorios();

            await Task.CompletedTask;
        }

        public async Task CrearFarmaciaAsync(Farmacia farmacia)
        {
            //si falta algun dato tiro un error
            if (farmacia.Nombre == null || farmacia.Nombre == "" ||
                farmacia.Direccion == null || farmacia.Direccion == "" ||
                farmacia.Latitud == 0 || farmacia.Longitud == 0)
            {
                throw ExcepcionService.BadRequestException("Faltan datos de Farmacia");
            }

            farmacia.IdFarmacia = 0;
            _unitOfWork.FarmaciaRepository.Add(farmacia);
            _unitOfWork.Save();

            await Task.CompletedTask;
        }

        public async Task<Farmacia> BuscarFarmaciaByIdAsync(int? id, string? nombre)
        {
            if (id != null)
                return await _unitOfWork.FarmaciaRepository.GetByIdAsync((int)id);

            else if (nombre != null && nombre != "")
                return await _unitOfWork.FarmaciaRepository.GetByNombreAsync(nombre);

            else
                throw ExcepcionService.BadRequestException("debe introducir id o nombre");
        }

        public async Task<Farmacia> BuscarFarmaciaCercanaAsync(decimal latitud, decimal longitud)
        {
            var farmacias = await _unitOfWork.FarmaciaRepository.GetAllAsync();

            Farmacia? farmaciaCercana = null;
            double distanciaMinima = double.MaxValue;

            foreach (var farmacia in farmacias)
            {
                var distancia = HaversineService.Distancia((double)latitud, (double)longitud, (double)farmacia.Latitud, (double)farmacia.Longitud);

                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    farmaciaCercana = farmacia;
                }
            }

            if (farmaciaCercana != null)
                return farmaciaCercana;
            else
                throw ExcepcionService.FarmaciaNoEncontradaException("No se encontraron farmacias cercanas");
        }
    }
}
