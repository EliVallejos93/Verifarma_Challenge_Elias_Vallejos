using Moq;
using Verifarma_Challenge_Backend.Controllers;
using Verifarma_Challenge_Backend.Models;
using Verifarma_Challenge_Backend.Services;
using Verifarma_Challenge_Backend.Data.UnitOfWork;
using Verifarma_Challenge_Backend.Data.Repositories;
using Microsoft.Extensions.Logging;

namespace Verifarma_Challenge_TestProject_XUnit
{
    //Tests unitarios
    public class TestProject_XUnit
    {
        private readonly Mock<IFarmaciaService> _mockFaciaService;
        private readonly Mock<ILogger<FarmaciasController>> _mockLogger;
        private readonly FarmaciasController _faciasController;

        public TestProject_XUnit()
        {
            _mockFaciaService = new Mock<IFarmaciaService>();
            _mockLogger = new Mock<ILogger<FarmaciasController>>();
            _faciasController = new FarmaciasController(_mockFaciaService.Object, _mockLogger.Object);
        }

        // *** Test de Creacion de Farmacia ***
        //Test de Éxito
        [Fact]
        public async Task CrearFarmacia_DeberiaRetornarTrue_SiFarmaciaEsValidaAsync()
        {
            // Arrange
            var farmacia = new Farmacia { Nombre = "Farmacia Central", Direccion = "Calle Principal 123", Latitud = 40.7128M, Longitud = -74.0060M };
            var mockRepository = new Mock<IFarmaciaRepository<Farmacia>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FarmaciaRepository).Returns(mockRepository.Object);

            var service = new FarmaciaService(mockUnitOfWork.Object);

            // Act
            try
            {
                await service.CrearFarmaciaAsync(farmacia);
            }
            catch (Exception)
            {
                // Assert
                Assert.True(false);
            }

            // Assert
            mockRepository.Verify(r => r.Add(It.IsAny<Farmacia>()), Times.Once);
            mockUnitOfWork.Verify(u => u.Save(), Times.Once);
            Assert.True(true);
        }

        //Test de Fallo
        [Fact]
        public void CrearFarmacia_DeberiaRetornarFalse_SiFarmaciaEsInvalida()
        {
            // Arrange
            var farmacia = new Farmacia { Nombre = "", Direccion = "Calle Principal 123", Latitud = 40.7128M, Longitud = -74.0060M };
            var mockRepository = new Mock<IFarmaciaRepository<Farmacia>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FarmaciaRepository).Returns(mockRepository.Object);

            var service = new FarmaciaService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsAsync<ExcepcionService>(async () => await service.CrearFarmaciaAsync(farmacia));
            mockRepository.Verify(r => r.Add(It.IsAny<Farmacia>()), Times.Never);
            mockUnitOfWork.Verify(u => u.Save(), Times.Never);
        }


        // *** Test de Calculo de Distancias ***
        [Fact]
        public void Distancia_DosPuntosCercanos_DeberiaRetornarDistanciaCorrecta()
        {
            // Arrange
            double lat1 = 40.7128;
            double lon1 = -74.0060;
            double lat2 = 40.7128;
            double lon2 = -74.0060;

            // Act
            double distancia = HaversineService.Distancia(lat1, lon1, lat2, lon2);

            // Assert
            Assert.Equal(0, distancia, precision: 5);
        }
    }
}