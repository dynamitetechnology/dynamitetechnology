<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AppointmentSchedule.aspx.cs" Inherits="AppointmentSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    	<nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Booking</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Booking</h2>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <asp:Repeater ID="d1" runat="server">
            <HeaderTemplate>
              
            </HeaderTemplate>
           <ItemTemplate>
    <div class="card">
								<div class="card-body">
									<div class="booking-doc-info">
										<a href="doctor-profile.html" class="booking-doc-img">
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("images") %>' />
											<%--<img src='../<%#Eval("images") %>' alt="">--%>
										</a>
										<div class="booking-info">
											<h4><a href="doctor-profile.html"><%#Eval("name") %></a></h4>
                                            <p class="doc-speciality"><%#Eval ("qly") %></p>
										<p class="doc-department"><%#Eval("exp") %></p>
											<div class="rating">
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star filled"></i>
												<i class="fas fa-star"></i>
												<span class="d-inline-block average-rating">35</span>
											</div>
											<p class="text-muted mb-0"><i class="far fa-money-bill-alt"></i> Rs.<%#Eval ("fee") %> (Consulting Fee)</p>
										</div>
									</div>
								</div>
							</div>
							
							<!-- Schedule Widget -->
						
							<!-- /Schedule Widget -->
							 </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
		<!-- Submit Section -->
   
												<div class="col-sm-12">
													<div class="form-group card-label">                                                        
														<asp:Label ID="lblOPdSchedule" runat="server" Text=""></asp:Label>
													</div>
												</div>	
										
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Date</label>
                                                        <asp:TextBox ID="txtDate"  runat="server"  CssClass="form-control"></asp:TextBox>
													    <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="txtDate" ErrorMessage="*"/>
													</div>
												</div>
											
								
    	<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Time(From)</label>
														   <asp:TextBox ID="txtTime" runat="server" CssClass="form-control" />
                                                           <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtTime" ErrorMessage="*"/>
													</div>
												</div>
    	<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Time(To)</label>
														   <asp:TextBox ID="txtTime1" runat="server" CssClass="form-control"  />
                                                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtTime1" ErrorMessage="*"/>
													</div>
												</div>
    <div class="col-md-6 col-sm-12">
        <div class="form-group submit-section proceed-btn text-right">
						<asp:Label ID="lblavailable" runat="server" Text='<%# Eval("id") %>' Visible = "false" />
                                  <asp:Button ID="b1" runat="server" Text="Proceed to Pay" OnClick="b1_Click" class=" form-control" BackColor="#01CAE4" ForeColor="White"  />							
							</div>
        </div>
    <br />
    <br />
                                    	<script src="assets/js/script.js"></script>
          
							<!-- /Submit Section -->
					
</asp:Content>

