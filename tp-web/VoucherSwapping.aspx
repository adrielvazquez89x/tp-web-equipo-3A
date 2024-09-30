<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherSwapping.aspx.cs" Inherits="tp_web.VoucherForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <asp:Label ID="consola" runat="server" Text="Label"></asp:Label>
    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" ActiveStepIndex="0" OnNextButtonClick="Wizard1_NextButtonClick">
        <WizardSteps>
            <%-- Validación del código --%>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                <ContentTemplate>
                    <h2>Welcome!</h2>
                    <div class="mb-3">
                        <label for="txtVoucherCode" class="form-label">Voucher Code:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtVoucherCode" />
                    </div>
                    <asp:Label ID="lblVoucherError" runat="server" Text="" ForeColor="Red" />
                    <asp:Button Text="Swapping" CssClass="btn btn-primary" OnClick="btnSwap_Click" ID="btnSwap" runat="server" />
                </ContentTemplate>
            </asp:WizardStep>

            <%--  Eleccion del premio --%>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                <ContentTemplate>
                    <h2>Choose the Prize</h2>
                    <div class="container">
                        <div class="row">
                            <asp:Repeater ID="rptListaDeCosas" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-4 mb-4">
                                        <div class="card h-100" style="width: 18rem;">
                                            <img src='<%# Eval("UrlImages[0].UrlImage") %>' class="card-img-top" alt='<%# Eval("Name") %>'>
                                            <div class="card-body">
                                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                                <p class="card-text"><%# Eval("Description") %></p>
                                                <asp:Button
                                                    ID="btnPick" OnClick="btnPick_Click"
                                                    CommandArgument='<%# Eval("Id") %>'
                                                    runat="server"
                                                    Text="I want this!" CssClass="btn btn-primary w-100"
                                                    />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                </ContentTemplate>
            </asp:WizardStep>

            <%--  Datos del usuario --%>

            <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                <ContentTemplate>
                    <h1 class="text-center mb-4">Enter your information</h1>

                    <%--  DNI --%>
                    <div class="container col-8">
                        <div class="container mb-2">
                            <asp:Label ID="lblDni" runat="server" Text="DNI" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <%-- Next --%>
                        <div class="container">
                            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary w-100" onclick="btnNext_Click" />
                        </div>
                    </div>

                </ContentTemplate>
            </asp:WizardStep>


            <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 4">
                <contentTemplate>
                    
                        <%-- Name, lastname, email --%>
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

                        <%-- Segunda fila: Adress, City, Postal Code --%>
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

                        <%-- Terms checkbox --%>
                        <div class="container mb-3">
                            <div class="form-check">
                                <asp:CheckBox ID="chkAgree" runat="server" />
                                <asp:Label ID="lblAgree" runat="server" CssClass="form-check-label" Text="I agree to the terms and conditions" AssociatedControlID="chkAgree" />
                            </div>
                        </div>


                        <%-- Submit --%>
                        <div class="container">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary w-100" OnClick="btnSubmit_Click" />
                        </div>
                    </div>

                </contentTemplate>
            </asp:WizardStep>

        </WizardSteps>


        <StartNavigationTemplate>
        </StartNavigationTemplate>

        <StepNavigationTemplate>
            <asp:Button ID="btnStepPrevious" runat="server" Text="Previous" CommandName="MovePrevious" CssClass="btn btn-secondary" />
            <%--<asp:Button ID="btnStepNext" runat="server" Text="Siguiente" CommandName="MoveNext" CssClass="btn btn-secondary" />--%>
        </StepNavigationTemplate>

        <FinishNavigationTemplate>
            <asp:Button ID="btnFinishPrevious" runat="server" Text="Anterior" CommandName="MovePrevious" CssClass="btn btn-secondary" />
            <asp:Button ID="btnFinish" runat="server" Text="Finalizar" CommandName="Finish" CssClass="btn btn-success" />
        </FinishNavigationTemplate>
    </asp:Wizard>

</asp:Content>
