using Task.ShipManagement.Model;
using Task.ShipManagement.Service.Interface;
using System.Text.RegularExpressions;

namespace Task.ShipManagement.Service.Implementation
{
    public class ShipValidateService : IShipValidateService
    {
        public bool IsShipValid(Ship ship)
        {
            if (ship == null)
                return false;

            return Regex.IsMatch(ship.Code, @"^[A-Za-z]{4}[-][0-9]{4}[-][A-Za-z]{1}[0-9]{1}\z");
        }
    }
}
