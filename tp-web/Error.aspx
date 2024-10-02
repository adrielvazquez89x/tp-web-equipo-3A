<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-5">
        <h2>
            <asp:Label Text="" ID="lblError" runat="server" />
        </h2>
        <asp:Image CssClass="error" ImageUrl="https://cdn-icons-png.flaticon.com/512/5220/5220262.png" runat="server" />
    </div>
    <div class="text-center mt-5">
        <asp:Button ID="btnGoHome" runat="server" Text="Ir al Inicio" OnClick="btnGoHome_Click" CssClass="btn btn-primary mt-3 text-center" />
    </div>
</asp:Content>
