using HPC.Task.ShipManagement.Model;

namespace HPC.Task.ShipManagement.Service.Interface
{
    public interface IShipValidateService
    {
        bool IsShipValid(Ship ship);
    }
}
