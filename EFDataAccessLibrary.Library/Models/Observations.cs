using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class observations
    {


        [JsonProperty("notice")]
        public List<WeatherNotice> weatherNotice { get; set; }
        [JsonProperty("header")]
        public List<WeatherHeader> weatherHeader { get; set; }
        [JsonProperty("data")]
        public List<WeatherData> weatherData { get; set; }
    }
}
