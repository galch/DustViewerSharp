using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace DustSensorViewer
{
    class ThingSpeakClient
    {
        public static async void UpdateChannelFeed(int pm10, int pm25, int pm1)
        {
            StreamReader sr = new StreamReader("apikey.txt", System.Text.Encoding.Default);
            string api_key = sr.ReadLine();
            if (api_key.Length != 16)
            {
                Console.WriteLine("API Key length is not 16 but {0}", api_key.Length);
            }

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
            {
                { "api_key", api_key },
                { "field1", pm10.ToString() },
                { "field2", pm25.ToString() },
                { "field3", pm1.ToString() }
            };

                try
                {
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://api.thingspeak.com/update.json", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                    System.Diagnostics.Debug.WriteLine(exception);
                }
            }
        }

        public static async void UpdateChannelFeed(double pm10, double pm25)
        {
            StreamReader sr = new StreamReader("apikey.txt", System.Text.Encoding.Default);
            string api_key = sr.ReadLine();
            if(api_key.Length != 16)
            {
                Console.WriteLine("API Key length is not 16 but {0}", api_key.Length);
            }

            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "api_key", api_key },
                    { "field1", pm10.ToString("0.0") },
                    { "field2", pm25.ToString("0.0") }
                };

                try
                {
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync("https://api.thingspeak.com/update.json", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
                    System.Diagnostics.Debug.WriteLine(exception);
                }
            }
        }
    }
}