<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="MakeAppointment.aspx.cs" Inherits="patient_MakeAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Favourites</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Favourites</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="col-md-5 col-lg-4 col-xl-3 theiaStickySidebar">
							<div class="profile-sidebar">
								<div class="widget-profile pro-widget-content">
									<div class="profile-info-widget">
										<a href="#" class="booking-doc-img">
											<asp:Image ID="Image2" runat="server" />
										</a>
										<div class="profile-det-info">
											<h3><asp:Label ID="lblname" runat="server" Text="Label"></asp:Label></h3>
											<div class="patient-details">
												<h5><i class="fas fa-mobile"></i><asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label></h5>
												<h5 class="mb-0"><i class="fas fa-map-marker-alt"></i><asp:Label ID="lbladdress" runat="server" Text="Label"></asp:Label></h5>
											</div>
										</div>
									</div>
								</div>
								<div class="dashboard-widget">
									<nav class="dashboard-menu">
										<ul>
											<li class="active">
												<a href="Pdashboard.aspx">
													<i class="fas fa-columns"></i>
													<span>Dashboard</span>
												</a>
											</li>
											<li>
												<a href="MakeAppointment.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Quick Appointment</span>
												</a>
											</li>
                                            		<li>
												<a href="Prescriptiondash.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Prescription</span>
												</a>
											</li>
                                               <li>
												<a href="MedicineOrderDetail.aspx">
													<i class="fas fa-bookmark"></i>
													<span>Medicine Order Detail</span>
												</a>
											</li>
										<%--	<li>
												<a href="SendMessage.aspx">
													<i class="fas fa-comments"></i>
													<span>Message</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="Inbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Inbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>
                                            	<li>
												<a href="Outbox.aspx">
													<i class="fas fa-comments"></i>
													<span>Outbox</span>
													<small class="unread-msg">23</small>
												</a>
											</li>--%>
											<li>
												<a href="Profile.aspx">
													<i class="fas fa-user-cog"></i>
													<span>Profile Settings</span>
												</a>
											</li>
											<li>
												<a href="ChangePassword.aspx">
													<i class="fas fa-lock"></i>
													<span>Change Password</span>
												</a>
											</li>
											<li>
												<a href="/logout.aspx">
													<i class="fas fa-sign-out-alt"></i>
													<span>Logout</span>
												</a>
											</li>
										</ul>
									</nav>
								</div>

							</div>
						</div>
						<div class="col-md-7 col-lg-8 col-xl-9">
							<div class="row row-grid">
                                                            		  <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate> 
								<div class="col-md-6 col-lg-4 col-xl-3">
									<div class="profile-widget">
										<div class="doc-img">
											<a href="#">
											<asp:Image ID="Image2" class="img-fluid" runat="server" ImageUrl='<%#Eval("Doctor_Images") %>' />
											</a>
											<a href="javascript:void(0)" class="fav-btn">
												<i class="far fa-bookmark"></i>
											</a>
										</div>
										<div class="pro-content">
											<h3 class="title">
												<a href="#"><%#Eval("Doctor_Name") %></a> 
												<i class="fas fa-check-circle verified"></i>
											</h3>
											<p class="speciality"><%#Eval("Specialization") %></p>
											<div class="rating">
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<span class="d-inline-block average-rating">(17)</span>
											</div>
											<ul class="available-info">
												<li>
													<li><i class="far fa-thumbs-up"></i><%#Eval ("Doctor_Experience") %>Years</li>
                                                    
												</li>
												<li>
													<li><i class="far fa-comment"></i> <%#Eval ("Doctor_Qualification") %></li>	
												</li>
												<li>
													<i class="far fa-money-bill-alt"></i> Rs.<%#Eval ("Doctor_fee") %> (Consulting Fee) 
												</li>
											</ul>
											<div class="row row-sm">
												<div class="col-6">
													<a href="/DoctorDetail.aspx?id=<%#Eval("id") %>" class="btn view-btn">View Profile</a>
												</div>
												<div class="col-6">
													    <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>' Visible = "false" />
                                                   <asp:LinkButton ID="lnkbook" Text="Book Now" runat="server" OnClick="BookDoctor" Visible="True"  class="apt-btn" />
												</div>
											</div>
										</div>
									</div>
								</div>
								
								
							    </ItemTemplate>
        <FooterTemplate>
          
        </FooterTemplate>
    </asp:Repeater>			
								
								
							</div>
						</div>
					

</asp:Content>

