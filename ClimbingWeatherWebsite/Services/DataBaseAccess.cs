using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingWeatherWebsite.Services
{
    public class DataBaseAccess
    {
        private readonly WeatherDataContext _db;
    
        public DataBaseAccess(WeatherDataContext db)
        {
            _db = db;
        }


        /// <summary>
        /// Retrieves the most recent weatherdata OBJ for each location to be displayed on the website 
        /// </summary>
        /// <returns>weatherDataViewModel that contains a weatherdata OBJ for each location</returns>
        public WeatherDataViewModel GetWeatherDataFromDb()
        {
            WeatherDataViewModel weatherDataViewModel = new WeatherDataViewModel();
            List<WeatherData> weatherData = new List<WeatherData>();

            var dbWeatherdata = _db.WeatherData
           .OrderByDescending(x => x.local_date_time_full)
           .Where(x => x.name == "Moorabbin Airport")
           .First();
            weatherDataViewModel.weatherDataMelbourne = dbWeatherdata;

            dbWeatherdata = _db.WeatherData
            .OrderByDescending(x => x.local_date_time_full)
            .Where(x => x.name == "Redesdale")
            .First();
            weatherDataViewModel.weatherDataMountAlex = dbWeatherdata;

            dbWeatherdata = _db.WeatherData
            .OrderByDescending(x => x.local_date_time_full)
            .Where(x => x.name == "Stawell")
            .First();
            weatherDataViewModel.weatherDataGrampians = dbWeatherdata;

            return weatherDataViewModel;
        }

        /// <summary>
        /// Updates the WeatherDatabase with the weatherdata OBJs from the BOM website
        /// It checks if the entries from the BOM website are already in the database and add them if they are missing.
        /// </summary>
        /// <param name="WeatherData"></param>
        public void UpdateDb(List<WeatherData> WeatherData)
        {

            try { _db.WeatherData.FirstOrDefault(); }

            catch (Exception e)
            { }

            if (!_db.WeatherData.Where(x => x.name == WeatherData[0].name).Any())
            {
                _db.AddRange(WeatherData);
                _db.SaveChanges();
                return;
            }

            var latestWeatherData = _db.WeatherData
            .OrderByDescending(x => x.local_date_time_full)
            .Where(x => x.name == WeatherData[0].name)
            .Select(y => y.local_date_time_full)
            .First();

            int indexoflatestData = WeatherData.FindIndex(item => item.local_date_time_full == latestWeatherData);


            if (indexoflatestData == 0) { return; }   // DataBase is upto date

            if (indexoflatestData > 0)                // Part of the weather data is new starting at indexoflatestData            
            {
                _db.AddRange(WeatherData.GetRange(0, indexoflatestData));
                _db.SaveChanges();
                return;
            }

            if (indexoflatestData == -1)              // All WeatherData is new Data
            {
                _db.AddRange(WeatherData);
                _db.SaveChanges();
                return;
            }
        }

    }
}
