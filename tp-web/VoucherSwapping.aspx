<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VoucherSwapping.aspx.cs" Inherits="tp_web.VoucherForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" ActiveStepIndex="0" OnNextButtonClick="Wizard1_NextButtonClick">
        <WizardSteps>
            <%-- Validación del código --%>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                <contenttemplate>
                    <div class="container text-center mt-5">
                        <h2 class="display-4 text-primary">Welcome!</h2>
                        <div class="mb-3">
                            <label for="txtVoucherCode" class="form-label">Voucher Code:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtVoucherCode" />
                        </div>
                        <asp:Label ID="lblVoucherError" runat="server" Text="" ForeColor="Red" />
                        <asp:Button Text="Swapping" CssClass="btn btn-primary" OnClick="btnSwap_Click" ID="btnSwap" runat="server" />
                    </div>
                </contenttemplate>
            </asp:WizardStep>

            <%--  Eleccion del premio --%>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                <contenttemplate>
                    <h2>Choose the Prize</h2>
                    <div class="container">
                        <div class="row justify-content-center">
                            <asp:Repeater ID="rptListaDeCosas" runat="server" OnItemDataBound="rptListaDeCosas_ItemDataBound">
                                <ItemTemplate>
                                    <div class="col-md-4 mb-4">
                                        <div class="card h-100" style="width: 18rem;">
                                            <!-- Carrusel de imágenes -->
                                            <div id="carouselExample<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel">
                                                <div class="carousel-inner">
                                                    <!-- Repeater anidado para las imágenes -->
                                                    <asp:Repeater ID="rptImagesList" runat="server">
                                                        <ItemTemplate>
                                                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                                                <img src='<%# Eval("UrlImage") %>' class="d-block w-100" style="height: 300px; object-fit: cover;">
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>

                                                <!-- Controles del carrusel -->
                                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample<%# Eval("Id") %>" data-bs-slide="prev">
                                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                    <span class="visually-hidden">Previous</span>
                                                </button>
                                                <button class="carousel-control-next" type="button" data-bs-target="#carouselExample<%# Eval("Id") %>" data-bs-slide="next">
                                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                    <span class="visually-hidden">Next</span>
                                                </button>
                                            </div>

                                            <!-- Información del premio -->
                                            <div class="card-body">
                                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                                <p class="card-text"><%# Eval("Description") %></p>
                                                <asp:Button
                                                    ID="btnPick" OnClick="btnPick_Click"
                                                    CommandArgument='<%# Eval("Id") %>'
                                                    runat="server"
                                                    Text="I want this!" CssClass="btn btn-primary w-100" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                    </div>
                </contenttemplate>
            </asp:WizardStep>

            <%--  Datos del usuario --%>

            <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                <contenttemplate>
                    <h1 class="text-center mb-4">Enter your information</h1>

                    <%--  DNI --%>
                    <div class="container col-8">
                        <div class="container mb-2">
                            <asp:Label ID="lblDni" runat="server" Text="DNI" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="DNI is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="container mb-2">
                            <asp:Label ID="lblError" runat="server" Visible="false" CssClass="form-label"></asp:Label>
                        </div>
                        <%-- Next --%>
                        <div class="container">
                            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary w-100" OnClick="btnNext_Click" />
                        </div>
                    </div>
                </contenttemplate>
            </asp:WizardStep>

            <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 4">
                <contenttemplate>
                    <%-- Name, lastname, email --%>
                    <div class="container">
                        <div class="row mb-2">
                            <div class="col-md-4">
                                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorName" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorLastName" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." CssClass="text-danger" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorEmail" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Address, City, Postal Code --%>
                    <div class="container">
                        <div class="row mb-2">
                            <div class="col-md-4">
                                <asp:Label ID="lblAdress" runat="server" Text="Address" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAdress" runat="server" ControlToValidate="txtAdress" ErrorMessage="Address is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorAdress" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblCity" runat="server" Text="City" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorCity" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="lblCP" runat="server" Text="Postal Code" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCP" runat="server" ControlToValidate="txtCP" ErrorMessage="Postal Code is required." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div class="container mb-2">
                                    <asp:Label ID="lblErrorCP" runat="server" Visible="false" CssClass="form-label text-danger"></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <%-- Terms checkbox --%>
                    <div class="container mb-3">
                        <div class="form-check">
                            <asp:CheckBox ID="chkAgree" runat="server" AutoPostBack="true" OnCheckedChanged="chkAgree_CheckedChanged" />
                            <asp:Label ID="lblAgree" runat="server" CssClass="form-check-label" Text="I agree to the terms and conditions" AssociatedControlID="chkAgree" />
                        </div>
                    </div>



                    <%-- Submit --%>
                    <div class="container">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary w-100" OnClick="btnSubmit_Click" Enabled="false" />
                    </div>

                </contenttemplate>
            </asp:WizardStep>

        </WizardSteps>


        <StartNavigationTemplate>
        </StartNavigationTemplate>

        <StepNavigationTemplate>
            <asp:Button ID="btnStepPrevious" runat="server" Text="Previous" CommandName="MovePrevious" CssClass="btn btn-secondary" />
            <%--<asp:Button ID="btnStepNext" runat="server" Text="Siguiente" CommandName="MoveNext" CssClass="btn btn-secondary" />--%>
        </StepNavigationTemplate>

        <StepNavigationTemplate>
            <asp:Button ID="btnStepPrevious" runat="server" Text="Previous" CommandName="MovePrevious" CssClass="btn btn-secondary" />
            <%--<asp:Button ID="btnStepPrevious" runat="server" Text="Previous" CommandName="MovePrevious" CssClass="btn btn-secondary" />--%>
        </StepNavigationTemplate>

        <FinishNavigationTemplate>
            <asp:Button ID="btnStepPrevious" runat="server" Text="Previous" CommandName="MovePrevious" CssClass="btn btn-secondary" />
            <%--<asp:Button ID="btnFinishPrevious" runat="server" Text="Anterior" CommandName="MovePrevious" CssClass="btn btn-secondary" />--%>
            <%--<asp:Button ID="btnFinish" runat="server" Text="Finalizar" CommandName="Finish" CssClass="btn btn-success" />--%>
        </FinishNavigationTemplate>
    </asp:Wizard>

</asp:Content>
