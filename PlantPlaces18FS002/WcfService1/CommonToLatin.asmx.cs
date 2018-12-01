using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace WcfService1
{
    /// <summary>
    /// Summary description for CommonToLatin
    /// </summary>
    [WebService(Namespace = "http://www.planptlaces.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommonToLatin : System.Web.Services.WebService
    {

        /// <summary>
        /// For a common name, return the most frequent genus.
        /// </summary>
        /// <param name="commonName"></param>
        /// <returns></returns>
        [WebMethod]
        public string ConvertCommonToGenus(string commonName)
        {
            string genus = "unknown";
            PlantCollection plantCollection;

            using (var webClient = new WebClient())
            {
                string rawData = webClient.DownloadString("http://www.plantplaces.com/perl/mobile/viewplantsjson.pl?Combined_Name=" + commonName);
                
                plantCollection = JsonConvert.DeserializeObject<PlantCollection>(rawData);
                
            }

            // maintain a count of frequency of genus
            IDictionary<string, int> generaCount = new Dictionary<string, int>();
            List<Plant> allPlants = plantCollection.Plants;
            foreach (Plant plant in allPlants)
            {
                if(generaCount.ContainsKey(plant.Genus))
                {
                    // does exist; increase count.
                    int currentCount = generaCount[plant.Genus];
                    // increase by one.
                    currentCount++;
                    // store new value
                    generaCount[plant.Genus] = currentCount;
                }
                else
                {
                    // does not exist, need to create
                    generaCount[plant.Genus] = 1;
                }
            }

            // at this point, we have the count of genera.  Now, find the highest.

            // the current count.
            int highWaterMark = 0;

            // find the most common genus
            foreach(String iterGenus in generaCount.Keys)
            {
                // retreive the count associated with this genus
                int currentFrequency = generaCount[iterGenus];

                // are you a bigger number than the last biggest number I knew?
                if (currentFrequency > highWaterMark)
                {
                    // you're my new candidate!
                    genus = iterGenus;
                    highWaterMark = currentFrequency;

                }
            }

            return genus;
        }
    }
}
