using ClimbingWeatherWebsite.Models;
using ClimbingWeatherWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EFDataAccessLibrary.Models;



namespace EFDataAccessLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly string melbourneWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94870.json";
        private readonly string mtAlexWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94859.json";
        private readonly string grampiansWeatherURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94836.json";

        private readonly ILogger<HomeController> _logger;
        private readonly GetBomWeatherData _getBomWeatherData;
        private readonly DataBaseAccess _dataBaseAccess;

        public HomeController(ILogger<HomeController> logger, GetBomWeatherData getBomWeatherData, DataBaseAccess dataBaseAccess )
        {
            _logger = logger;
            _getBomWeatherData = getBomWeatherData;
            _dataBaseAccess = dataBaseAccess;
        }


        /// <summary>
        /// Updates the WeatherDatabase with the latest observations from the BOM website
        /// then gets the latest Data for the Database to display on the website
        /// </summary>
        /// <returns>WeatherDataViewModel that contains 3 weatherdata OBJs one for each location</returns>
        public IActionResult Index()
        {
  
            List<WeatherData> weatherData = new List<WeatherData>();

            weatherData = _getBomWeatherData.GetWeatherData(melbourneWeatherURL);
            _dataBaseAccess.UpdateDb(weatherData);

            weatherData = _getBomWeatherData.GetWeatherData(mtAlexWeatherURL);
            _dataBaseAccess.UpdateDb(weatherData);

            weatherData = _getBomWeatherData.GetWeatherData(grampiansWeatherURL);
            _dataBaseAccess.UpdateDb(weatherData);

            return View(_dataBaseAccess.GetWeatherDataFromDb() ); 
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult WhoAmI()
        { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
