using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class AutoCompletePlantNames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            // throw away anything it wants to post alread
            Response.Clear();

            // change the content type, so the browser knows what it is getting
            Response.ContentType = "application/json; charset=utf-8";

            // my list of autocomplete suggestions
            List<string> plantNames = new List<string>();
            plantNames.Add("White Oak");
            plantNames.Add("Red Oak");
            plantNames.Add("White Pine");
            plantNames.Add("Red Maple");
            plantNames.Add("Burr Oak");
            plantNames.Add("Pin Oak");
            plantNames.Add("Swamp White Oak");



            // convert to JSON stream.
            string plantJSON = JsonConvert.SerializeObject(plantNames);

            // print our JSON stream out.
            Response.Write(plantJSON);

            // we're all done!
            Response.End();
        }

    }
}