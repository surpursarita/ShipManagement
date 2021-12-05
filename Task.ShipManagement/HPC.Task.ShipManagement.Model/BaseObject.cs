using System;

namespace HPC.Task.ShipManagement.Model
{
    public class BaseObject
    {        
        public string Id { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public String ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
