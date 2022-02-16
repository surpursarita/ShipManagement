using Task.ShipManagement.API.Controllers;
using Task.ShipManagement.Model;
using Task.ShipManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Task.ShipManagement.API.Test
{
    [TestClass]
    public class ShipControllerTest
    {
        protected ShipController shipController;
        protected Mock<IShipValidateService> mockShipValidateService;
        protected Mock<IShipService> mockShipService;
        protected string url;

        [TestInitialize]
        public void Initialize()
        {
            mockShipValidateService = new Mock<IShipValidateService>();
            mockShipService = new Mock<IShipService>();
            shipController = new ShipController(mockShipValidateService.Object, mockShipService.Object);
            url = "http://test.com";
        }

        [TestMethod]
        public void Get_OK_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            var id = Guid.NewGuid().ToString();
            this.mockShipService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(expectedShip);            

            // Act            
            var mockResponseMsg = this.shipController.Get(id).Result;
            var okObjectResult = mockResponseMsg as OkObjectResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipService.Verify(x => x.Get(It.IsAny<string>()), Times.Once);    
            
            Assert.AreEqual(200, okObjectResult.StatusCode);
            var actualShip = okObjectResult.Value as Ship;
            Assert.AreEqual(expectedShip, actualShip);
        }

        [TestMethod]
        public void Get_NotFound_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;            
            var id = Guid.NewGuid().ToString();
            this.mockShipService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync((Ship)null);

            // Act            
            var mockResponseMsg = this.shipController.Get(id).Result;
            var result = mockResponseMsg as NotFoundResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipService.Verify(x => x.Get(It.IsAny<string>()), Times.Once);

            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void GetShips_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            var expectedShipList = new List<Ship>() { expectedShip };            
            this.mockShipService.Setup(x => x.GetShips()).ReturnsAsync(expectedShipList);

            // Act            
            var mockResponseMsg = this.shipController.GetShips().Result;
            var okObjectResult = mockResponseMsg as OkObjectResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipService.Verify(x => x.GetShips(), Times.Once);

            Assert.AreEqual(200, okObjectResult.StatusCode);
            var actualShipList = okObjectResult.Value as List<Ship>;
            Assert.AreEqual(expectedShipList, actualShipList);
        }

        [TestMethod]
        public void Post_OK_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            expectedShip.Id = null;
            var id = Guid.NewGuid().ToString();
            this.mockShipValidateService.Setup(x => x.IsShipValid(It.IsAny<Ship>())).Returns(true);
            this.mockShipService.Setup(x => x.Create(It.IsAny<Ship>())).ReturnsAsync(id);

            // Act            
            var mockResponseMsg = this.shipController.Post(expectedShip).Result;
            var okObjectResult = mockResponseMsg as OkObjectResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipValidateService.Verify(x => x.IsShipValid(It.IsAny<Ship>()), Times.Once);
            this.mockShipService.Verify(x => x.Create(It.IsAny<Ship>()), Times.Once);

            Assert.AreEqual(200, okObjectResult.StatusCode);
            var actualId = okObjectResult.Value as string;
            Assert.IsNotNull(actualId);
            Assert.AreEqual(id, actualId);
        }

        [TestMethod]
        public void Post_BadRequest_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            var id = Guid.NewGuid().ToString();
            this.mockShipValidateService.Setup(x => x.IsShipValid(It.IsAny<Ship>())).Returns(false);
            this.mockShipService.Setup(x => x.Create(It.IsAny<Ship>())).ReturnsAsync(id);

            // Act            
            var mockResponseMsg = this.shipController.Post(expectedShip).Result;
            var result = mockResponseMsg as BadRequestResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipValidateService.Verify(x => x.IsShipValid(It.IsAny<Ship>()), Times.Once);
            this.mockShipService.Verify(x => x.Create(It.IsAny<Ship>()), Times.Never);

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void Put_OK_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            this.mockShipValidateService.Setup(x => x.IsShipValid(It.IsAny<Ship>())).Returns(true);
            this.mockShipService.Setup(x => x.Update(It.IsAny<Ship>())).ReturnsAsync(expectedShip);

            // Act            
            var mockResponseMsg = this.shipController.Put(expectedShip).Result;
            var okObjectResult = mockResponseMsg as OkObjectResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipValidateService.Verify(x => x.IsShipValid(It.IsAny<Ship>()), Times.Once);
            this.mockShipService.Verify(x => x.Update(It.IsAny<Ship>()), Times.Once);

            Assert.AreEqual(200, okObjectResult.StatusCode);
            var actualShip = okObjectResult.Value as Ship;
            Assert.AreEqual(expectedShip, actualShip);
        }

        [TestMethod]
        public void Put_BadRequest_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;
            var expectedShip = ShipDetails();
            this.mockShipValidateService.Setup(x => x.IsShipValid(It.IsAny<Ship>())).Returns(false);
            this.mockShipService.Setup(x => x.Update(It.IsAny<Ship>())).ReturnsAsync(expectedShip);

            // Act            
            var mockResponseMsg = this.shipController.Put(expectedShip).Result;
            var result = mockResponseMsg as BadRequestResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.
            this.mockShipValidateService.Verify(x => x.IsShipValid(It.IsAny<Ship>()), Times.Once);
            this.mockShipService.Verify(x => x.Update(It.IsAny<Ship>()), Times.Never);

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void Delete_Test()
        {
            // Arrange            
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.Add("NewRequest", Guid.NewGuid().ToString());
            this.shipController.Request = request;            
            var id = Guid.NewGuid().ToString();
            this.mockShipService.Setup(x => x.Delete(id)).ReturnsAsync(true);

            // Act            
            var mockResponseMsg = this.shipController.Delete(id).Result;
            var okObjectResult = mockResponseMsg as OkObjectResult;

            //Assert
            // Verify is used to check if the all dependecy is called or not.            
            this.mockShipService.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);

            Assert.AreEqual(200, okObjectResult.StatusCode);
            var result = (Boolean)okObjectResult.Value;
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
