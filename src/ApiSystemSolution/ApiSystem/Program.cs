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
        static void Main(string[] args)
        {
            var page = new Uri("http://challenge-server.code-check.io/api/recursive/ask");
            string jsonString;

            //string[] tabtest = { "b0c2b89f-4862-4814-8728-ddb0b36076ba", "6" };

            int result;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string output = String.Format("args[{0}]: {0}", i, args[i]);
                    Console.WriteLine(output);
                }

                if (int.Parse(args[1]) == 0)
                {

                }

                if (int.Parse(args[1]) == 2)
                {

                }

                if (int.Parse(args[1]) % 2 == 0)
                {
                    result = recursive(int.Parse(args[1]));
                }

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
                }
                Console.WriteLine(result);
            }
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
            }
            Console.ReadKey();
        }

        static int recursive(int n)
        {
            if (n <= 0)
                return n - 1;

            else
                return n - 1 + recursive(n - 1);
        }
    }
}
