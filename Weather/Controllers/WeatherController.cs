using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiWeatherApi.DarkSky;
using MultiWeatherApi.DarkSky.Model;
using RestSharp;

namespace Weather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public IActionResult GetData(string city)
        {
            
            return new ObjectResult(GetWeather(city).Content);
        }

        private RestResponse GetWeather(string input)
        {
            var client = new RestClient("https://api.weatherbit.io/v2.0/current");
            var request = new RestRequest("https://api.weatherbit.io/v2.0/current?city=" + input +"&key=5b55ca0f45cb43ae91293721e24e2060&include=hourly");
            return client.Execute(request);
        }
    }
}