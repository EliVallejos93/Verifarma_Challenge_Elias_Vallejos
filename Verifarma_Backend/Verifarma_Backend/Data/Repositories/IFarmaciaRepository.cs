namespace Verifarma_Challenge_Backend.Data.Repositories
{
    public interface IFarmaciaRepository<T> where T : class
    {
        void InsertarDatosAleatorios();
        void Add(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByNombreAsync(string nombre);
    }
}
