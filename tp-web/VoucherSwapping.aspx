<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherSwapping.aspx.cs" Inherits="tp_web.VoucherForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Wizard ID="Wizard1" runat="server">
    <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
            <ContentTemplate>
                <h2>Welcome!</h2>
                <div class="mb-3">
                    <label for="txtVoucherCode" class="form-label">Voucher Code:</label>
                    <asp:TextBox runat="server" cssclass="form-control" REQUIRED="true" ID="txtVoucherCode" />
                </div>
                <asp:Button Text="swapping" cssclass="btn btn-primary" OnClick="btnSwap_Click" ID="btnSwap" runat="server" />
            </ContentTemplate>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
            <ContentTemplate>
                <h2>Choose the Prize</h2>
                <p>aca apareceran las opciones de los premios.</p>
                    <asp:Button Text="Next" cssclass="btn btn-primary¨ ID="btnNext" runat="server" /> <%--OnClick="btnNext_Click" NO ME ESTA DEJANDO AGREGAR EVENTOS...--%>
            </ContentTemplate>
        </asp:WizardStep>
    </WizardSteps>
</asp:Wizard>
</asp:Content>
