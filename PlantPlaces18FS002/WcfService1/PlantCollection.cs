﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class PlantCollection
    {
        private List<Plant> plants;

        public List<Plant> Plants { get => plants; set => plants = value; }
    }
}