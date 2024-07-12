using Verifarma_Challenge_Backend.Data.Repositories;
using Verifarma_Challenge_Backend.Models;

namespace Verifarma_Challenge_Backend.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IFarmaciaRepository<Farmacia> FarmaciaRepository { get; }
        void Save();
    }
}
