using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recycling_4._0
{
    public class UploadingXML
    {
        public LocalDataStoreSlot xmlData;
        public DateTime dateOfUploade;
        public User uploadedUser;
        public int costForTheXML;

        public UploadingXML(Object xml, User user, int xmlCost)
        {
            xmlData = (LocalDataStoreSlot) xml;
            dateOfUploade = DateTime.Now;
            uploadedUser = user;
            costForTheXML = xmlCost;
        }
    }
}