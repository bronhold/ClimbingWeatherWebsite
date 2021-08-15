using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ClimbingWeatherWebsite.Services
{
    public class FormatWeatherData
    {
        /// <summary>
        /// Converts a WeatherData obj into a list of strings 
        /// </summary>
        /// <param name="weatherDatas"></param>
        /// <returns>list of strings containing information from weatherData object</returns>
        /// 
        public List<string> getweatherstringdata(WeatherData weatherDatas)
        {
            List<string> weatherdatastringlist = new List<string>(new string[] 
            {
            weatherDatas.name,
            weatherDatas.local_date_time,
            weatherDatas.local_date_time_full,
            weatherDatas.apparent_t,
            weatherDatas.air_temp,
            weatherDatas.dewpt,
            weatherDatas.press,
            weatherDatas.rain_trace,
            weatherDatas.rel_hum,
            weatherDatas.wind_dir,
            weatherDatas.wind_spd_kmh       
            });

            return weatherdatastringlist;
        }


        /// <summary>
        /// Converts a list of weatherdata Objs to Json Objs
        /// </summary>
        /// <param name="weatherDataArray"></param>
        /// <returns>a list of JSON WeatherData Objs</returns>
        public string SerializeObjtoJson(List<WeatherData> weatherDataArray)
        {
            return JsonConvert.SerializeObject(weatherDataArray);
        }
    }
}

