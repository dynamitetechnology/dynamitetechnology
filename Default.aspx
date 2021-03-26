<!--#include file="head.aspx"-->
            <div class="main-wrapper">
		
			<!-- Header -->
				<!--#include file="Header.aspx"-->
			<!-- /Header -->
				
			<!-- Clinic and Specialities -->
		  
			<!-- Popular Section -->
			<section class="section section-doctor">
				<div class="container-fluid">
				   <div class="row">
						<div class="col-lg-4">
							<div class="section-header ">
								<h2>Book Our Doctor</h2>
								<p>At Dr.Singh’s City Hospital </p>
							</div>
							<div class="about-content">
                                <p>
                                    we take pride in the healthcare services we offer to patients suffering from Diabetes, heart problem, kidney, ENT, chest , asthma, allergie and various other diseases. We are one of the best hospitals in Kalamboli, Kamothe, Kharghar, Panvel, Taloja, Navi Mumbai to provide the healthcare services. We are committed to achieve excellence in health care by providing the latest technology for diagnostic and therapeutic services with a pleasant ambience.

The 50 bedded multi-specialty hospital is ideally located on the Mumbai-Panvel Highway in Kalamboli (Navi Mumbai).
                                </p>				
								<a href="#">Enquiry Now..</a>
							</div>
						</div>
						<div class="col-lg-8">
							<div class="doctor-slider slider">
                               
							  <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        
        </HeaderTemplate>
        <ItemTemplate>       
              
                <div class="profile-widget">
									<div class="doc-img">
										<a href="product_desc.aspx?id=<%#Eval("id") %>">
                                            	<asp:Image ID="Image2" class="img-fluid" runat="server" ImageUrl='<%#Eval("Doctor_Images") %>' />
										<%--	<img class="img-fluid" alt="" src="<%#Eval("Doctor_Images") %>">--%>
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
												<i class="fas fa-map-marker-alt"></i> <%#Eval ("Doctor_Qualification") %>
											</li>
											<li>
												<i class="far fa-clock"></i> <%#Eval ("Doctor_Experience") %>Years
											</li>
											<%--<li>
												<i class="far fa-money-bill-alt"></i> Rs.<%#Eval ("Doctor_fee") %>
												
											</li>--%>
										</ul>
										<div class="row row-sm">
											<div class="col-6">
												<a href="DoctorDetail.aspx?id=<%#Eval("id") %>" class="btn view-btn">View Profile</a>
											</div>
											<div class="col-6">                                            
											  <!-- <a   class="btn book-btn" href="AppointmentSchedule.aspx?id=">Book Now</a>        -->      
												<a   class="btn book-btn" href="AppointmentSchedule.aspx?id=<%# Eval("id") %>">Book Now</a> 
												
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
				   </div>
				</div>
			</section>
			<!-- /Popular Section -->
		   
		   <!-- Availabe Features -->
		   <section class="section section-features">
				<div class="container-fluid">
				   <div class="row">
						<div class="col-md-5 features-img">
							<img src="assets/img/features/feature.png" class="img-fluid" alt="Feature">
						</div>
						<div class="col-md-7">
							<div class="section-header">	
								<h2 class="mt-2">Availabe Features in Our Clinic</h2>
								<p>A full range of hospital facilities are very critical to provide best healthcare to patients. Healthcare facilities management is important for medical facilities. We have following best hospital facilities to handle every healthcare situation </p>
							</div>	
							<div class="features-slider slider">
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-01.jpg" class="img-fluid" alt="Feature">
									<p>OPD</p>
								</div>
								<!-- /Slider Item -->
								
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-02.jpg" class="img-fluid" alt="Feature">
									<p>Diagnostic Facility</p>
								</div>
								<!-- /Slider Item -->
								
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-03.jpg" class="img-fluid" alt="Feature">
									<p>ICU</p>
								</div>
								<!-- /Slider Item -->
								
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-04.jpg" class="img-fluid" alt="Feature">
									<p>Laboratory</p>
								</div>
								<!-- /Slider Item -->
								
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-05.jpg" class="img-fluid" alt="Feature">
									<p>Operation</p>
								</div>
								<!-- /Slider Item -->
								
								<!-- Slider Item -->
								<div class="feature-item text-center">
									<img src="assets/img/features/feature-06.jpg" class="img-fluid" alt="Feature">
									<p>Medical</p>
								</div>
								<!-- /Slider Item -->
							</div>
						</div>
				   </div>
				</div>
			</section>		
			<!-- Availabe Features -->
			
			<!-- Footer -->
			<!--#include file="footer.aspx"-->
			<!-- /Footer -->
		<!--#include file="footerend.aspx"-->