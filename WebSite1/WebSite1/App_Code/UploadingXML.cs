using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Zusammenfassungsbeschreibung für UploadingXML
/// </summary>
public class UploadingXML
{
    public HttpPostedFile xmlData { get; set; }
    public DateTime dateOfUploade;
    public String uploadedUser;
    public int costForTheXML;

    public UploadingXML(Object xml, String user, int xmlCost)
    {
        xmlData = (HttpPostedFile)xml;
        dateOfUploade = DateTime.Now;
        uploadedUser = user;
        costForTheXML = xmlCost;
    }
}