using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeRest2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Making a request to the internet
            var client = new HttpClient();

            //requesting API quotes from the Kanye and Ron URI's.
            var kanyeUri = "https://api.kanye.rest";
            var ron = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            //ForLoop string 5 conversations between Kanye and Ron.            
            for (int i = 0; i < 5; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeUri).Result;
                var ronResponse = client.GetStringAsync(ron).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                Console.WriteLine($" Kanye: {kanyeQuote}");
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                Console.WriteLine($" Ron: {ronQuote}");
                Console.WriteLine();
            }
            
            

        }
    }
}
