using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Welcome : System.Web.UI.Page {
    protected static int xmlName;
    private string strconnct = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;

    public List<UploadingXML> uploadedXMLs = new List<UploadingXML>();
    protected HttpPostedFile tempXML;
    protected String tempUser;
    protected int tempCostForXML;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strconnct);

        if (!IsPostBack)
        {
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
    }

    protected void addNewXML(object sender, EventArgs e)
    {
        //uploadedXMLs.Add(new UploadingXML(tempXML, tempUser, tempCostForXML));

        //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

        xmlName++;
        string fileName = "xml_"+xmlName;
        string filePath = Server.MapPath("~/Uploads/") + fileName;
        FileUpload1.SaveAs(filePath);
        string xml = File.ReadAllText(filePath);

        tempUser = Session["username"].ToString();
        var sqlFormattedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Int32.TryParse(TextBox1.Text.ToString(), out tempCostForXML);

        SqlConnection con = new SqlConnection(strconnct);
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO UpladedData VALUES ('"+ xmlName + "', '"+ tempUser + "', '" + sqlFormattedDate + "', '" + xml + "', '" + tempCostForXML + "');");
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Console.WriteLine("Daten hochgeladen.");

        /*
        using (SqlConnection con = new SqlConnection(strconnct))
        {
            using (SqlCommand cmd = new SqlCommand("InsertXML"))
            {
                cmd.Connection = con;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UploadedUser", Session["username"].ToString());
                cmd.Parameters.AddWithValue("@UploadedData", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@UploadedData", xml);
                cmd.Parameters.AddWithValue("@CostForXML", tempCostForXML);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }*/
    }
}