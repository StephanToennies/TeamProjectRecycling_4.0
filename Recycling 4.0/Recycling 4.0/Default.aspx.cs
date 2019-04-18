using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;


namespace Recycling_4._0
{
    public partial class _Default : Page
    {
        public User user1 = new User("User A", "password");
        public User user2 = new User("User B", "123456");

        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ID = "Login1";
            Login1.Controls.Add(login);

            

        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            Login Login1 = (Login) sender;

            if (Login1.UserName.Equals(user1.getName()) && Login1.Password.Equals(user1.getPassword()) || 
                Login1.UserName.Equals(user2.getName()) && Login1.Password.Equals(user2.getPassword()))
            {
                Console.WriteLine("User ist valide.");
                Login1.InstructionText = String.Empty;

            }
            else
            {
                Console.WriteLine("User ist invalide.");
                Login1.InstructionText = "Der Nutzername oder E-Mail ist falsch.";
            }

            

            /*
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                    cmd.Parameters.AddWithValue("@Password", Login1.Password);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                switch (userId)
                {
                    //testen
                    case -1:
                        Login1.FailureText = "Username and/or password is incorrect.";
                        break;
                    case -2:
                        Login1.FailureText = "Account has not been activated.";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                        break;
                }
            
            }
            */
        }
    }
}