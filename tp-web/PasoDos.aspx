<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasoDos.aspx.cs" Inherits="tp_web.PasoDos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center mb-4">Choose your prize</h2>
    
<div class="container">
    <div class="row ">
        <% foreach (var item in ListaDeCosas)
            {%>
        <div class="col-md-4 mb-4 " >
            <div class="card h-100" style="width: 18rem;">


                <div id="carouselExample" class="carousel slide">
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="https://tudosobrecachorro.wordpress.com/wp-content/uploads/2014/06/cachorros-fofos.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="https://web.archive.org/web/20170305160937im_/http://cachorrosfofos.com.br/wp-content/uploads/2014/04/racas-filhotes-de-cachorros-mais-fofos-malamute.jpg" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="https://www.petdarling.com/wp-content/uploads/2021/01/cachorros.jpg" class="d-block w-100" alt="...">
                        </div>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>


<%--<img src="<%= item.UrlImages[0].UrlImage %>" class="card-img-top" alt="<%=item.Name %>" style="height: 200px; object-fit: cover;">--%>
                
                
                <div class="card-body text-center">
                    <h5 class="card-title"><%=item.Name %></h5>
                    <p class="card-text"><%=item.Description %></p>
                    <a href="#" class="btn btn-primary">I want it!</a>
                </div>
            </div>
        </div>
        <%}%>
    </div>
</div>






</asp:Content>
