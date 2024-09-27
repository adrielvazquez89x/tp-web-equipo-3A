<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
    <div class="row">
        <div class="col-4">
            <h2>Welcome!</h2>
            <%--<asp:Label Text="error" ID="lblMensaje" Visible="false" runat="server" />--%>
            <div class="mb-3">
                <label class="form-label">Voucher Code:</label>
                <asp:TextBox runat="server" cssclass="form-control" REQUIRED="true" ID="txtVoucherCode" />
            </div>
            <asp:Label ID="LabelPrueba" runat="server" Visible="false"></asp:Label>
            <asp:Button Text="swapping" cssclass="btn btn-primary" OnClick="btnSwap_Click" ID="btnSwap" runat="server" />

        </div>
    </div>
    </main>

</asp:Content>
