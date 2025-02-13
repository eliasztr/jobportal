<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="jobportal.user.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <style>
            .clicklink a {
                color: highlight;
                font-family: "Barlow",sans-serif;
                font-weight: 500;
                font-size: 15px;
            }

                .clicklink a:hover {
                    color: #fb246a;
                }
        </style>
        <div class="container pt-50 pb-40">

            <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-center ">Log in</h2>
                </div>
                <div class="col-lg-8 mx-auto">
                    <div class="col-12">
                        <div class="form-group">
                            <label>username</label>
                            <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Enter unique username" required="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Enter password" TextMode="Password" required="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12">
                    </div>
                    <div class="col-12">
                        <div class="form-group mb-3">
                            <label>Login Type</label>
                            <asp:DropDownList ID="ddllogintype" runat="server" CssClass="form-control w-100">

                                <asp:ListItem>Select login type</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>user</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="usertype is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddllogintype"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group mt-3">
                        <asp:Button ID="btnlogin" runat="server" Text="Log In" CssClass="button button-contactForm boxed-btn" OnClick="btnlogin_Click" />
                    </div>
                    <span class="clicklink"><a href="../user/register.aspx">create new account!</a></span>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
