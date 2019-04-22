using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recycling_4._0
{
    public partial class Main : Page
    {
        public List<UploadingXML> uploadedXMLs = new List<UploadingXML>();
        protected HttpPostedFile tempXML;
        protected User tempUser;
        protected int tempCostForXML;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsCallback)
            {
            
                //inittialisiere Label
                Label label1 = new Label();
                label1.ID = "Label1";
                label1.Text = "Hochzuladnede Datei:";
                label1.Visible = true;
                Label1.Controls.Add(label1);

                //inittialisiere Fileuploade
                FileUpload fileupload = new FileUpload();
                fileupload.ID = "FileUpload1";
                fileupload.Visible = true;
                FileUpload1.Controls.Add(fileupload);

                //inittialisiere Label
                Label label2 = new Label();
                label2.ID = "Label2";
                label2.Text = "Festgelegter Preis für den Verkauf";
                label2.Visible = true;
                Label2.Controls.Add(label2);

                //intitalise TextBox 
                TextBox textbox = new TextBox();
                textbox.ID = "TextBox1";
                textbox.Visible = true;
                TextBox1.Controls.Add(textbox);
                

                //intitalise Button 
                Button button = new Button();
                button.ID = "Button1";
                button.Visible = true;
                Button1.Controls.Add(button);
                
            }
            
            //TODO
            
            //Ruft Wert von der Textbox auf und wandelt diese in in int um
            Int32.TryParse(TextBox1.Text, out tempCostForXML);


            //Ruft UploadeDatei von der Fileuploade auf und wandelt diese in in LocalDataStoreSlot um
            tempXML = FileUpload1.PostedFile;
        }

        protected void addNewXML(object sender, EventArgs e)
        {
                        uploadedXMLs.Add(new UploadingXML(tempXML, tempUser, tempCostForXML));
        }
    }
}