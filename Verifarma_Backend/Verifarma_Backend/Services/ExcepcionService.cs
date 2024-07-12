namespace Verifarma_Challenge_Backend.Services
{
    public class ExcepcionService : Exception
    {
        public ExcepcionService(string message) : base(message) { }

        // Método estático para crear FarmaciaNoEncontradaException
        public static ExcepcionService FarmaciaNoEncontradaException(string message)
        {
            return new ExcepcionService(message) { HResult = 404 };  // HResult para representar NotFound
        }

        // Método estático para crear BadRequestException
        public static ExcepcionService BadRequestException(string message)
        {
            return new ExcepcionService(message) { HResult = 400 };  // HResult para representar BadRequest
        }
    }
}
