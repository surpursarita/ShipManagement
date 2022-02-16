using Task.ShipManagement.Model;
using Task.ShipManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Task.ShipManagement.API.Controllers
{
    [Route("api/v1/[controller]")]    
    public class ShipController : ApiController
    {
        private readonly IShipValidateService shipValidateService;
        private readonly IShipService shipService;

        /// <summary>
        /// Initializes the instance of <see cref="ShipController"/> class.
        /// </summary>
        /// <param name="shipValidateService">Instance of IShipValidateService</param>
        /// <param name="shipService">Instance of IShipService</param>
        public ShipController(IShipValidateService shipValidateService, IShipService shipService)
        {
            this.shipValidateService = shipValidateService;
            this.shipService = shipService;
        }

        [HttpGet]
        [Route("GetShips")]        
        public async Task<IActionResult> GetShips()
        {
            var response = await shipService.GetShips();
            
            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            var response = await shipService.Get(id);

            if(response == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ship ship)
        {
            if (!ModelState.IsValid || !shipValidateService.IsShipValid(ship))
            {
                return new BadRequestResult();
            }

            var response = await shipService.Create(ship);
            return new OkObjectResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Ship ship)
        {
            if (!ModelState.IsValid || !shipValidateService.IsShipValid(ship))
            {
                return new BadRequestResult();
            }

            var response = await shipService.Update(ship);
            return new OkObjectResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            var response = await shipService.Delete(id);
            return new OkObjectResult(response);
        }
    }
}