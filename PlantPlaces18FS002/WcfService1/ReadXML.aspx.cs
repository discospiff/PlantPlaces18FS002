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
        /// <summary>
        /// Handle uploading XML on page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // start our XML validation.
                String allowedExtension = ".xml" ;
                if (XMLFileUpload.HasFile)
                {
                    string fileName = XMLFileUpload.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();

                    // is this an allowed xml file?
                    if (fileExtension == allowedExtension)
                    {
                        // construct the path where I want to save the file.
                        String path = Server.MapPath("~/XML/");

                        // save our XML file.
                        XMLFileUpload.PostedFile.SaveAs(path + XMLFileUpload.FileName);

                        LblXMLValidation.Text = "File Uploaded";
                    } else
                    {
                        LblXMLValidation.Text = "File extension not permitted.";
                    }
                }
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