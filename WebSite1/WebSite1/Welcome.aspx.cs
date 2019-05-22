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
using System.Text;

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
            //take username from Login
            try
            {
                Label1.Text = "Welcome " + Session["username"];
                tempUser = Session["username"].ToString();
            }
            catch (System.NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }
            
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

        //Populating a DataTable from database.
        DataTable dt = this.GetDataXMLUploade();
        //Building an HTML string.
        StringBuilder html = new StringBuilder();
        //Table start.
        html.Append("<table border = '1'>");
        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");
        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }
        //Table end.
        html.Append("</table>");
        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

}

    protected void addNewXML(object sender, EventArgs e)
    {
        //!!!
        //Beim Reloade der Seite wird der Upload noch mal hochgeladen
        //!!!
            xmlName = newXmlName();
            string fileName = "xml_" + xmlName;
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);
            string xml = File.ReadAllText(filePath);

            tempUser = Session["username"].ToString();
            var sqlFormattedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Int32.TryParse(TextBox1.Text.ToString(), out tempCostForXML);

            SqlConnection con = new SqlConnection(strconnct);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO UpladedData VALUES ('" + xmlName + "', '" + tempUser + "', '" + sqlFormattedDate + "', '" + xml + "', '" + tempCostForXML + "');");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Daten hochgeladen.");

            FileUpload1.Attributes.Clear();
        
    }

    private DataTable GetDataXMLUploade()
    {
        string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Id, UploadedUser, UploadedDate, CostForXML FROM UpladedData"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    protected int newXmlName()
    {
        DataTable dt = this.GetDataXMLUploade();
        int temp;
        int i = 0;

        for(int j = 0; i < dt.Rows.Count; i++)
        {
            Int32.TryParse(dt.Rows[i]["Id"].ToString(), out temp); // Where Fieldname is the name of fields from your database that you want to get
            if(i != temp)
            {
                return i;
            }
        }
        return i;
    }
}