<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="Recycling_4._0._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <p>+++TEST Default site TEST+++</p>
        <form id="form1">
            <div class="centerContainer">
                <asp:Login ID = "Login1" runat="server" Class="hidden" OnLoggingIn= "OnLoggingIn">
                </asp:Login>
            </div>
        </form>
    </div>
    
</asp:Content>
