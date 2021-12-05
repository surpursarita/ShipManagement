using HPC.Task.ShipManagement.DAL.Implementation;
using HPC.Task.ShipManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HPC.Task.ShipManagement.DAL.Test
{
    [TestClass]
    public class ShipRepositoryTest
    {
        protected ShipRepository shipRepository;

        [TestInitialize]
        public void Initialize()
        {
            shipRepository = new ShipRepository();
        }

        [TestMethod]
        public void Get_Test()
        {
            // Arrange            
            var id = Guid.NewGuid().ToString();
            var ships = this.shipRepository.GetShips().Result;

            // Act            
            var actualShip = this.shipRepository.Get(ships[0].Id).Result;

            //Assert
            Assert.IsNotNull(actualShip);
            Assert.AreEqual(actualShip, ships[0]);
        }

        [TestMethod]
        public void Get_NotFound_Test()
        {
            // Arrange            
            var id = Guid.NewGuid().ToString();            

            // Act            
            var actualShip = this.shipRepository.Get(id).Result;

            //Assert
            Assert.IsNull(actualShip);
        }

        [TestMethod]
        public void GetShips_Test()
        {
            // Arrange            
            var id = Guid.NewGuid().ToString();            

            // Act            
            var actualShips = this.shipRepository.GetShips().Result;

            //Assert
            Assert.IsNotNull(actualShips);
            Assert.IsTrue(actualShips.Count > 0);
        }

        [TestMethod]
        public void Create_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();            

            // Act            
            var result = this.shipRepository.Create(expectedShip).Result;
            var actualShip = this.shipRepository.Get(result).Result;

            //Assert            
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedShip.Name, actualShip.Name);
            Assert.AreEqual(expectedShip.Length, actualShip.Length);
            Assert.AreEqual(expectedShip.Width, actualShip.Width);
            Assert.AreEqual(expectedShip.Code, actualShip.Code);
            Assert.AreEqual(expectedShip.Description, actualShip.Description);
            Assert.IsNotNull(expectedShip.CreatedBy);
            Assert.IsNotNull(expectedShip.CreatedDate);
            Assert.IsNotNull(expectedShip.ModifiedBy);
            Assert.IsNotNull(expectedShip.ModifiedDate);
        }

        [TestMethod]
        public void Update_Test()
        {
            // Arrange
            var result = this.shipRepository.GetShips().Result;
            var expectedShip = ShipDetails();
            expectedShip.Id = result[0].Id;

            // Act            
            var actualShip = this.shipRepository.Update(expectedShip).Result;

            //Assert            
            Assert.IsNotNull(actualShip);
            Assert.AreEqual(expectedShip.Name, actualShip.Name);
            Assert.AreEqual(expectedShip.Length, actualShip.Length);
            Assert.AreEqual(expectedShip.Width, actualShip.Width);
            Assert.AreEqual(expectedShip.Code, actualShip.Code);
            Assert.AreEqual(expectedShip.Description, actualShip.Description);
            Assert.IsTrue(expectedShip.ModifiedDate < actualShip.ModifiedDate);
        }

        [TestMethod]
        public void Delete_Test()
        {
            // Arrange
            var expectedShip = ShipDetails();

            // Act            
            var result = this.shipRepository.Create(expectedShip).Result;
            var deleteResult = this.shipRepository.Delete(result).Result;

            //Assert
            Assert.IsTrue(deleteResult);
        }

        private Ship ShipDetails()
        {
            return new Ship()
            {                
                Name = "New Ship1",
                Length = 200,
                Width = 50,
                Code = "BBBB-2222-B2",
                Description = "New Ship1 Description"
            };
        }

        private Ship UpdateShipDetails()
        {
            return new Ship()
            {
                Name = "New Ship2",
                Length = 204,
                Width = 55,
                Code = "BBBB-3333-B3",
                Description = "New Ship2 Description"
            };
        }
    }
}
