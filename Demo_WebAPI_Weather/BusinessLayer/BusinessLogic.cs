using Demo_WebAPI_Weather.DataAccessLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_WebAPI_Weather.BusinessLayer
{
    public class BusinessLogic
    {
        /// <summary>
        /// get weather data using longitude and latitude
        /// </summary>
        /// <param name="lon">longitude</param>
        /// <param name="lat">latitude</param>
        /// <returns>weather data</returns>
        public WeatherData GetWeatherByLonLat(double lon, double lat)
        {
            var restClient = new RestClient();
            restClient.BaseUrl = new Uri(ApiAccess.OPEN_WEATHER_MAP_BASE_URL);

            var request = new RestRequest("weather", Method.GET);
            request.AddParameter("appid", ApiAccess.OPEN_WEATHER_MAP_KEY);
            request.AddParameter("lon", lon);
            request.AddParameter("lat", lat);

            RestApiClientSync syncRestClient = new RestApiClientSync();
            WeatherData weatherData = syncRestClient.ExecuteRequest(restClient, request);

            return weatherData;
        }

    }
}
