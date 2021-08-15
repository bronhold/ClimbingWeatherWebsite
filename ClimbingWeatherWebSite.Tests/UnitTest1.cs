using ClimbingWeatherWebsite.Models;
using ClimbingWeatherWebsite.Services;
using EFDataAccessLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ClimbingWeatherWebSite.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           // JsonDeserialization jsonDeserialization = new JsonDeserialization();

          //  StreamReader sr;
           // JsonDeserialization(sr);


        }

        [TestMethod]
        public void TestMethod2()
        {
            FormatWeatherData formatWeatherData = new FormatWeatherData();
            WeatherData weatherData = new WeatherData();
            weatherData.name = "Bron";
           
            var output =  formatWeatherData.getweatherstringdata(weatherData);

            Assert.AreEqual(output.Count, 11);
            Assert.AreEqual(output[0], "Bron");

        }
    }
}
