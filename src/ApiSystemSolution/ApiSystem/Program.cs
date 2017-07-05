using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiSystem
{
    class Program
    {
        static string seed;

        static void Main(string[] args)
        {
            var page = new Uri("http://challenge-server.code-check.io/api/recursive/ask");
            string jsonString;

            string[] tabtest = { "b0c2b89f-4862-4814-8728-ddb0b36076b4", "4" };

            int result;

            if (args.Length == 0)
            {
                seed = tabtest[0];
                    if (int.Parse(tabtest[1]) == 0)
                    {
                        result = 1;
                    }

                    if (int.Parse(tabtest[1]) == 2)
                    {
                        result = 2;
                    }

                    else
                    {
                        result = recursive(int.Parse(tabtest[1]));
                    }
                    /*
                    else
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.QueryString.Add("n", args[1]);
                            client.QueryString.Add("seed", args[0]);
                            client.Encoding = Encoding.UTF8;
                            jsonString = client.DownloadString(page);
                        }
                        dynamic json = JsonConvert.DeserializeObject(jsonString);
                        result = json.result;
                    }*/
                    Console.WriteLine(result);
                /*
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                    {
                        var resp = (HttpWebResponse)ex.Response;
                        if (resp.StatusCode == HttpStatusCode.BadRequest) // HTTP 400
                        {
                            Console.WriteLine(HttpStatusCode.BadRequest);
                        }

                    }
                }*/
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("BadRequest, missing argument");
            }
            Console.ReadKey();

        }

        static int recursive(int n)
        {
            if (n == 0)
                return 1;

            if (n == 2)
                return 2;

            if (n % 2 == 0)
                return recursive(n - 1) + recursive(n - 2) + recursive(n - 3) + recursive(n - 4);
            else
            {
                var page = new Uri("http://challenge-server.code-check.io/api/recursive/ask");
                string jsonString;

                using (WebClient client = new WebClient())
                {
                    client.QueryString.Add("n", n.ToString());
                    client.QueryString.Add("seed", seed);
                    client.Encoding = Encoding.UTF8;
                    jsonString = client.DownloadString(page);
                }
                dynamic json = JsonConvert.DeserializeObject(jsonString);
                return json.result;
            }
        }
    }
}
