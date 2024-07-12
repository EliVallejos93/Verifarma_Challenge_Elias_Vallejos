using Verifarma_Challenge_Backend.Data.Repositories;
using Verifarma_Challenge_Backend.Models;

namespace Verifarma_Challenge_Backend.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IFarmaciaRepository<Farmacia>? _farmaciaRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IFarmaciaRepository<Farmacia> FarmaciaRepository
        {
            get { return _farmaciaRepository ?? (_farmaciaRepository = new FarmaciaRepository(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
