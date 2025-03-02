<%@ Page Title="" Language="C#" MasterPageFile="~/user/usermaster.Master" AutoEventWireup="true" CodeBehind="jobdetails.aspx.cs" Inherits="jobportal.user.jobdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>

        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="assets/img/hero/about.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                <h2><%# jobtitle %></h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="lblmsg" runat="server" Visible="false"></asp:Label>
        </div>



        <!-- job post company Start -->
        <div class="job-post-company pt-120 pb-120">
            <div class="container">
                <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">
                    <ItemTemplate>
                        <div class="row justify-content-between">
                            <!-- Left Content -->
                            <div class="col-xl-7 col-lg-8">
                                <!-- job single -->
                                <div class="single-job-items mb-50">
                                    <div class="job-items">
                                        <div class="company-img company-img-details">
                                            <a href="#">
                                                <img width="80" src="<%# GetImageUrl(Eval("companyimage")) %>" alt=""></a>
                                        </div>
                                        <div class="job-tittle">
                                            <a href="#">
                                                <h4><%# Eval("title")  %></h4>
                                            </a>
                                            <ul>
                                                <li><%# Eval("companyname")  %></li>
                                                <li><i class="fas fa-map-marker-alt"></i><%# Eval("state")  %>, <%# Eval("country")  %></li>
                                                <li><%# Eval("salary")  %></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!-- job single End -->

                                <div class="job-post-details">
                                    <div class="post-details1 mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Job Description</h4>
                                        </div>
                                        <p><%# Eval("description")  %></p>
                                    </div>
                                    <div class="post-details2  mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Required Knowledge, Skills, and Abilities</h4>
                                        </div>
                                        <ul>
                                            <li><%# Eval("specialization")  %></li>
                                            <%-- <li>Mobile Applicationin iOS/Android/Tizen or other platform</li>
                   <li>Research and code , libraries, APIs and frameworks</li>
                   <li>Strong knowledge on software development life cycle</li>
                   <li>Strong problem solving and debugging skills</li>--%>
                                        </ul>
                                    </div>
                                    <div class="post-details2  mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Education + Experience</h4>
                                        </div>
                                        <ul>
                                            <li><%# Eval("qualification")  %></li>
                                            <li><%# Eval("experience")  %></li>
                                            <%-- <li>Ecommerce website design experience</li>
                   <li>Familiarity with mobile and web apps preferred</li>
                   <li>Experience using Invision a plus</li>--%>
                                        </ul>
                                    </div>
                                </div>

                            </div>
                            <!-- Right Content -->
                            <div class="col-xl-4 col-lg-4">
                                <div class="post-details3  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Job Overview</h4>
                                    </div>
                                    <ul>
                                        <li>Posted date : <span><%# DataBinder.Eval(Container.DataItem,"createdate","{0:dd MMMM yyyy}")  %></span></li>
                                        <li>Location : <span><%# Eval("state")  %></span></li>
                                        <li>Vacancy : <span><%# Eval("numofpost")  %></span></li>
                                        <li>Job nature : <span><%# Eval("jobtype")  %></span></li>
                                        <li>Salary :  <span><%# Eval("salary")  %></span></li>
                                        <li>last date : <span><%# DataBinder.Eval(Container.DataItem, "lastdatetoapply", "{0:dd MMMM yyyy}") %>
                                        </span></li>
                                    </ul>
                                    <div class="apply-btn2">
                                        <%--<a href="#" class="btn">Apply Now</a>--%>
                                       <asp:LinkButton ID="lblapply" runat="server" CommandName="applyjob" CommandArgument='<%# Eval("jobid") %>' CssClass="btn btn-primary">Apply Now</asp:LinkButton>

                                    </div>
                                </div>
                                <div class="post-details4  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Company Information</h4>
                                    </div>
                                    <span><%# Eval("companyname")  %></span>
                                    <p><b> Address : </b><%# Eval("address")  %></p>
                                    <ul>
                                        <li>Name: <span><%# Eval("companyname")  %> </span></li>
                                        <li>Web : <span><%# Eval("website")  %></span></li>
                                        <li>Email: <span><%# Eval("email")  %></span></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>

            </div>
        </div>
        <!-- job post company End -->

    </main>
</asp:Content>
