using ClimbingWeatherWebsite.Models;
using EFDataAccessLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingWeatherWebsite.Services
{
   
    public class GetBomWeatherData
    {
        private List<WeatherData> weatherData;
        private WeatherDataRoot BomWeatherInfo;
        private List<WeatherData> weatherDataList;

        /// <summary>
        /// This is the main method that is called to get weather data from all location:
        /// Melbourne, Mount Alexander and Grampians
        /// Gets Json weatherdata from BOM website via HTTPWebRequest and converts it into C# obj weatherdata to be store in the database
        /// </summary>
        /// <returns>List of weatherData Objs from either Melbourne, Mount Alexander or Grampians</returns>
        public List<WeatherData> GetWeatherData(string BomUrl)
        {

            //List<WeatherData> weatherData = new List<WeatherData>();

            try
            {

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(BomUrl);
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.Accept = "application/json; charset=utf-8";
                var response = (HttpWebResponse)httpWebRequest.GetResponse();
                var sr = new StreamReader(response.GetResponseStream());
                weatherData = DeserializeJson(sr);

            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e);
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine(e);
            }

            catch (System.Security.SecurityException e)
            {
                Console.WriteLine(e);
            }

            catch (UriFormatException e)
            {
                Console.WriteLine(e);
            }


            return weatherData;
        }
        

        /// <summary>
        /// Converts a stream reader that contains a json weather obj to WeatherDataRoot C# obj and returns the list of weatherdata obj that is inside the WeatherDataRoot
        /// </summary>
        /// <param name="sr"></param>
        /// <returns>returns the list of weatherdata obj</returns>
        
        private List<WeatherData> DeserializeJson(StreamReader sr)
        {
            //WeatherDataRoot BomWeatherInfo;

            using (sr)
            {
                string json = sr.ReadToEnd();
                BomWeatherInfo = JsonConvert.DeserializeObject<WeatherDataRoot>(json);

            }

            //List<WeatherData> weatherDataList = new List<WeatherData>(BomWeatherInfo.observations.weatherData);
            weatherDataList = BomWeatherInfo.observations.weatherData; 
            return weatherDataList;
        }



    }
}
