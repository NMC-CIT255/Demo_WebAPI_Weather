using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_WebAPI_Weather.DataAccessLayer;
using RestSharp;

namespace Demo_WebAPI_Weather
{
    class Program
    {
        static void Main(string[] args)
        {

            WeatherData weatherData = GetWeatherByLonLat();
        }

        static WeatherData GetWeatherByLonLat()
        {
            var restClient = new RestClient();
            restClient.BaseUrl = new Uri("http://api.openweathermap.org/data/2.5/");

            var request = new RestRequest("weather", Method.GET);
            request.AddParameter("appid", "864d252afc928abff4010abe732617a1");
            request.AddParameter("lon", "-86");
            request.AddParameter("lat", "45");

            RestApiClientSync syncRestClient = new RestApiClientSync();
            WeatherData weatherData = syncRestClient.ExecuteRequest(restClient, request);

            return weatherData;
        }


        /// <summary>
        /// Display the Closing Screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tBye!");


            DisplayContinuePrompt();
        }

        /// <summary>
        /// Display the Welcome Screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tWelcome!");
            Console.ReadLine();

            DisplayContinuePrompt();
        }

        #region HEDPER METHODS
        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
