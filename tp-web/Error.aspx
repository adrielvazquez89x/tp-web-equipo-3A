﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center mt-5">
        <h2>
            <asp:Label Text="" ID="lblError" runat="server" />
        </h2>
        <asp:Image CssClass="error img-fluid" ImageUrl="https://cdn-icons-png.flaticon.com/512/5220/5220262.png" runat="server" Style="width: 20%; max-width: 200px;" />
    </div>
    <div class="text-center mt-5">
        <asp:Button ID="btnGoHome" runat="server" Text="Home" OnClick="btnGoHome_Click" CssClass="btn btn-primary mt-3 text-center" />

        <asp:Button ID="btnGoToSwapping" runat="server" CssClass="btn btn-primary mt-3 text-center" Text="Go to Swapping" OnClick="btnGoToSwapping_Click" />

    </div>
</asp:Content>
