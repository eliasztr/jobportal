<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="joblist.aspx.cs" Inherits="jobportal.admin.joblist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container-fluid pt-4 pb-4">
            <div>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>

            </div>

            <h3 class="text-center">job list/Details</h3>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                        EmptyDataText="no record to display" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        DataKeyNames="jobid"
                        OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand">

                        <Columns>

                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="title" HeaderText=" job Title">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numofpost" HeaderText="numOfPosts">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="qualification" HeaderText="Qualification">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="experience" HeaderText="Experience">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="lastdatetoapply" HeaderText="Valid Till" DataFormatString="{0:dd MMMM yyyy}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="companyname" HeaderText="Company">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="country" HeaderText="Country">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="state" HeaderText="State">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="createdate" HeaderText="Posted at" DataFormatString="{0:dd MMMM yyyy}">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Delete">

                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server"
                                        CommandName="Delete"
                                        CommandArgument='<%# Eval("jobid") %>'
                                        CssClass="btn btn-danger btn-sm"
                                        OnClientClick="return confirm('Are you sure you want to delete this job?');">
            <i class="fas fa-trash"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">

                                <ItemTemplate>
                                    <asp:LinkButton ID="btneditjob" runat="server"
                                        CommandName="editjob"
                                        CommandArgument='<%# Eval("jobid") %>'
                                        CssClass="btn btn-danger btn-sm">

<i class="fas fa-edit"></i>
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
