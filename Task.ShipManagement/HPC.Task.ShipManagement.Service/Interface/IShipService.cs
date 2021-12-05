using HPC.Task.ShipManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPC.Task.ShipManagement.Service.Interface
{
    public interface IShipService
    {
        Task<List<Ship>> GetShips();
        Task<Ship> Get(string id);
        Task<string> Create(Ship ship);
        Task<Ship> Update(Ship ship);
        Task<bool> Delete(string id);
    }
}
