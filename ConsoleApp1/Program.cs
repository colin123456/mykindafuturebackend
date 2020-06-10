using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("Hello World!");

            HttpResponseMessage response =  httpClient.GetAsync("http://www.contoso.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);

            Console.WriteLine(responseBody);
        }
    }
}
