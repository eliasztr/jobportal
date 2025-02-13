<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminmaster.Master" AutoEventWireup="true" CodeBehind="newjob.aspx.cs" Inherits="jobportal.admin.newjob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container pt-4 pb-4">
            <div>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>

            </div>
            <div>
                <h3 class="text-center">Add job</h3>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtjobtitle" style="font-weight: 600">job title </label>
                        <asp:TextBox ID="txtjobtitle" runat="server" CssClass="form-control" placeholder="Ex. web developer,app developer..."></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="txtnumofposts" style="font-weight: 600">number of posts </label>
                        <asp:TextBox ID="txtnumofposts" runat="server" CssClass="form-control" placeholder="enter number of position" TextMode="Number"></asp:TextBox>

                    </div>
                </div>

                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-12 pt-3">
                        <label for="txtjobtitle" style="font-weight: 600">description </label>
                        <asp:TextBox ID="txtdescription" runat="server" CssClass="form-control" placeholder="enter job description" TextMode="MultiLine"></asp:TextBox>

                    </div>

                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtqualification" style="font-weight: 600">Qualification/Education Required </label>
                        <asp:TextBox ID="txtqualification" runat="server" CssClass="form-control" placeholder="Ex. MCA,Btech,MBA..."></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="txtexperience" style="font-weight: 600">experience required </label>
                        <asp:TextBox ID="txtexperience" runat="server" CssClass="form-control" placeholder="Ex: 2years,1year..."></asp:TextBox>

                    </div>
                </div>

                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtspecialization" style="font-weight: 600">specialization Required </label>
                        <asp:TextBox ID="txtspecialization" runat="server" CssClass="form-control" placeholder="enter specialization " TextMode="MultiLine"></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="txtlastdate" style="font-weight: 600">last date to apply </label>
                        <asp:TextBox ID="txtlastdate" runat="server" CssClass="form-control" placeholder="enter last date to apply" TextMode="Date"></asp:TextBox>

                    </div>
                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtsalary" style="font-weight: 600">salary </label>
                        <asp:TextBox ID="txtsalary" runat="server" CssClass="form-control" placeholder="enter salary"></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="ddljobtype" style="font-weight: 600">job type </label>
                        <asp:DropDownList ID="ddljobtype" runat="server" CssClass="form-control">
                            <asp:ListItem Value="0">Select job type</asp:ListItem>
                            <asp:ListItem>full time</asp:ListItem>
                            <asp:ListItem>part time</asp:ListItem>
                            <asp:ListItem>remote </asp:ListItem>
                            <asp:ListItem>freelance</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="job type is required" ForeColor="Red" ControlToValidate="ddljobtype" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtcompany" style="font-weight: 600">company/organization name </label>
                        <asp:TextBox ID="txtcompany" runat="server" CssClass="form-control" placeholder="enter company/organization name"></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="ddljobtype" style="font-weight: 600">company/organization logo </label>
                        <asp:FileUpload ID="fucompanylogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only" />

                    </div>
                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtwebsite" style="font-weight: 600">website </label>
                        <asp:TextBox ID="txtwebsite" runat="server" CssClass="form-control" placeholder="enter website " TextMode="Url"></asp:TextBox>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="txtemail" style="font-weight: 600">Email</label>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="enter Email" TextMode="Email"></asp:TextBox>

                    </div>
                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="txtaddress" style="font-weight: 600">address </label>
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" placeholder="enter work location"></asp:TextBox>

                    </div>

                </div>
                <div class="row mr-lg-5 ml-lg-5 mb-3">
                    <div class="col-md-6 pt-3">
                        <label for="ddlcountry" style="font-weight: 600">country </label>
                        <asp:DropDownList ID="ddlcountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                            AppendDataBoundItems="true" DataTextField="countryname" DataValueField="countryname">
                            <asp:ListItem Value="0">Select country</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="country is required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlcountry"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT [countryname] FROM [country]"></asp:SqlDataSource>

                    </div>
                    <div class="col-md-6 pt-3">
                        <label for="txtstate" style="font-weight: 600">state</label>
                        <asp:TextBox ID="txtstate" runat="server" CssClass="form-control" placeholder="enter state" ></asp:TextBox>

                    </div>
                </div>

                 <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
     <div class="col-md-3 col-md-offset-2 mb-3">
         <asp:Button ID="btnaddjob" runat="server" Text="add job" OnClick="btnaddjob_Click" CssClass="btn btn-primary btn-block " BackColor="#7200cf" />
     </div>
            </div>
              
   
   </div>

        </div>

    </div>
</asp:Content>
