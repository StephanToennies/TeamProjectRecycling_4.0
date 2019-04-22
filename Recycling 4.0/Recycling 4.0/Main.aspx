<%@ Page Title="Marktplatz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Main.aspx.cs" Inherits="Recycling_4._0.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Laden Sie ihre XML Datei hoch</h1>
    <table>
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
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Hochladen" OnClick="addNewXML"/>
            </td>
        </tr>
    </table>
</asp:Content>
