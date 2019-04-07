<%@ Page Title="Marktplace" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormsAuthentication.aspx.cs" Inherits="Recycling_4._0.FormsAuthentication" %>
<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form runat="server">
        <div>
            Welcome
                <asp:LoginName ID="LoginName1" runat="server" Font-Bold="true" />
            <br />
            <br />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </div>

        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <a href="~/">Recicling 4.0 Market Place</a>
                </div>
            </div>
        </div>

        <div class="container body-content">
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> Team 01</p>
            </footer>
        </div>
    </form>
    <p>&nbsp;</p>
</body>
</html>
