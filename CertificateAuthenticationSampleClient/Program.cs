using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace CertificateAuthenticationSampleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await SendRequest();
            Console.ReadKey();
        }

        static async Task SendRequest()
        {

            try
            {
                var cert = new X509Certificate2(Path.Combine(Environment.CurrentDirectory, "client.pfx"), "test");
                var handler = new HttpClientHandler();
                handler.ClientCertificates.Add(cert);
                var client = new HttpClient(handler);

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://localhost:5001/WeatherForecast"),
                    Method = HttpMethod.Get,
                };

                var response = await client.SendAsync(request);

                Console.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
