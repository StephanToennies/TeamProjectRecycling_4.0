<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="App_Data/Scripts/jquery-3.3.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Welcome.aspx">HyperLink</asp:HyperLink>
        </p>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Welcome.aspx" OnAuthenticate="Login1_Authenticate">
        </asp:Login>
    </form>
</body>
</html>
