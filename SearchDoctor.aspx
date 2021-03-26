<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchDoctor.aspx.cs" Inherits="SearchDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Search</li>
								</ol>
							</nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-12 col-lg-4 col-xl-3 theiaStickySidebar">
						
							<!-- Search Filter -->
							<div class="card search-filter">
								<div class="card-header">
									<h4 class="card-title mb-0">Select Specialist</h4>
								</div>
								<div class="card-body">
							<%--	<div class="filter-widget">
									<div class="cal-icon">
										<input type="text" class="form-control datetimepicker" placeholder="Select Date">
									</div>			
								</div>--%>
							<%--	<div class="filter-widget">
									<h4>Gender</h4>
									<div>
										<label class="custom_check">
											<input type="checkbox" name="gender_type" checked>
											<span class="checkmark"></span> Male Doctor
										</label>
									</div>
									<div>
										<label class="custom_check">
											<input type="checkbox" name="gender_type">
											<span class="checkmark"></span> Female Doctor
										</label>
									</div>
								</div>--%>
								<div class="filter-widget">
									
									<div>
									
												
											     <asp:CheckBoxList ID="chkSpecialization" runat="server">
                                                 </asp:CheckBoxList>
									
										
									</div>
									
								</div>
									<div class="btn-search">
                                        <asp:Button ID="btnSave" runat="server" Text="Search" OnClick="btnSave_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White" Width="200"  />
										<%--<button type="button" class="btn btn-block">Search</button>--%>
									</div>	
								</div>
							</div>
							<!-- /Search Filter -->
							
						</div>
						
						<div class="col-md-12 col-lg-8 col-xl-9">
                            		  <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate> 
							<!-- Doctor Widget -->
							<div class="card">
								<div class="card-body">
									<div class="doctor-widget">
										<div class="doc-info-left">
											<div class="doctor-img">
												<a href="doctor-profile.html">
													<asp:Image ID="Image2" class="img-fluid" runat="server" ImageUrl='<%#Eval("Doctor_Images") %>' />
												</a>
											</div>
											<div class="doc-info-cont">
												<h4 class="doc-name"><a href="#"><%#Eval("Doctor_Name") %></a></h4>
												<p class="doc-speciality"><%#Eval("Specialization") %></p>
<%--												<h5 class="doc-department"><img src="../assets/img/specialities/specialities-05.png" class="img-fluid" alt="Speciality">Dentist</h5>--%>
												<div class="rating">
													<i class="fas fa-star filled"></i>
													<i class="fas fa-star filled"></i>
													<i class="fas fa-star filled"></i>
													<i class="fas fa-star filled"></i>
													<i class="fas fa-star"></i>
													<span class="d-inline-block average-rating">(17)</span>
												</div>
												
												
											</div>
										</div>
										<div class="doc-info-right">
											<div class="clini-infos">
												<ul>
													<li><i class="far fa-thumbs-up"></i><%#Eval ("Doctor_Experience") %>Years</li>
													<li><i class="far fa-comment"></i> <%#Eval ("Doctor_Qualification") %></li>												
													<li><i class="far fa-money-bill-alt"></i> Rs.<%#Eval ("Doctor_fee") %> (Consulting Fee) </li>
												</ul>
											</div>
											<div class="clinic-booking">
                                                <a href="DoctorDetail.aspx?id=<%#Eval("id") %>" class="view-pro-btn">View Profile</a>											
                                               <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>' Visible = "false" />
                                                   <asp:LinkButton ID="lnkbook" Text="Book Now" runat="server" OnClick="BookDoctor" Visible="True"  class="apt-btn" />
											</div>
										</div>
									</div>
								</div>
							</div>
							<!-- /Doctor Widget -->

            </ItemTemplate>
        <FooterTemplate>
          
        </FooterTemplate>
    </asp:Repeater>
							
						</div>
				

</asp:Content>

