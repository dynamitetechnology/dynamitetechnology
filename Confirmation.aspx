<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Confirmation.aspx.cs" Inherits="Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <nav aria-label="breadcrumb" class="page-breadcrumb">
								<ol class="breadcrumb">
									<li class="breadcrumb-item"><a href="index-2.html">Home</a></li>
									<li class="breadcrumb-item active" aria-current="page">Checkout</li>
								</ol>
							</nav>
							<h2 class="breadcrumb-title">Checkout</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="col-md-7 col-lg-8">
							<div class="card">
								<div class="card-body">
								
								
										<!-- Personal Information -->
										<div class="info-widget">
											<h4 class="card-title">Personal Information</h4>
											<div class="row">
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Patient Name</label>
                                                         <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
														  <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="txtName" ErrorMessage="*"/>
													</div>
												</div>
											
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Email</label>
														<asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
													</div>
												</div>
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Phone</label>
														<asp:TextBox ID="txtPhone" runat="server" class="form-control" ReadOnly></asp:TextBox>
													</div>
												</div>
                                                	<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Age</label>
														<asp:TextBox ID="txtAge" runat="server" class="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="txtAge" ErrorMessage="*"/>
													</div>
												</div>
											</div>
											<div class="row">
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Gender</label>													
                                                        <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                                                            <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                            <asp:ListItem Text="FeMale" Value="FeMale"></asp:ListItem>
                                                        </asp:DropDownList>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="ddlGender" ErrorMessage="*" InitialValue="Select"/>
													</div>
												</div>
											
												<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Blood Group</label>
														<asp:DropDownList ID="ddlBloodgroup" runat="server" class="form-control">
                                                             <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                                                         <asp:ListItem Text="O+" Value="O+"></asp:ListItem>
                                                            <asp:ListItem Text="AB" Value="AB"></asp:ListItem>
                                                            </asp:DropDownList>
                                                         <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="ddlBloodgroup" ErrorMessage="*" InitialValue="Select"/>
													</div>
												</div>
                                                	<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>Address</label>
														<asp:TextBox ID="txtAddress" runat="server" class="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator7" controltovalidate="txtAddress" ErrorMessage="*"/>
													</div>
												</div>
                                                	<div class="col-md-6 col-sm-12">
													<div class="form-group card-label">
														<label>City</label>
														<asp:TextBox ID="txtCity" runat="server" class="form-control"></asp:TextBox>
                                                          <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator6" controltovalidate="txtCity" ErrorMessage="*"/>
													</div>
												</div>
												<div class="col-sm-12">
													<div class="form-group card-label">
														<label>Health Problem</label>
														<asp:TextBox ID="txtProblem" runat="server" class="form-control" CausesValidation="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ControlToValidate="txtProblem" runat="server" ID="valFirstName"  ErrorMessage="Problem is required." Text="*" />
													</div>
												</div>
                                                <div class="col-sm-12">
													<div class="form-group card-label">
                                                        <asp:CheckBox ID="CheckBox1" runat="server"  Text="All Information given by me are correct and if anything found incorrect then I will be responsible"/>
													</div>
												</div>
											</div>
                                            	<div class="submit-section mt-4">
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                    <asp:Label ID="lblId" runat="server" Text='' Visible = "false" />
                                                     <asp:Button ID="b1" runat="server" Text="Confirm and Pay" onclick="b1_Click" CausesValidation="true" class=" form-control" BackColor="#01CAE4" ForeColor="White" />
												<%--<button type="submit" class="btn btn-primary submit-btn">Confirm and Pay</button>--%>
											</div>
										</div>
										<!-- /Personal Information -->
										
									
								</div>
							</div>
							
						</div>
								  <asp:Repeater ID="d1" runat="server">
            <HeaderTemplate>
              
            </HeaderTemplate>
           <ItemTemplate>
						<div class="col-md-5 col-lg-4 theiaStickySidebar">
						
							<!-- Booking Summary -->
							<div class="card booking-card">
								<div class="card-header">
									<h4 class="card-title">Booking Summary</h4>
								</div>
								<div class="card-body">
								
									<!-- Booking Doctor Info -->
									<div class="booking-doc-info">
										<a href="doctor-profile.html" class="booking-doc-img">
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("images") %>' />
											<%--<img src='../<%#Eval("images") %>' alt="User Image">--%>
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
											<div class="clinic-details">
											<%--	<p class="doc-location"><i class="fas fa-map-marker-alt"></i> Newyork, USA</p>--%>
											</div>
										</div>
									</div>
									<!-- Booking Doctor Info -->
									
									<div class="booking-summary">
										<div class="booking-item-wrap">
											<ul class="booking-date">
										         <li>Appoint.Date <span><%#Eval ("Adate") %></span></li>
												<li>Time-Slot <span><%#Eval ("ftime") %>-<%#Eval ("Ttime") %></span></li>
											</ul>
                                              <ul class="booking-date">
										         <li>Last Visit Date <span><%#Eval ("LastVisit") %></span></li>												
											</ul>
											<ul class="booking-fee">
											<li>Consulting Fee <span>Rs.<%#Eval ("fee") %></span></li>
												<li>Booking Fee <span>Rs.0</span></li>
											</ul>
											<div class="booking-total">
												<ul class="booking-total-list">
													<li>
														<span>Total</span>
														<span class="total-cost">Rs.<%#Eval ("fee") %></span>
													</li>
												</ul>
											</div>
										</div>
                                      
									</div>
								</div>
							</div>
							<!-- /Booking Summary -->
							
						</div>
                   		 </ItemTemplate>
            <FooterTemplate>
           
            </FooterTemplate>
        </asp:Repeater>
</asp:Content>

