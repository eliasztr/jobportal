<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="jobportal.user.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt-50 pb-40">

            <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-center " >Sign Up</h2>
                </div>
                <div class="col-lg-8 mx-auto">

                    <div class="row">
                        <div class="col-12">
                            <h6>Login information</h6>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>username</label>
                                <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Enter unique username" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Password</label>
                                <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="Enter password" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>confirm password</label>
                                <asp:TextBox ID="txtconfirmpassword" runat="server" CssClass="form-control" placeholder="Confirm Password" required="required"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="does not match" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="col-12">
                            <h6>Personal information</h6>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox ID="txtfullname" runat="server" CssClass="form-control" placeholder="Enter unique username" required="required"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="name must be in characters" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtfullname"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter address" required="required" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Mobile number</label>
                                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" placeholder="Enter mobile number" required="required" TextMode="MultiLine"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="mobile number must have 10 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtmobile"></asp:RegularExpressionValidator>

                            </div>

                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Email</label>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter Email" required="required" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Contry</label>
                                <asp:DropDownList ID="ddlcountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                                    
                                    AppendDataBoundItems="true" DataTextField="countryname" DataValueField="countryname" >
                                    <asp:ListItem Value="0">Select country</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="country is required" ForeColor="Red"  Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlcountry"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT [countryname] FROM [country]"></asp:SqlDataSource>
                            </div>
                        </div>

                    </div>
                    <div class="form-group mt-3">
                        <asp:Button ID="btnregister" runat="server" Text="Register" CssClass="button button-contactForm boxed-btn" OnClick="btnregister_Click" />

                    </div>

                </div>
            </div>
        </div>
    </section>


</asp:Content>
