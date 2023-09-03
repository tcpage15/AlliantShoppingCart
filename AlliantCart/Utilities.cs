﻿using AlliantCart.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlliantCart
{
    public class Utilities
    {
        const string jsonFilePath = @"Model\productMenu.json";

        public List<Product>? GetProductListFromMenu()
        {
            string? path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                jsonFilePath);
            //string? path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            //    @"C:\Users\tcpag\source\repos\AlliantShoppingCart\AlliantShoppingCart\bin\Debug\net7.0\Model\ProductMenu.json");
            string productJSON = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Product>>(productJSON);
        }
    }
}