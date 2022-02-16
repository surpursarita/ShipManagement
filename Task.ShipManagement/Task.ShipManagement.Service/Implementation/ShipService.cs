using Task.ShipManagement.DAL.Interface;
using Task.ShipManagement.Model;
using Task.ShipManagement.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.ShipManagement.Service.Implementation
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            this.shipRepository = shipRepository;
        }

        public async Task<List<Ship>> GetShips()
        {
            return await shipRepository.GetShips();
        }

        public async Task<Ship> Get(string id)
        {
            return await shipRepository.Get(id);
        }

        public async Task<string> Create(Ship ship)
        {
            return await shipRepository.Create(ship);
        }

        public async Task<Ship> Update(Ship ship)
        {
            return await shipRepository.Update(ship);
        }

        public async Task<bool> Delete(string id)
        {
            return await shipRepository.Delete(id);
        }
    }
}