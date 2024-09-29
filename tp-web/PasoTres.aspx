<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasoTres.aspx.cs" Inherits="tp_web.PasoTres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center mb-4">Enter your information</h1>

    <!--  DNI -->
    <div class="container col-8">
        <div class="container mb-2">
            <asp:Label ID="lblDni" runat="server" Text="DNI" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Name, lastname, email-->
        <div class="container">
            <div class="row mb-2">
                <div class="col-md-4">
                    <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>

        <!-- Segunda fila: Adress, City, Postal Code -->
        <div class="container">
            <div class="row mb-2">
                <div class="col-md-4">
                    <asp:Label ID="lblAdress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCity" runat="server" Text="City" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblCP" runat="server" Text="Postal Code" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>

        <!-- Terms checkbox -->
        <div class="container mb-3">
            <div class="form-check">
                <asp:CheckBox ID="chkAgree" runat="server"/>
                <asp:Label ID="lblAgree" runat="server" CssClass="form-check-label" Text="I agree to the terms and conditions" AssociatedControlID="chkAgree" />
            </div>
        </div>


        <!-- Submit -->
        <div class="container">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary w-100" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
