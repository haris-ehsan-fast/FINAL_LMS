<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="member_signup.aspx.cs" Inherits="LMS.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Member Signup</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top:2em; padding-bottom:2em; animation:slideInFromRight 1s ease-in;">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card py-2">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b> Member Signup</b></h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label> Name</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Name" required="true"></asp:TextBox>
                             
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Date of Birth</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Date" TextMode="Date" required="true"></asp:TextBox>
                         </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                         <div class="form-group">
                             <label>Gender</label><br />
                             
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server">  
                                 <asp:ListItem>Male</asp:ListItem>  
                                 <asp:ListItem>Female</asp:ListItem>  
                             </asp:RadioButtonList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="RadioButtonList1" ErrorMessage="*Gender required" ForeColor="IndianRed">
                            </asp:RequiredFieldValidator>
                             
                         </div>
                     </div>
                  </div>
                <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Email</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email" TextMode="Email"  pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Invalid Email Address e.g amna@gmail.com" required="true"></asp:TextBox>
                            
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Phone Number</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Phone Number" TextMode="Phone" MaxLength="11" pattern="[0-9]{11}" title="Invalid Phone Number e.g 03xxxxxxxxx" required="true"></asp:TextBox>
                             <asp:Label ID="phnoError" runat="server"></asp:Label>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <label>Address</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Address" TextMode="MultiLine" required="true"></asp:TextBox>
                     </div>
                  </div>
                   <br />
                   <center>
                   <span class="badge rounded-pill bg-light text-dark">Login Credentials</span>
                   </center>
                   <div class="row">
                     <div class="col">
                        <label>Member ID</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ID" MaxLength="12" required="true"></asp:TextBox>
                         <asp:Label ID="idExists" runat="server"></asp:Label>
                     </div>
                  </div>
                   <br />
                   <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Password</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Password" TextMode="Password" MaxLength="12" pattern=".{4,12}" title = "Must contain 4-12 characters" required="true"></asp:TextBox>
                            
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Confirm Password</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Confirm Password" TextMode="Password" MaxLength="12" pattern=".{4,12}" title = "Must contain 4-12 characters" required="true"></asp:TextBox>
                            <asp:Label ID="passerror" runat="server"></asp:Label>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="SignUp" OnClick="Button1_Click" />
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
