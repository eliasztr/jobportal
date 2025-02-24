<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="jobportal.user.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container pt-5 pb-5">
        <div class="main-body">
           <asp:DataList ID="dlprofile" runat="server" Width="100%" onItemCommand="dlprofile_ItemCommand">
    <ItemTemplate>
        <div class="row gutters-sm">
            <!-- Left Card: Profile Picture and Basic Info -->
            <div class="col-md-4 mb-3">
                <div class="card">
                    <div class="card-body text-center">
                        <img src="../assets/img/profile.png" 
                             alt="userpic" class="rounded-circle border" width="150" />
                        <div class="mt-3">
                            <h4 class="text-capitalize"><%# Eval("name") %></h4>
                            <p class="text-secondary mb-1"><%# Eval("username") %></p>
                            <p class="text-muted font-size-sm text-capitalize">
                                <i class="fas fa-map-marker-alt"></i> <%# Eval("country") %>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-3"><h6 class="mb-0">Full Name</h6></div>
                            <div class="col-sm-9 text-secondary text-capitalize"><%# Eval("name") %></div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-3"><h6 class="mb-0">Email</h6></div>
                            <div class="col-sm-9 text-secondary text-capitalize"><%# Eval("email") %></div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-3"><h6 class="mb-0">Mobile</h6></div>
                            <div class="col-sm-9 text-secondary text-capitalize"><%# Eval("mobile") %></div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-3"><h6 class="mb-0">Address</h6></div>
                            <div class="col-sm-9 text-secondary text-capitalize"><%# Eval("address") %></div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-3"><h6 class="mb-0">Resume Upload</h6></div>
                            <div class="col-sm-9 text-secondary text-capitalize">
                                <%# Eval("resume") == DBNull.Value ? "Not uploaded" : "Uploaded" %>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="btn btn-primary"
                                    CommandName="edituserprofile" CommandArgument='<%# Eval("userid") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>

        </div>

    </div>


</asp:Content>
