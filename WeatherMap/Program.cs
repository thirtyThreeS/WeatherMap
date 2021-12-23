using Newtonsoft.Json;

namespace WeatherMap
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetTodoItems();
        }

        private async Task GetTodoItems()
        {
            string response = await client.GetStringAsync(   //specified city of Detroit in URL below
                "https://api.openweathermap.org/data/2.5/weather?q=Detroit&units=imperial&appid=b011385b35af79f839561b76b94c9a08");
                                                                    //^           ^Fahrenheit units=imperial
            GetWeather getWeather = JsonConvert.DeserializeObject<GetWeather>(response);

            Console.WriteLine($"The current tempature of Detroit is {getWeather.main.temp}°F " +
                $"but it feels like {getWeather.main.feels_like}°F.. The minimum temp of this 24 hour period " +
                $"could be {getWeather.main.temp_min}°F but we could also see it get as warm as " +
                $"{getWeather.main.temp_max}°F..\nCurrent Pressure: {getWeather.main.pressure}.\nCurrent Humidity: " +
                $"{getWeather.main.humidity}.");
        }
    }
}