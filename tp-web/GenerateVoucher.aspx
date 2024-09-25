<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateVoucher.aspx.cs" Inherits="tp_web.GenerateVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
       
        <asp:Button
            ID="btnGenerateVoucher"
            runat="server"
            Text="Generar Voucher"
            OnClick="btnGenerateVoucher_Click" />

    </main>
</asp:Content>
