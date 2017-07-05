﻿using Newtonsoft.Json;
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

            using (WebClient client = new WebClient())
            {
                client.QueryString.Add("n", args[1]);
                client.QueryString.Add("seed", args[0]);
                client.Encoding = Encoding.UTF8;
                jsonString = client.DownloadString(page);
            }

            dynamic result = JsonConvert.DeserializeObject(jsonString);
            Console.WriteLine(result.result);
        }
    }
}
