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
            //string[] tabtest = { "b0c2b89f-4862-4814-8728-ddb0b36076b4", "4" };
            int result;

            if (args.Length == 2)
            {
                seed = args[0];
                if (int.Parse(args[1]) == 0)
                {
                    result = 1;
                }

                if (int.Parse(args[1]) == 2)
                {
                    result = 2;
                }

                else
                {
                    result = recursive(int.Parse(args[1]));
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("BadRequest, missing argument");
            }
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
