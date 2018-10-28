using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_WebAPI_Weather.ConsoleUtilities;
using Demo_WebAPI_Weather.DataAccessLayer;
using Demo_WebAPI_Weather.BusinessLayer;
using RestSharp;

namespace Demo_WebAPI_Weather.PresentationLayer
{
    class Presenter
    {
        BusinessLogic _businessLogic;
        IRestApiClient _restApiClient;
        WeatherData _weatherData;

        public Presenter(BusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            InitializeConsoleWindow();
            RunApplicationLoop();
        }

        private void RunApplicationLoop()
        {
            DisplayWelcomeScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        private void DisplayMainMenu()
        {
            bool runApp = true;

            do
            {
                DisplayHeader("\t\tMain Menu");
                Console.WriteLine("");
                Console.WriteLine("\tA. Choose Rest API Client");
                Console.WriteLine("\tB. Get Weather by Longitude and Latitude");
                Console.WriteLine("\tC. ");
                Console.WriteLine("\tD. ");
                Console.WriteLine("\tE. ");
                Console.WriteLine("\tF. ");
                Console.WriteLine("\tQ. Quit");
                Console.WriteLine();
                Console.Write("\tEnter Menu Choice:");
                switch (Console.ReadLine().ToLower())
                {
                    case "a":
                        _restApiClient = DisplayChooseRestApiClient();
                        break;
                    case "b":
                        _weatherData = DisplayGetWeatherByLonLat();
                        break;
                    case "c":

                        break;
                    case "d":

                        break;
                    case "e":

                        break;
                    case "f":

                        break;
                    case "q":
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("Please make a selection A-F or Q.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (runApp);

        }

        private WeatherData DisplayGetWeatherByLonLat()
        {
            WeatherData weatherData;
            double lon, lat;

            DisplayHeader("Weather by Longitude and latitude");

            do
            {
                Console.Write("Enter Longitude:");
            } while (!double.TryParse(Console.ReadLine(), out lon));
            do
            {
                Console.Write("Enter latitude:");
            } while (!double.TryParse(Console.ReadLine(), out lat));
            
            weatherData = _businessLogic.GetWeatherByLonLat(lon, lat);

            Console.WriteLine($"Weather data for Longitude:{lon:0.##} and Latitude:{lat:0.##} acquired.");

            DisplayContinuePrompt();

            return weatherData;
        }

        private WeatherData DisplayGetWeatherByZipCode()
        {
            WeatherData weatherData;
            int zipCode;

            DisplayHeader("Weather by Zip Code");

            do
            {
                Console.Write("Enter Zip Code:");
            } while (!int.TryParse(Console.ReadLine(), out zipCode));

            weatherData = _businessLogic.GetWeatherByZipCode(zipCode);

            Console.WriteLine($"Weather data for Zip Code:{zipCode} acquired.");

            DisplayContinuePrompt();

            return weatherData;
        }

        private IRestApiClient DisplayChooseRestApiClient()
        {
            IRestApiClient restApiClient = null;

            DisplayHeader("Choose Rest API Client");

            Console.WriteLine("Choosing Sync Client");
            restApiClient = new RestApiClientSync();

            DisplayContinuePrompt();

            return restApiClient;
        }


        //static WeatherData GetWeatherByLonLat()
        //{
        //    var restClient = new RestClient();
        //    restClient.BaseUrl = new Uri(ApiAccess.OPEN_WEATHER_MAP_KEY);

        //    var request = new RestRequest("weather", Method.GET);
        //    request.AddParameter("appid", "864d252afc928abff4010abe732617a1");
        //    request.AddParameter("lon", "-86");
        //    request.AddParameter("lat", "45");

        //    RestApiClientSync syncRestClient = new RestApiClientSync();
        //    WeatherData weatherData = syncRestClient.ExecuteRequest(restClient, request);

        //    return weatherData;
        //}

        /// <summary>
        /// initialize console configuration
        /// </summary>
        private void InitializeConsoleWindow()
        {
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
        }

        /// <summary>
        /// Display the Closing Screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tDemo Provided by NMC CIT Department");


            DisplayContinuePrompt();
        }

        /// <summary>
        /// Display the Welcome Screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tWeather Web API Demo");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        #region HEDPER METHODS

        /// <summary>
        /// display a screen header
        /// </summary>
        /// <param name="headerText">header content</param>
        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine();
        }

        /// <summary>
        /// display a continue prompt w/ ReadKey()
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        #endregion
    }
}
