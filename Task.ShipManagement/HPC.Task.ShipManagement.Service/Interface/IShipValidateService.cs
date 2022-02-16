using Task.ShipManagement.Model;

namespace Task.ShipManagement.Service.Interface
{
    public interface IShipValidateService
    {
        bool IsShipValid(Ship ship);
    }
}
