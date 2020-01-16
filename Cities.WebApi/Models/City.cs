﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cities.WebApi.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public Coordinates coord { get; set; }
    }
}
