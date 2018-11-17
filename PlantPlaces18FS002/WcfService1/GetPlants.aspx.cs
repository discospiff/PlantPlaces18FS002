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
    public partial class GetPlants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnReadJSON_Click(object sender, EventArgs e)
        {
            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("http://www.plantplaces.com/perl/mobile/viewplantsjson.pl?Combined_Name=Oak");

                PlantCollection plantCollection = JsonConvert.DeserializeObject<PlantCollection>(rawData);
                int i = 1 + 1;
            }
        }
    }
}