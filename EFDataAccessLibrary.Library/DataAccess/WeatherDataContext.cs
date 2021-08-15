using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess
{
    public class WeatherDataContext : DbContext
    {
        public WeatherDataContext(DbContextOptions options) : base(options) { }

        public DbSet<WeatherData> WeatherData{ get; set; }

    }
}
