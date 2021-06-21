<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin_member_management.aspx.cs" Inherits="LMS.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Member Management</title>
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-top:2em; padding-bottom:2em;">
      <div class="row">
         <div class="col-md-5" style="animation: slideInFromLeft 1s ease-in;">
            <div class="card">
               <div class="card-body">
                   <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/generaluser.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b> Member Details</b></h4>
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
                        <label>Member ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" required="true" ></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" Text="Go" OnClick="LinkButton4_Click"></asp:LinkButton>
                            </div>
                               <asp:Label ID="IDerror" runat="server"></asp:Label>
                        </div>
                     </div>
                    </div>
                   <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Full Name</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Name" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Date of Birth</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date" TextMode="Date" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                         <div class="form-group">
                             <label>Gender</label><br />
                             <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Gender" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Email</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="Email" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                     <div class="col-md-6">
                         <div class="form-group">
                             <label>Phone Number</label>
                             <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Phone Number" TextMode="Phone" ReadOnly="true"></asp:TextBox>
                         </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <label>Address</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Address" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                     </div>
                  </div>
                   <br />
                   <div class="row">
                       <div class="col">
                       <label>Package ID</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="ID" pattern="[0-9]" title="Only one digit numbers allowed" MaxLength ="1"></asp:TextBox>
                       </div>
                   </div>
                   <div class="row">
                       <div class="col-md-4">
                       <label>Max Dur</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Max Dur" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                       <div class="col-md-4">
                       <label>Max Books</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Max Books" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                       <div class="col-md-4">
                       <label>Amount</label>
                         <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="Amount" TextMode="Number" ReadOnly="true"></asp:TextBox>
                     </div>
                  </div>
                   <br />
                   <div class="row mx-auto">
                     <div class="col-md-6 mx-auto">
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                       <asp:Label ID="pkgerror" runat="server"></asp:Label>
                        </div>
                          
                     </div>
                  </div>
                   <div class="row">
                     <div class="col mx-auto">
                        <div class="form-group">
                           <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button1" runat="server" Text="Delete Member Permenantly" OnClick="Button1_Click" />
                             <asp:Label ID="delete" runat="server"></asp:Label>
                        </div>
                     </div>
                  </div>
                   
               </div>
            </div>
         </div>
         <div class="col-md-7" style="animation: slideInFromRight 1s ease-in;">
             <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b> Member List</b></h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsConnectionString %>" SelectCommand="SELECT * FROM [member]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="mem_id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="mem_id" HeaderText="Member ID" ReadOnly="True" SortExpression="mem_id" />
                                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
                                <asp:BoundField DataField="ph_no" HeaderText="Phone Number" SortExpression="ph_no" />
                                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                <asp:BoundField DataField="mem_pkg_id" HeaderText="Package ID" SortExpression="mem_pkg_id" />
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>


               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
