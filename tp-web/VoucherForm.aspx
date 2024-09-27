<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherForm.aspx.cs" Inherits="tp_web.VoucherForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    Hay que probar esto, se ve piola vaguex
    <asp:Wizard ID="Wizard1" runat="server">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1"></asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2"></asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>
