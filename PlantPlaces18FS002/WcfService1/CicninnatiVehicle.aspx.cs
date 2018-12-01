using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class CicninnatiVehicle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("https://data.cincinnati-oh.gov/resource/w2ka-rfbi.json");

                List<Vehicle> allVehicles = JsonConvert.DeserializeObject < List < Vehicle>>(rawData);

                // the data the user entered into the field.
                String odometer = TxtOdometer.Text;
                int intOdometer = Convert.ToInt32(odometer);

                List<Vehicle> mileageVehicles = new List<Vehicle>();

                foreach(Vehicle vehicle in allVehicles)
                {
                    if (vehicle.Odometer > intOdometer)
                    {
                        mileageVehicles.Add(vehicle);
                    }
                }
                LblCount.Text = Convert.ToString(mileageVehicles.Count);
            }
        }
    }
}