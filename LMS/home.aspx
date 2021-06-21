<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="LMS.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Showcase -->
    <section class="showcase">
        <div class="container-fluid grid">
            <div class="showcase-text">
                <h2>Our LMS</h2>
                <p>Our Library Management System is one of the best reknowned library in the country. We provide a variety of books to our Members to borrow and enjoy. The best part is that it all comes for free! Sign up now to borrow books from us for free!</p>
                
                <a href="features.aspx" class="btn btn-outline">Read More</a>
            </div>
            
        </div>
    </section>
    <!-- Stats -->
    <section class="stats">
        <div class="container">
            <h3 class="stats-heading text-center my-1">
                Welcome to the best platform for having access to a variety of books
            </h3>
            <div class="row text-center my-4 align-content-center">
                <div class="col-md-4 text-center">
                    <i class="fas fa-book fa-3x"></i>
                    <h3>1,523</h3>
                    <p class="text-secondary">Books</p>
                </div>
                <div class="col-md-4 text-center">
                    <i class="fas fa-align-left fa-3x"></i>
                    <h3>987</h3>
                    <p class="text-secondary">Authors</p>
                </div>
                <div class="col-md-4 text-center">
                    <i class="fas fa-users fa-3x"></i>
                    <h3>2,343</h3>
                    <p class="text-secondary">Members</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
