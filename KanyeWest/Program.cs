using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            //var dothrakiURL = "https://api.funtranslations.com/translate/dothraki.json";

            // Next, we send a GET request to the specified Uri and return the response body as a string in an asynchronous operation.
            //Basically, we get a string of JSON back
            int i = 0;
            while (i < 5)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var ronResponse = client.GetStringAsync(ronURL).Result;

                

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($"{kanyeQuote} \n{ronQuote}\n");
                i++;
            }

            //var dothrakiResponse = client.GetStringAsync(dothrakiURL).Result;
            //var dothrakiTranslate = client.PostAsync(dothrakiURL, "text = You Dog!");





        }
    }
}
