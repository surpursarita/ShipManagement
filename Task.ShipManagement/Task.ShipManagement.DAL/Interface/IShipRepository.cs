using Task.ShipManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task.ShipManagement.DAL.Interface
{
    public interface IShipRepository
    {
        Task<List<Ship>> GetShips();
        Task<Ship> Get(string id);
        Task<string> Create(Ship ship);
        Task<Ship> Update(Ship ship);
        Task<bool> Delete(string id);
    }
}
