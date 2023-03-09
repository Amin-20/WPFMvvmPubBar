using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMvvmPubBar.Models
{
    public class Beer : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public string ImagePath { get; set; }
    }
}
