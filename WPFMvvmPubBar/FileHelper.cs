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
        public static void Write(Beer beer)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{beer.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, beer);
                }
            }
        }

        public static Beer Read(string fileName)
        {
            Beer beer = new Beer();
            var context = File.ReadAllText(fileName);
            beer = JsonConvert.DeserializeObject<Beer>(context);
            return beer;
        }
    }
}