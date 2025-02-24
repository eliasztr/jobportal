<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="contactlist.aspx.cs" Inherits="jobportal.admin.contactlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container-fluid pt-4 pb-4">
            <div>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>

            </div>

            <h3 class="text-center">Contact list</h3>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                        EmptyDataText="no record to display" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        DataKeyNames="contactid"
                        onRowDeleting="GridView1_RowDeleting" >

                        <Columns>

                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText=" user name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="user email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="subject" HeaderText="Subject">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="message" HeaderText="Message">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                          
                            <asp:TemplateField HeaderText="Delete">

                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server"
                                        CommandName="Delete"
                                        CommandArgument='<%# Eval("contactid") %>'
                                        CssClass="btn btn-danger btn-sm"
                                        OnClientClick="return confirm('Are you sure you want to delete this job?');">
            <i class="fas fa-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                           





                        </Columns>
                        <HeaderStyle BackColor="#7200cf" ForeColor="White" />

                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>





</asp:Content>
