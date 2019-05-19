<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="de">
    <head runat="server">
        <link type="text/css" rel="stylesheet" href="Content/Site.css">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Login</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:Login ID="Login1" class="login" runat="server" DestinationPageUrl="~/Welcome.aspx" OnAuthenticate="Login1_Authenticate">
            </asp:Login>
        </form>
    </body>
</html>
