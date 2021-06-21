<%@ Page Title="" Language="C#" MasterPageFile="~/member.Master" AutoEventWireup="true" CodeBehind="member_profile.aspx.cs" Inherits="LMS.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Member Profile</title>
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
                           <h4><b>Your Profile</b></h4>
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
                             <label>Full Name</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Name"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Date of Birth</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
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
                         </div>
                     </div>
                  </div>
                <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Email</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Email" TextMode="Email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$" title="Invalid Email Address"></asp:TextBox>
                             <asp:Label ID="emailerror" runat="server"></asp:Label>
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Phone Number</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Phone Number" TextMode="Phone" maxLength="11" pattern="[0-9]{11}" title="Invalid Phone Number"></asp:TextBox>
                            <asp:Label ID="phnoError" runat="server"></asp:Label>

                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <label>Address</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                     </div>
                  </div>
                   <br />
                   <div class="row">
                     <div class="col-md-3">
                       <label>Package ID</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="ID" ReadOnly="true"></asp:TextBox>
                     </div>
                       <div class="col-md-3">
                       <label>Max Dura</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Max Dur" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                       <div class="col-md-3">
                       <label>Max Books</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Max Books" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                       <div class="col-md-3">
                       <label>Amount</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Amount" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                  </div>
                   <br />
                   <center>
                   <span class="badge rounded-pill bg-light text-dark">Login Credentials</span>
                   </center>
                   <br />
                   <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Member ID</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ID" ReadOnly="True"></asp:TextBox>
                             
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label> Old Password</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Old Password" TextMode="Password" pattern=".{4,12}" title = "Must contain 4-12 characters"></asp:TextBox>
                             <asp:Label ID="passerror" runat="server"></asp:Label>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                       <div class="col-md-6">
                           <label>New Password</label>
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="New Password" TextMode="Password" pattern=".{4,12}" title = "Must contain 4-12 characters"></asp:TextBox>
                            <asp:Label ID="newpasserr" runat="server"></asp:Label>
                       </div>
                       <div class="col-md-6">
                           <label>Confirm New Password</label>
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Confirm New Password" TextMode="Password" pattern=".{4,12}" title = "Must contain 4-12 characters"></asp:TextBox>
                           <asp:Label ID="passerror2" runat="server"></asp:Label>
                       </div>
                   </div>
                   <br />
                   <div class="row">
                     <div class="col">
                        <div class="form-group">
                           <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                            <asp:Label ID="updated" runat="server"></asp:Label>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
