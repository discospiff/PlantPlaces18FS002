using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class Vehicle
    {
        private int asset;
        private string latitude;
        private string longitude;
        private decimal odometer;
        private string status;
        private string speed;
        private string time;

        public int Asset { get => asset; set => asset = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public decimal Odometer { get => odometer; set => odometer = value; }
        public string Status { get => status; set => status = value; }
        public string Speed { get => speed; set => speed = value; }
        public string Time { get => time; set => time = value; }
    }
}