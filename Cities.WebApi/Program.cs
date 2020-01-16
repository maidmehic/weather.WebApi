using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cities.WebApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cities.WebApi
{
    public class Program
    {
        public static List<City> Cities { get; set; }
        public static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(@"Data\city.list.json");
            List<City> cities = JsonConvert.DeserializeObject<List<City>>(json);
            Cities = cities;

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
