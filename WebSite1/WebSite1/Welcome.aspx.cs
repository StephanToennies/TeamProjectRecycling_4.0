using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Welcome : System.Web.UI.Page
{
    public List<UploadingXML> uploadedXMLs = new List<UploadingXML>();
    protected HttpPostedFile tempXML;
    protected String tempUser;
    protected int tempCostForXML;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Label1.Text = "Welcome " + Session["username"];
            tempUser = Session["username"].ToString();

            //inittialisiere Label
            Label label2 = new Label();
            label2.ID = "Label2";
            label2.Text = "Hochzuladnede Datei:";
            label2.Visible = true;
            Label2.Controls.Add(label2);

            //inittialisiere Fileuploade
            FileUpload fileupload = new FileUpload();
            fileupload.ID = "FileUpload1";
            fileupload.Visible = true;
            FileUpload1.Controls.Add(fileupload);

            //inittialisiere Label
            Label label3 = new Label();
            label3.ID = "Label3";
            label3.Text = "Festgelegter Preis für den Verkauf";
            label3.Visible = true;
            Label3.Controls.Add(label3);

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

    protected void addNewXML(object sender, EventArgs e)
    {
        uploadedXMLs.Add(new UploadingXML(tempXML, tempUser, tempCostForXML));
    }
}