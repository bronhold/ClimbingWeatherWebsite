using ClimbingWeatherWebsite.Models;
using ClimbingWeatherWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using EFDataAccessLibrary.DataAccess;
using System.Text.Json;
using EFDataAccessLibrary.Models;
using EFDataAccessLibrary.ViewModels;

namespace EFDataAccessLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly string melbourneWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94870.json";
        private readonly string mtAlexWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94859.json";
        private readonly string grampiansWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94836.json";

        private readonly ILogger<HomeController> _logger;
        private readonly WeatherDataContext _db;

        public HomeController(ILogger<HomeController> logger,  WeatherDataContext db)
        {
            _logger = logger;
            
            _db = db;
        }


        /// <summary>
        /// Updates the WeatherDatabase with the latest observations from the BOM website
        /// then gets the latest Data for the Database to display on the website
        /// </summary>
        /// <returns>WeatherDataViewModel that contains 3 weatherdata OBJs one for each location</returns>
        public IActionResult Index(GetBomWeatherData getBomWeatherData, List<WeatherData> weatherData)
        {
  
            //GetBomWeatherData getBomWeatherData = new GetBomWeatherData();
            //List<WeatherData> weatherData = new List<WeatherData>();

            weatherData = getBomWeatherData.GetWeatherData(melbourneWeatherURL);
            UpdateDb(weatherData);

            weatherData = getBomWeatherData.GetWeatherData(mtAlexWeatherURL);
            UpdateDb(weatherData);

            weatherData = getBomWeatherData.GetWeatherData(grampiansWeatherURL);
            UpdateDb(weatherData);

            return View( GetWeatherDataFromDb() ); 
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Retrieves the most recent weatherdata OBJ for each location to be displayed on the website 
        /// </summary>
        /// <returns>weatherDataViewModel that contains a weatherdata OBJ for each location</returns>
        private WeatherDataViewModel GetWeatherDataFromDb ()
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
        private void UpdateDb(List<WeatherData> WeatherData)
        {

            try{ _db.WeatherData.FirstOrDefault(); }

            catch(Exception e)
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
