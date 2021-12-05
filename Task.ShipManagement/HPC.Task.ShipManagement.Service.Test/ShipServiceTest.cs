using HPC.Task.ShipManagement.DAL.Interface;
using HPC.Task.ShipManagement.Model;
using HPC.Task.ShipManagement.Service.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace HPC.Task.ShipManagement.Service.Test
{
    [TestClass]
    public class ShipServiceTest
    {
        protected ShipService shipService;
        protected Mock<IShipRepository> mockShipRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockShipRepository = new Mock<IShipRepository>();
            shipService = new ShipService(mockShipRepository.Object);
        }

        [TestMethod]
        public void Get_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();
            var id = Guid.NewGuid().ToString();
            this.mockShipRepository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(expectedShip);

            // Act            
            var actualShip = this.shipService.Get(id).Result;            

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipRepository.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
            
            Assert.AreEqual(expectedShip, actualShip);
        }

        [TestMethod]
        public void GetShips_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();            
            var expectedShipList = new List<Ship>() { expectedShip };
            this.mockShipRepository.Setup(x => x.GetShips()).ReturnsAsync(expectedShipList);

            // Act            
            var actualShipList = this.shipService.GetShips().Result;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipRepository.Verify(x => x.GetShips(), Times.Once);

            Assert.AreEqual(expectedShipList, actualShipList);
        }

        [TestMethod]
        public void Create_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();
            var id = Guid.NewGuid().ToString();
            this.mockShipRepository.Setup(x => x.Create(It.IsAny<Ship>())).ReturnsAsync(id);

            // Act            
            var actualId = this.shipService.Create(expectedShip).Result;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipRepository.Verify(x => x.Create(It.IsAny<Ship>()), Times.Once);

            Assert.IsNotNull(actualId);
            Assert.AreEqual(id, actualId);
        }

        [TestMethod]
        public void Update_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();            
            this.mockShipRepository.Setup(x => x.Update(It.IsAny<Ship>())).ReturnsAsync(expectedShip);

            // Act            
            var actualShip = this.shipService.Update(expectedShip).Result;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipRepository.Verify(x => x.Update(It.IsAny<Ship>()), Times.Once);
                        
            Assert.AreEqual(expectedShip, actualShip);
        }

        [TestMethod]
        public void Delete_Test()
        {
            // Arrange            
            var id = Guid.NewGuid().ToString();
            this.mockShipRepository.Setup(x => x.Delete(It.IsAny<string>())).ReturnsAsync(true);

            // Act            
            var result = this.shipService.Delete(id).Result;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipRepository.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
                        
            Assert.IsTrue(result);
        }

        private Ship ShipDetails()
        {
            return new Ship()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Default Ship",
                Length = 200,
                Width = 50,
                Code = "AAAA-1111-D1",
                Description = "Default Ship Description"
            };
        }
    }
}
