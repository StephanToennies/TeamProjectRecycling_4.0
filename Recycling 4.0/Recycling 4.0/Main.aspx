<%@ Page Title="Marktplatz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Main.aspx.cs" Inherits="Recycling_4._0.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Laden Sie ihre XML Datei hoch</h1>
    <asp:Label ID="Label1" runat="server" Text="Hochzuladnede Datei:"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" Class="hidden"/>
    <asp:Label ID="Label2" runat="server" Text="Festgelegter Preis für den Verkauf"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Hochladen" OnClick="addNewXML"/>
</asp:Content>
