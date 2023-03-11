using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Models
{
    public class Cars
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int CarShowroomId { get; set; }
        public virtual CarShowroom CarShowroom { get; set; } = null!;
    }
}
