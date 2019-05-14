using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{

    private string strconnct = WebConfigurationManager.ConnectionStrings["DatabaseConnectionString1"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool UserLogin(string un, string pw)
    {
        SqlConnection con = new SqlConnection(strconnct);
        SqlCommand cmd = new SqlCommand("Select username from users where username=@un and password=@pw", con);
        cmd.Parameters.AddWithValue("@un",un);
        cmd.Parameters.AddWithValue("@pw", pw);
        con.Open();
        String result = Convert.ToString(cmd.ExecuteScalarAsync());

        if (String.IsNullOrEmpty(result)) return false; return true;


    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string un = Login1.UserName;
        string pw = Login1.Password;

        bool result = UserLogin(un,pw);

        if (result)
        {
            e.Authenticated = true;
            Session["username"] = un;

        }
        else e.Authenticated = false;


    }


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Session["username"] = TextBox1.Text;
    }
}