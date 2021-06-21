<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="member_login.aspx.cs" Inherits="LMS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Member Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container" style="padding-top:2em; padding-bottom:2em; animation:slideInFromRight 1s ease-in;">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card py-2">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3> Member Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" required="true" MaxLength="12"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" required="true" TextMode="Password" MaxLength="12"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="loginerror" runat="server"></asp:Label><br/>
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                        <div class="form-group">
                           <a href="member_signup.aspx"><input class="btn btn-primary btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="home.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
