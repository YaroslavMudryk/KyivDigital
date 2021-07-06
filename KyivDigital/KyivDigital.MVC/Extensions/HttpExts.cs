﻿using System;
using System.Net.Http;
namespace KyivDigital.MVC.Extensions
{
    public static class HttpExts
    {
        public static void InitializationKyivDigitalClient(this HttpClient client)
        {
            client.BaseAddress = new Uri("https://kyiv.digital");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-Client-Version", "1.1.1");
            client.DefaultRequestHeaders.Add("X-Client-Platform", "0");
        }
    }
}