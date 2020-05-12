using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MathFanBoy
{
    class Program
    {
        static string[] endpoints = null;
        static string[] operations = new string[5] { "addition", "division", "multiplication", "substraction", "percentage" };
        
        static async Task Main(string[] args)
        {
#if DEBUG
            endpoints = new string[5] {
                "http://localhost:5001/addition",
                "http://localhost:5002/division",
                "http://localhost:5003/multiplication",
                "http://localhost:5004/substraction",
                "http://localhost:5005/percentage"};
#else
            endpoints = new string[5] {
                Environment.GetEnvironmentVariable("AdditionEndpoint"),
                Environment.GetEnvironmentVariable("DivisionEndpoint"),
                Environment.GetEnvironmentVariable("MultiplicationEndpoint"),
                Environment.GetEnvironmentVariable("SubstractionEndpoint"),
                Environment.GetEnvironmentVariable("PercentageEndpoint")};
#endif
            Console.WriteLine("available endpoints");
            foreach (string endpoint in endpoints)
            {
                Console.WriteLine(endpoint);
            }
            while (true)
            {
                try
                {
                    Thread.Sleep(20);
                    var position = new Random().Next(0, 5);
                   
                    Console.WriteLine("Attempting {0} {1}", operations[position],
                       // await Calculate(4, new Random().Next(0,5), endpoints[position]));
                       await Calculate(4, new Random().Next(0, 5), endpoints[4]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        static async Task<string> Calculate(int op1, int op2, string endpoint)
        {
            using (HttpClient cli = new HttpClient())
            {
                
                return (await cli.PostAsync(
                    endpoint, new StringContent(JsonConvert.SerializeObject(
                    new OperationParameters
                    {
                        op1 = op1,
                        op2 = op2
                    }), Encoding.UTF8, "application/json"))).Content.ReadAsStringAsync().Result;

            }
        }

    }
    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
