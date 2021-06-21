<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="features.aspx.cs" Inherits="LMS.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Features</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Head -->
    <section class="features-head bg-white py-3">
        <div class="container-fluid">
            <div>
                <h1 class="xl"><b>Features</b></h1>
                <p class="lead">
                    Check out the features of our enhancing LMS.
                </p>
            </div>
        </div>
    </section>
    <!-- Sub head -->
    <section class="features-sub-head bg-light py-3">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-8">
                    <h1 class="md"><b>Our LMS Platform</b></h1>
                    <br />
                    <br />
                    <p>We have a huge variety of books all for our members. Member are allowed to borrow any book they like to for free. Members will write reviews on the book when returning. This platform enables many people to develop their interests in the different genres present at our LMS.</p>
                </div>
                <div class="col-md-4">
                    <img src="images/server2.png" alt="" style="padding: 50px;" />
                </div>
            </div>
            &nbsp;</div>
    </section>
    <!-- Packages -->
    <section class="features-main my-2">
        <div class="container-fluid">
            <div class="row">
                <div class="col">
                    <h1 class="md"><b>Packages</b></h1>
                </div>
		    </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="card flex">
                        <center>
                            <img src="images/pkg0.png" alt="">
                            <p>Free for borrowing a book for 14 days!</p>
                        </center>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card flex">
                        <center>
                            <img src="images/pkg1.png" alt="">
                            <p>$50 for borrowing a book for 21 days!</p>
                        </center>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card flex">
                        <center>
                            <img src="images/pkg2.png" alt="">
                            <p>$100 for borrowing a book for 28 days!</p>
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
