using Microsoft.EntityFrameworkCore;
using Verifarma_Challenge_Backend.Models;
using Verifarma_Challenge_Backend.Services;

namespace Verifarma_Challenge_Backend.Data.Repositories
{
    public class FarmaciaRepository : IFarmaciaRepository<Farmacia>
    {
        private readonly ApplicationDbContext _context;

        public FarmaciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InsertarDatosAleatorios()
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_InsertarFarmaciasAleatorias");
        }

        public void Add(Farmacia entity)
        {
            _context.Farmacia.Add(entity);
        }

        public async Task<List<Farmacia>> GetAllAsync()
        {
            return await _context.Farmacia.ToListAsync();
        }

        public async Task<Farmacia> GetByIdAsync(int id)
        {
            var facia = await _context.Farmacia.FindAsync(id);
            if (facia != null)
                return facia;
            else
                throw ExcepcionService.FarmaciaNoEncontradaException("Farmacia no encontrada");
        }

        public async Task<Farmacia> GetByNombreAsync(string nombre)
        {
            var facia = await _context.Farmacia.FirstOrDefaultAsync(t => t.Nombre.ToLower().Contains(nombre.ToLower()));
            if (facia != null)
                return facia;
            else
                throw ExcepcionService.FarmaciaNoEncontradaException("Farmacia no encontrada");
        }


    }
}
