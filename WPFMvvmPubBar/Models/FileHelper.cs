using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WPFMvvmPubBar.Models;

namespace WPFMvvmPubBar
{
    public class FileHelper
    {
        public static void Write(List<Sales> beers)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"Sales.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, beers);
                }
            }
        }

        public static List<Sales> Read(string fileName)
        {
            List<Sales> beers = new List<Sales>();
            var context = File.ReadAllText(fileName);
            beers = JsonConvert.DeserializeObject<List<Sales>>(context);
            return beers;
        }
    }
}