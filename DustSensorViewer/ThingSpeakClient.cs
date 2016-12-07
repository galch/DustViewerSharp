using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DustSensorViewer
{
    class ThingSpeakClient
    {
        const string my_api_key = "2HJQLSHH3ZG3UGZW";

        public static async void UpdateChannelFeed(int pm10, int pm25, int pm1)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "api_key", my_api_key },
                   { "field1", pm10.ToString() },
                   { "field2", pm25.ToString() },
                   { "field3", pm1.ToString() }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api.thingspeak.com/update.json", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        public static async void UpdateChannelFeed(double pm10, double pm25)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "api_key", my_api_key },
                   { "field1", pm10.ToString("0.0") },
                   { "field2", pm25.ToString("0.0") }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://api.thingspeak.com/update.json", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
