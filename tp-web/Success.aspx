<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="tp_web.Success" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container text-center">
        <h1 class="mt-5 text-success"><asp:Label Text="CONGRATULATIONS" ID="lblCongrats" runat="server" /></h1>
        <p class="lead"><asp:Label ID="lblP1" runat="server" /></p>
        <p class="lead"><asp:Label ID="lbl2" runat="server" /></p>
        <a href="Default.aspx" class="btn btn-primary">Return to main page</a>

    </div>
</asp:Content>
