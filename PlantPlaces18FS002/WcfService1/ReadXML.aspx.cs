using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class ReadXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // start our XML validation.
                String[] allowedExtensions = { ".xml" };
                string fileName =  XMLFileUpload.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            ValidateXML();
        }

        public void ValidateXML()
        {
            LblXMLValidation.Text = "Looking good!";
        }
    }
}