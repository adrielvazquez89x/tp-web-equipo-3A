<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasoDos.aspx.cs" Inherits="tp_web.PasoDos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1 class="text-center">Segundo paso</h1>
    <h2 class="text-center mb-4">Choose your price</h2>
    
<div class="container">
    <div class="row ">
        <% foreach (var item in ListaDeCosas)
            {%>
        <div class="col-md-4 mb-4 " >
            <div class="card h-100" style="width: 18rem;">
<img src="<%= item.UrlImages[0].UrlImage %>" class="card-img-top" alt="<%=item.Name %>" style="height: 200px; object-fit: cover;">
                <div class="card-body text-center">
                    <h5 class="card-title"><%=item.Name %></h5>
                    <p class="card-text"><%=item.Description %></p>
                    <a href="#" class="btn btn-primary">Quiero esta </a>
                </div>
            </div>
        </div>
        <%}%>
    </div>
</div>






</asp:Content>
