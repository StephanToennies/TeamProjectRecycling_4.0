using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recycling_4._0
{
    public class UploadingXML
    {
        public HttpPostedFile xmlData { get; set; }
        public DateTime dateOfUploade;
        public User uploadedUser;
        public int costForTheXML;

        public UploadingXML(Object xml, User user, int xmlCost)
        {
            xmlData = (HttpPostedFile) xml;
            dateOfUploade = DateTime.Now;
            uploadedUser = user;
            costForTheXML = xmlCost;
        }
    }
}