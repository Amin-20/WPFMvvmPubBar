﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMvvmPubBar.Models
{
    public class Beer : Entity
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string ImagePath { get; set; }
    }
}
