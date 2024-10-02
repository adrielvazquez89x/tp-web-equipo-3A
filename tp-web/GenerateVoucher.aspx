<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerateVoucher.aspx.cs" Inherits="tp_web.GenerateVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container my-5">

        <div class="row">
            <div class="col-12">
                <h1 class="text-center mb-4">Generar nuevo voucher</h1>
            </div>
        </div>


        <!-- Voucher Button -->
        <div class="row justify-content-center">
            <div class="col-4 text-center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnGenerateVoucher" runat="server" CssClass="btn btn-primary btn-lg w-100" OnClick="btnGenerateVoucher_Click" Text="Generar Voucher" />

                        <!-- Toastie -->
                        <div class="card mt-4" id="voucherCard" runat="server" style="display: none;">
                            <div class="card-body">
                                <h5 class="card-title">Voucher</h5>
                                <p class="card-text">
                                    <asp:Label> Codigo: </asp:Label>
                                    <asp:Literal ID="ltlVoucherCode" runat="server" />
                                </p>
                            </div>
                        </div>


                        <div class="text-center mt-3">
                            <asp:Button ID="btnGoToSwapping" runat="server" CssClass="btn btn-secondary" Text="Ir a Swapping" OnClick="btnGoToSwapping_Click" Visible="false" />
                        </div>

                        <%-- <div class="toast-container position-fixed top-0 end-0 p-5">
                            <div id="toastMessage" class="toast align-items-center text-bg-success border-0" role="alert" aria-live="assertive" aria-atomic="true">
                                <div class="d-flex">
                                    <div class="toast-body">
                                        <asp:Literal ID="ltlToastMessage" runat="server" />
                                    </div>
                                    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                                </div>
                            </div>
                        </div>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </main>

</asp:Content>
