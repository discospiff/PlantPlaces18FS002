using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;

namespace WcfService1
{
    public partial class ReadXML : System.Web.UI.Page
    {
        // declare the variable
        private string fullFilePath;

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
                    String fileName = XMLFileUpload.FileName;
                    string fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
                    

                    // is this an allowed xml file?
                    if (fileExtension == allowedExtension)
                    {
                        // construct the path where I want to save the file.
                        String path = Server.MapPath("~/XML/");
                        fullFilePath = path + fileName;

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
            if (fullFilePath != null && fullFilePath.Length > 0) { 
                XmlDocument doc = new XmlDocument();
                doc.Load(fullFilePath);
                
                ValidateXML();
                XmlNode node = doc.SelectSingleNode("/plants/specimens/specimen[latitude>0]");
                String data = node.ToString();
            }
        }

        public void ValidateXML()
        {
            // settings for how we read XML.
            XmlReaderSettings settings = new XmlReaderSettings();

            // tell it how we want to validate.
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= 
                System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |=
                System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;

            // Wire our validator up to a method that it can call if validation fails. 
            settings.ValidationEventHandler += 
                new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandle);
            
            // read and validate the document.
            XmlReader xmlReader = XmlReader.Create(fullFilePath, settings);

            try
            {
                // read the file one line at a time, and validate.
                while (xmlReader.Read())
                {

                }
                LblXMLValidation.Text = "Validation passed";
            }catch (Exception e)
            {
                LblXMLValidation.Text = "Validation Failed.  message: " + e.Message;
            }
        }

        /// <summary>
        /// This method will be invoked by the .net Framework ONLY if validation fails.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ValidationEventHandle(object sender, ValidationEventArgs args)
        {
            Console.WriteLine("Validation error: " + args.Message);
            LblXMLValidation.Text = "Validation Failed.  message: " + args.Message;
            // something went wrong.  Let's stop working.
            throw new Exception("Validation Failed.  message: " + args.Message);
        }
    }
}