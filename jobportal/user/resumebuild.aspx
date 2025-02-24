<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.Master" AutoEventWireup="true" CodeBehind="resumebuild.aspx.cs" Inherits="jobportal.user.resumebuild" %>

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
                    <h2 class="contact-title text-center ">Build Resume</h2>
                </div>
                <div class="col-lg-8 mx-auto">

                    <div class="row">
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
                                <label>username</label>
                                <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Enter unique username" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" placeholder="Enter address" required="required" TextMode="MultiLine"></asp:TextBox>
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
                                <label>Country</label>
                                <asp:DropDownList ID="ddlcountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                                    AppendDataBoundItems="true" DataTextField="countryname" DataValueField="countryname">
                                    <asp:ListItem Value="0">Select country</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="country is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlcountry"></asp:RequiredFieldValidator>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT [countryname] FROM [country]"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="col-12 pt-4">
                            <h6>Education/Resume information</h6>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>10th percantage/grade</label>
                                <asp:TextBox ID="txttenth" runat="server" CssClass="form-control" placeholder="Ex:90%" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>12th percantage/grade</label>
                                <asp:TextBox ID="txttwelfth" runat="server" CssClass="form-control" placeholder="Ex:90%" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>Graduation with pointer/grade</label>
                                <asp:TextBox ID="txtgraduation" runat="server" CssClass="form-control" placeholder="Btech with 9.2 pointer" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>Post graduation</label>
                                <asp:TextBox ID="txtpostgrad" runat="server" CssClass="form-control" placeholder="Post graduation grade" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>PHD with percantage/grade</label>
                                <asp:TextBox ID="txtphd" runat="server" CssClass="form-control" placeholder="phd with grade" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>work experience</label>
                                <asp:TextBox ID="txtexperience" runat="server" CssClass="form-control" placeholder="enter your experience" required="required"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>Job profile/works on</label>
                                <asp:TextBox ID="txtwork" runat="server" CssClass="form-control" placeholder="job profile" required="required"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-12">
                            <div class="form-group">
                                <label>Resume</label>
                                <asp:FileUpload ID="furesume" runat="server" CssClass="form-control pt-2" ToolTip=".doc, .docx, .pdf extension only" />
                            </div>
                        </div>

                    </div>
                    <div class="form-group mt-3">
                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn" OnClick="btnupdate_Click" />

                    </div>

                </div>
            </div>
        </div>
    </section>

</asp:Content>
