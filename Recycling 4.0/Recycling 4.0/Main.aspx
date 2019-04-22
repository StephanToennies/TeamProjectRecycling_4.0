<%@ Page Title="Marktplatz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Main.aspx.cs" Inherits="Recycling_4._0.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 class="uploadingXMLData">Laden Sie Ihre XML Datei hoch</h1>
    <table class="uploadingXMLData">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Hochzuladnede Datei: "></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Class="hidden"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Festgelegter Preis für den Verkauf: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Credits"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Hochladen" OnClick="addNewXML"/>
            </td>
        </tr>
    </table>
    <!--
    <asp:Table ID="TableDynamic" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell>Dateiname </asp:TableCell>
            <asp:TableCell>Datum / Uhrzeit</asp:TableCell>
            <asp:TableCell>Nutzer </asp:TableCell>
            <asp:TableCell>Preis </asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>
    -->
</asp:Content>
