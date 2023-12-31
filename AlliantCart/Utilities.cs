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

        /// <summary>
        /// Get the JSON product data and serialize it into a collection of Products
        /// </summary>
        /// <returns></returns>
        public List<Product>? GetProductListFromMenu()
        {
            string? path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                jsonFilePath);
            string productJSON = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<Product>>(productJSON);
        }
    }
}
