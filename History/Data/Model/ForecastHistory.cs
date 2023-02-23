using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace History.Data.Model
{
    public class ForecastHistory
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
        public string CityName { get; set; }
        public float Temp { get; set; }
        public float Humidity { get; set; }
        public float FeelsLike { get; set; }
        public float WindSpeed { get; set; }
        public float Pressure { get; set; }
    }
}
