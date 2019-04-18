using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recycling_4._0
{
    public class User
    {
        protected string name;
        protected string password;
        protected int credits;
        
        public User(string nameN, string passwordN)
        {
            name = nameN;
            password = passwordN;
            credits = 10;
        }

        public string getName()
        {
            return this.name;
        }

        public string getPassword()
        {
            return this.password;
        }

        void setCredits(int copayment)
        {
            credits += copayment;
        }

        int getCredits()
        {
            return credits;
        }

    }
}