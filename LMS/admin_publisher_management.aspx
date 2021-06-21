<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin_publisher_management.aspx.cs" Inherits="LMS.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Publisher Management</title>
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top:2em; padding-bottom:2em;">
        <div class="row">
            <div class="col-md-5 mx-auto" style="animation:slideInFromLeft 1s ease-in;">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="images/publisher.png" />
                                       
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4><b>Publisher Details</b></h4>
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
                                <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" required="true" ></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Publisher Name"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success text-center" runat="server" Text="Add" OnClick="Button2_Click" />
                                
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning text-center" runat="server" Text="Update" OnClick="Button3_Click" />
                                
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger text-center" runat="server" Text="Delete" OnClick="Button4_Click" />
                                
                            </div>
                        </div>
                        <div class="row justify-content-center">
                            <div class="col-md-12">
                                <asp:Label ID="buttonerror" runat="server"></asp:Label>
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
                                        <h4><b>Publisher List</b></h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsConnectionString %>" SelectCommand="SELECT * FROM [publisher]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publ_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publ_id" HeaderText="Publisher ID" ReadOnly="True" SortExpression="publ_id" />
                                        <asp:BoundField DataField="name" HeaderText="Publisher Name" SortExpression="name" />
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
