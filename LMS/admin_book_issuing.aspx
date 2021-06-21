<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin_book_issuing.aspx.cs" Inherits="LMS.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Book Issuing</title>
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-top:2em; padding-bottom:2em;">
      <div class="row">
         <div class="col-md-5" style="animation:slideInFromLeft 1s ease-in;">
            <div class="card">
               <div class="card-body">
                 
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/books.png" />
                        </center>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col">
                        <center>
                           <h4><b>Book Issuing</b></h4>
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
                        <label>Member ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Book ID"></asp:TextBox>
                             
                           </div>
                        </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col mx-auto">
                        <div class="form-group">
                           <asp:Button class="btn btn-block btn-lg" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                            <asp:Label ID="iderror" runat="server"></asp:Label>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Member Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Title</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Title" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Start Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>End Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Issue" OnClick="Button2_Click" />
                         <asp:Label ID="issue" runat="server"></asp:Label>
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-success" runat="server" Text="Return" OnClick="Button4_Click" />
                         <asp:Label ID="returnerr" runat="server"></asp:Label>
                     </div>
                  </div>
               </div>
            </div>
            <br>
         </div>
         <div class="col-md-7" style="animation:slideInFromRight 1s ease-in;">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b>Issued Book List</b></h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsConnectionString %>" SelectCommand="SELECT borrowing.mem_id, member.name, borrowing.book_id, book.title, borrowing.iss_date, borrowing.exp_ret_date, borrowing.act_ret_date FROM borrowing INNER JOIN member ON borrowing.mem_id = member.mem_id INNER JOIN book ON borrowing.book_id = book.book_id"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="mem_id,book_id" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="mem_id" HeaderText="Member ID" SortExpression="mem_id" ReadOnly="True" />
                                <asp:BoundField DataField="name" HeaderText="Member Name" SortExpression="name" />
                                <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" ReadOnly="True" />
                                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                                <asp:BoundField DataField="iss_date" HeaderText="Issue Date" SortExpression="iss_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true"/>
                                <asp:BoundField DataField="exp_ret_date" HeaderText="Expected Return Date" SortExpression="exp_ret_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true" />
                                <asp:BoundField DataField="act_ret_date" HeaderText="Actual Return Date" SortExpression="act_ret_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true"/>
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
