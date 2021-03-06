﻿using System;
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

    protected HttpPostedFile tempXML;
    protected String tempUser;
    protected int tempCreditValue;
    protected int tempCostForXML;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strconnct);

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
        Label labeln_CreditValue = new Label();
        DataTable dtCrecitValue = new DataTable(); 
        labeln_CreditValue.ID = "Labeln_CreditValue";
        SqlCommand cmdCredits = new SqlCommand("SELECT Credits from users WHERE UserName='" + tempUser + "';", con);
        cmdCredits.CommandType = CommandType.Text;
        con.Open();
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmdCredits.Connection = con;
            sda.SelectCommand = cmdCredits;
            sda.Fill(dtCrecitValue);
            tempCreditValue = Convert.ToInt32(dtCrecitValue.Rows[0][0]);
        }
        Labeln_CreditValue.Text = "Ihr Credits:  " + tempCreditValue;


        //inittialisiere Label
        //Label label2 = new Label();
        Label2.ID = "Label2";
        Label2.Text = "Hochzuladnede Datei:";
        Label2.Visible = true;
        //Label2.Controls.Add(label2);

        //inittialisiere Fileuploade
        //FileUpload fileupload = new FileUpload();
        FileUpload1.ID = "FileUpload1";
        FileUpload1.Visible = true;
        //FileUpload1.Controls.Add(fileupload);

        //inittialisiere Label
        //Label label3 = new Label();
        Label3.ID = "Label3";
        Label3.Text = "Festgelegter Preis für den Verkauf";
        Label3.Visible = true;
        //Label3.Controls.Add(label3);

        //intitalise TextBox 
        //TextBox textbox = new TextBox();
        TextBox1.ID = "TextBox1";
        TextBox1.Visible = true;
        //TextBox1.Controls.Add(textbox);


        //intitalise Button 
        //Button button = new Button();
        Button1.ID = "Button1";
        Button1.Visible = true;
        //Button1.Controls.Add(button);

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
        html.Append("<th>");
        html.Append("Downloads");
        html.Append("</th>");
        html.Append("</tr>");

        int rowCounter = 0;
        //Generiere aus DataTable eine HTML-Tabelle
        foreach (DataRow row in dt.Rows)
        {

            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("<td>");
            html.Append("<button id=\"ButtonDownloade"+rowCounter + "\"  runat=\"server\" name=\"Downloade\" style=\"width:79px; height:22px\"  OnClick=\"btnDownload_Click\">Downloade");
            html.Append("</td>");
            html.Append("</tr>");
            rowCounter++;
        }
        //Table end.
        html.Append("</table>");
        //Ein Platzhalter
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

}

    protected void AddNewXML(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
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
            SqlCommand cmd = new SqlCommand("INSERT INTO UpladedData VALUES ('" + xmlName + "', '" + tempUser + "', '" + sqlFormattedDate + "', '" + xml + "', '" + (tempCostForXML + 10) + "');"); //+10 weil sehe imp_4_2
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Daten hochgeladen.");

            TextBox1.Text = "";
        }

        //Reloade der Seite erzwingen
        Response.Redirect(Request.RawUrl);
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
    protected void btnDownload_Click(object sender, EventArgs e)
    {

        //Response.Redirect("Uploade/xml_0");

        string FileName = "xml.xml"; // It's a file name displayed on downloaded file on client side.
        
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/xml";
        response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");
        response.TransmitFile(Server.MapPath("~/Uploads/xml_0"));
        response.Flush();
        response.End();
        
    }

    protected void btnAddCredits(object sender, EventArgs e)
    {
        //string conn = ConfigurationManager.ConnectionStrings["welcome"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strconnct))
        {
            SqlCommand cmd = new SqlCommand("UPDATE users SET Credits='50' WHERE UserName='" + tempUser + "';", con);

            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.ExecuteNonQuery();
        }
        //Reloade der Seite erzwingen
        Response.Redirect(Request.RawUrl);
    }
}