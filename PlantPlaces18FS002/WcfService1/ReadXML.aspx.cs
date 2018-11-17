using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WcfService1
{
    public partial class ReadXML : System.Web.UI.Page
    {
        // declare the variable
        private string fileName;

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
                    
                    // assign a value to the variable.
                    fileName = XMLFileUpload.FileName;
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
            // is there something in this variable, AND if so, is there more than one letter in it.
            if (fileName != null && fileName.Length > 0) { 
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                ValidateXML();
            }
        }

        public void ValidateXML()
        {
            
        }
    }
}