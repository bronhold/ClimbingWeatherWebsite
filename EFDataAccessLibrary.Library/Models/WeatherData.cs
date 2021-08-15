using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary.Models
{
    public class WeatherData
    {
        
        public int Id { get; set; }

        [MaxLength(20)]
        public string sort_order { get; set; }

        [MaxLength(20)]
        public string wmo { get; set; }
        
        [MaxLength(100)]
        public string name { get; set; }

        [MaxLength(20)]
        public string history_product { get; set; }

        [MaxLength(20)]
        public string local_date_time { get; set; }

        [MaxLength(20)]
        public string local_date_time_full { get; set; }

        [MaxLength(20)]
        public string aifstime_utc { get; set; }

        [MaxLength(20)]
        public string lat { get; set; }

        [MaxLength(20)]
        public string lon { get; set; }

        [MaxLength(20)]
        public string apparent_t { get; set; }

        [MaxLength(20)]
        public string cloud { get; set; }
        
        [MaxLength(20)]
        public string cloud_base_m { get; set; }
        
        [MaxLength(20)]
        public string cloud_oktas { get; set; }
        
        [MaxLength(20)]
        public string cloud_type_id { get; set; }
        
        [MaxLength(20)]
        public string cloud_type { get; set; }
        
        [MaxLength(20)]
        public string delta_t { get; set; }
        
        [MaxLength(20)]
        public string gust_kmh { get; set; }
        
        [MaxLength(20)]
        public string gust_kt { get; set; }
       
        [MaxLength(20)]
        public string air_temp { get; set; }
       
        [MaxLength(20)]
        public string dewpt { get; set; }
        
        [MaxLength(20)]
        public string press { get; set; }
        
        [MaxLength(20)]
        public string press_qnh { get; set; }
       
        [MaxLength(20)]
        public string press_msl { get; set; }
        
        [MaxLength(20)]
        public string press_tend { get; set; }
        
        [MaxLength(20)]
        public string rain_trace { get; set; }
        
        [MaxLength(20)]
        public string rel_hum { get; set; }
        
        [MaxLength(20)]
        public string sea_state { get; set; }
        
        [MaxLength(20)]
        public string swell_dir_worded { get; set; }
      
        [MaxLength(20)]
        public string swell_height { get; set; }
        
        [MaxLength(20)]
        public string swell_period { get; set; }
        
        [MaxLength(20)]
        public string vis_km { get; set; }
        
        [MaxLength(20)]
        public string weather { get; set; }

        [MaxLength(20)]
        public string wind_dir { get; set; }
        
        [MaxLength(20)]
        public string wind_spd_kmh { get; set; }
        
        [MaxLength(20)]
        public string wind_spd_kt { get; set; }




    }

    
}
