using Task.ShipManagement.DAL.Interface;
using Task.ShipManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.ShipManagement.DAL.Implementation
{
    public class ShipRepository : IShipRepository
    {
        private static List<Ship> ships = new List<Ship>() { new Ship()
                                                                    {
                                                                        Id = Guid.NewGuid().ToString(),
                                                                        Name = "Default Ship",
                                                                        Length = 200,
                                                                        Width = 50,
                                                                        Code = "AAAA-1111-D1",
                                                                        Description = "Default Ship Description",
                                                                        CreatedBy = Guid.NewGuid().ToString(),
                                                                        CreatedDate = DateTime.Now,
                                                                        ModifiedBy = Guid.NewGuid().ToString(),
                                                                        ModifiedDate = DateTime.Now
                                                                    }                                                                               
                                                            };

        public ShipRepository()
        {
        }

        public async Task<List<Ship>> GetShips()
        {
            return ships;
        }

        public async Task<Ship> Get(string id)
        {
            return ships.FirstOrDefault(s => s.Id == id);
        }

        public async Task<string> Create(Ship ship)
        {
            ship.Id = Guid.NewGuid().ToString();
            ship.CreatedBy = Guid.NewGuid().ToString();
            ship.CreatedDate = DateTime.Now;
            ship.ModifiedBy = Guid.NewGuid().ToString();
            ship.ModifiedDate = DateTime.Now;
            ships.Add(ship);
            return ship.Id;
        }

        public async Task<Ship> Update(Ship ship)
        {
            Ship newShip = ships.FirstOrDefault(s => s.Id == ship.Id);
            newShip.Name = ship.Name;
            newShip.Length = ship.Length;
            newShip.Width = ship.Width;
            newShip.Description = ship.Description;
            newShip.Code = ship.Code;
            newShip.ModifiedBy = Guid.NewGuid().ToString();
            newShip.ModifiedDate = DateTime.Now;
            return newShip;
        }

        public async Task<bool> Delete(string id)
        {
            Ship deleteShip = ships.FirstOrDefault(s => s.Id == id);
            return ships.Remove(deleteShip);
        }
    }
}
