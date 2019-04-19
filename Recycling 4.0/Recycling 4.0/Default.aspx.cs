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

        private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
        {
            return UserName.Equals(user1.getName()) && Password.Equals(user1.getPassword()) ||
                   UserName.Equals(user2.getName()) && Password.Equals(user2.getPassword());
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);

            if (Authenticated)
            {
                Console.WriteLine("User ist valide.");
                Login1.InstructionText = String.Empty;
            }
            else
            {
                Console.WriteLine("User ist invalide.");
                Login1.InstructionText = "Der Nutzername oder E-Mail ist falsch.";
            }

            e.Authenticated = Authenticated;
        }

        protected void OnLoggingIn(object sender, EventArgs e)
        {
            //TODO
        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void OnLoginError(object sender, EventArgs e)
        {
            Console.WriteLine("User ist invalide.");
            Login1.InstructionText = "Der Nutzername oder E-Mail ist falsch.";

            //TODO
        }
    }
}