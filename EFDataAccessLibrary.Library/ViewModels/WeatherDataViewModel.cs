using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;

namespace EFDataAccessLibrary.ViewModels
{
    public class WeatherDataViewModel
    {
        public WeatherData weatherDataMelbourne { get; set; }
        public WeatherData weatherDataMountAlex { get; set; }
        public WeatherData weatherDataGrampians { get; set; }

    }
}
