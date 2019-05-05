<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="Recycling_4._0._Default" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container centerContainer">
        <asp:Login id="Login1" runat="server" Class="hidden"
            OnAuthenticate="OnAuthenticate"
            OnLoggingIn="OnLoggingIn"
            OnLoggedIn="OnLoggedIn"
            OnLoginError="OnLoginError">
         </asp:Login>
    </div>
    
</asp:Content>
