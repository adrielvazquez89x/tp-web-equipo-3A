<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherSwapping.aspx.cs" Inherits="tp_web.VoucherForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--Hay que probar esto, se ve piola vaguex
    <asp:Wizard ID="Wizard1" runat="server">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1"></asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2"></asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>--%>

    <div class="row">
    <div class="col-4">
        <h2>Welcome!</h2>
       <div class="mb-3">
            <label class="form-label">Voucher Code:</label>
            <asp:TextBox runat="server" cssclass="form-control" REQUIRED="true" ID="txtVoucherCode" />
        </div>
        <asp:Label ID="LabelPrueba" runat="server" Visible="false"></asp:Label>
        <asp:Button Text="swapping" cssclass="btn btn-primary" OnClick="btnSwap_Click" ID="btnSwap" runat="server" />

    </div>
</div>
</asp:Content>
