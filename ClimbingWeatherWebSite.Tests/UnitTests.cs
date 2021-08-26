using ClimbingWeatherWebsite.Models;
using ClimbingWeatherWebsite.Services;
using EFDataAccessLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ClimbingWeatherWebSite.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestgetBomWeatherData()
        {
            string bomURL = @"http://www.bom.gov.au/fwo/IDV60801/IDV60801.94870.json";
            GetBomWeatherData getBomWeatherData = new GetBomWeatherData();
            
            List<WeatherData> weatherData = getBomWeatherData.GetWeatherData(bomURL);
            
            Assert.AreEqual(weatherData[0].name, "Moorabbin Airport");
            Assert.AreEqual(weatherData[0].sort_order, "0");
            Assert.AreEqual(weatherData[4].sort_order, "4");

        }

        [TestMethod]
        public void Testgetweatherstringdata()
        {
            FormatWeatherData formatWeatherData = new FormatWeatherData();
            WeatherData weatherData = new WeatherData();
            weatherData.name = "Melbourne";
            weatherData.local_date_time_full = "202108260912";
            weatherData.apparent_t = "7.1";
            weatherData.press = "1000";
            weatherData.wind_spd_kmh = "100";
            

            var output =  formatWeatherData.getweatherstringdata(weatherData);

            Assert.AreEqual(output.Count, 11);
            Assert.AreEqual(output[0], "Melbourne");
            Assert.AreEqual(output[2], "202108260912");
            Assert.AreEqual(output[3], "7.1");
            Assert.AreEqual(output[6], "1000");
            Assert.AreEqual(output[10], "100");
            


        }
    }
}
