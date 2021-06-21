<%@ Page Title="" Language="C#" MasterPageFile="~/member.Master" AutoEventWireup="true" CodeBehind="member_view_books.aspx.cs" Inherits="LMS.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Books</title>
    <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top:2em; padding-bottom:2em; animation:slideInFromRight 1s ease-in;">
      <div class="row">
         <div class="col-md-12 mx-auto">
            <div class="card py-2">
               <div class="card-body">
                   <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/books.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4><b>Borrowing History</b></h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lmsConnectionString %>" SelectCommand="memberBookLoad" SelectCommandType="StoredProcedure">
                           <SelectParameters>
                               <asp:SessionParameter Name="mid" SessionField="username" Type="String" />
                           </SelectParameters>
                       </asp:SqlDataSource>
                     <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="mem_id,book_id,book_id1" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                             <Columns>
                                 <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" SortExpression="book_id" />
                                 <asp:TemplateField HeaderText="Book Details">
                                     <ItemTemplate>
                                    <div class="container-fluid">
                                       <div class="row">
                                          <div class="col-lg-9">
                                             <div class="row">
                                                <div class="col-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("title") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   <span>Author - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("name1") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Genre - </span>
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                      Language -<span>&nbsp;</span>
                                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("lingo") %>'></asp:Label>
                                                   </span>
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Publisher -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("name") %>'></asp:Label>
                                                   &nbsp;| Publish Date -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publ_yr") %>'></asp:Label>
                                                   
                                                </div>
                                             </div>
                                             <div class="row">
                                                <div class="col-12">
                                                   Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("des") %>'></asp:Label>
                                                </div>
                                             </div>
                                          </div>
                                          <div class="col-lg-3">
                                             <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("img_link") %>' />
                                          </div>
                                       </div>
                                    </div>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="iss_date" HeaderText="Issue Date" SortExpression="iss_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true" />
                                 <asp:BoundField DataField="exp_ret_date" HeaderText="Expected Return Date" SortExpression="exp_ret_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true" />
                                 <asp:BoundField DataField="act_ret_date" HeaderText="Actual Return Date" SortExpression="act_ret_date" DataFormatString="{0:d}" ApplyFormatInEditMode="true" />
                                 <asp:TemplateField HeaderText="Reviews">
                                     <ItemTemplate>
                                         <div class="row">
                                             <div class="col">
                                                 <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Add Review" TextMode="MultiLine"></asp:TextBox>
                                                 <br />
                                                 <asp:Button class="btn btn-block btn-lg" ID="Button1" runat="server" Text="Submit Review" OnClick="Button1_Click"/>
                                             </div>
                                         </div>
                                     </ItemTemplate>
                                 </asp:TemplateField>
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
