<%@ Page Title="" Language="C#" MasterPageFile="~/member.Master" AutoEventWireup="true" CodeBehind="member_book_review.aspx.cs" Inherits="LMS.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Reviews</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="padding-top:2em; padding-bottom:2em;">
      <div class="row justify-content-center">
         <div class="col-md-8 " style="animation:slideInFromRight 1s ease-in;">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b>Book Review</b></h4>
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
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server">

                          </asp:GridView>
                      </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
