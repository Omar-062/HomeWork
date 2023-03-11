using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Models
{
    public class CarShowroom
    {
        public int Id { get; set; }
        public string? Name { get; set; } = null!;
        public virtual ICollection<Cars> Cars { get; } = new List<Cars>();
    }
}
