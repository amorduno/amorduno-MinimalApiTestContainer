﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo.Tests.Helper
{
    internal class HttpHelper
    {
        public static StringContent GetJsonHttpContent(object items)
        {
            return new StringContent(JsonConvert.SerializeObject(items), Encoding.UTF8, "application/json");
        }

        internal static class Urls
        {
            public readonly static string GetPersonas = "/GetPersonas";
            public readonly static string GetPersona = "/GetPersona";
            public readonly static string AddPersona = "/AddPersona";
            public readonly static string UpdatePersona = "/UpdatePersona";
        }
    }
}
