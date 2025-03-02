<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="viewresume.aspx.cs" Inherits="jobportal.admin.viewresume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container-fluid pt-4 pb-4">
            <div>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>

            </div>

            <h3 class="text-center">view resume/download resume</h3>
            <div class="row mb-3 pt-sm-3">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"
                        EmptyDataText="no record to display" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="5"
                        OnPageIndexChanging="GridView1_PageIndexChanging"
                        DataKeyNames="appliedjob"
                        onRowDataBound="GridView1_RowDataBound" >

                        <Columns>

                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="companyname" HeaderText="company name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>



                            <asp:BoundField DataField="title" HeaderText=" job Title">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="user name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="user email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mobile" HeaderText="user mobile">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Resume">

                                <ItemTemplate>
                                 <asp:HyperLink ID="HyperLink1" runat="server" 
    NavigateUrl='<%# "~/DownloadResume.ashx?file=" + Eval("resume") %>'>
    <i class="fas fa-download"></i> Download
</asp:HyperLink>
                                    <asp:HiddenField ID="hdnjobid" runat="server" Value='<%# Eval("jobid") %>' Visible="false" />



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
