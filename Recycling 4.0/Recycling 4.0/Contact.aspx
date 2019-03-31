<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Recycling_4._0.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- Login Buton -->
    <div>
        <!--
        <form action="action_page.php">
            -->
            <div class="container">
                <label for="username"><b>Username</b></label>
                <input type="text" placeholder="Nutzername" name="username" required>
                <label for="psw"><b>Password</b></label>
                <input type="password" placeholder="Passwort" name="psw" required>
                <button type="submit">Login</button>
            </div>
        <!--
        </form>
        -->
   </div>


</asp:Content>
