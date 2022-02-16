using System.ComponentModel.DataAnnotations;

namespace Task.ShipManagement.Model
{
    public class Ship : BaseObject
    {   
        [Required]
        //Ship must have a name(string)
        public string Name { get; set; }
        
        [Required]
        //Ship must have a length(in metres)
        public int Length { get; set; } 
        
        [Required]
        //Ship must have a width(in metres)
        public int Width { get; set; }

        //Ship must have a code(a string with a format of AAAA-1111-A1 where A is any character from the Latin alphabet and 1 is a number from 0 to 9)
        [Required]
        public string Code { get; set; }

        //Ship can have description
        public string Description { get; set; }
    }
}
