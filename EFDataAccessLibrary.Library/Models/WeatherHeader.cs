using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class WeatherHeader
    {
        public string refresh_message { get; set; }
        public string ID { get; set; }
        public string main_ID { get; set; }
        public string name { get; set; }
        public string state_time_zone { get; set; }
        public string time_zone { get; set; }
        public string product_name { get; set; }
        public string state { get; set; }

    }
}
