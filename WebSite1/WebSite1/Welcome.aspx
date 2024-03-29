﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>
<html lang="de">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link type="text/css" rel="stylesheet" href="Content/Site.css">
        <title>Marktplatz</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <asp:Label ID="Label_Credits" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Labeln_CreditValue" runat="server" Text="Ihr Credits:  "></asp:Label>
                <br />
                <h3 class="uploadingXMLData">Laden Sie Ihre XML Datei hoch</h3>
                <br />
                <table class="uploadingXMLData">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Hochzuladnede Datei: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" Class="hidden"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Festgelegter Preis für den Verkauf: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" Text="Credits"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Hochladen" OnClick="AddNewXML"/>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="buttonDownloade" runat="server" Text="Downloade" OnClick="btnDownload_Click"></asp:Button>
                <br />
                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                <br />
                <asp:Button ID="buttonAddCredits" runat="server" Text="Add Credits to 50" OnClick="btnAddCredits"/>
            </div>
        </form>
    </body>
</html>
