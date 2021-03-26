<form ID="form1" runat="server">
    			<header class="header">
				<nav class="navbar navbar-expand-lg header-nav">
					<div class="navbar-header">
						<a id="mobile_btn" href="javascript:void(0);">
							<span class="bar-icon">
								<span></span>
								<span></span>
								<span></span>
							</span>
						</a>
						<a href="Default.aspx" class="navbar-brand logo">
							<img src="assets/img/logo.png" class="img-fluid" alt="Logo">
						</a>
					</div>
					<div class="main-menu-wrapper">
						<div class="menu-header">
							<a href="Default.aspx" class="menu-logo">
								<img src="assets/img/logo.png" class="img-fluid" alt="Logo">
							</a>
							<a id="menu_close" class="menu-close" href="javascript:void(0);">
								<i class="fas fa-times"></i>
							</a>
						</div>
						<ul class="main-nav">
							<li class="active">
								<a href="Default.aspx">Home</a>
							</li>
                              <li>
								<a href="SearchDoctor.aspx">Search Doctor</a>
							</li>
						
							<li class="has-submenu">
								<a href="#">Logins <i class="fas fa-chevron-down"></i></a>
								<ul class="submenu"> 
                                    <li><a href="/Patientlogin.aspx">Patient Login</a></li>
									<li><a href="doctor/Doctorlogin.aspx">Doctor Login</a></li>
									<li><a href="admin/Adminlogin.aspx">Admin Login</a></li>								
								</ul>
							</li>            
                        <%
                            if (Session["user"] == null)
                            {
                        %>
							<li class="login-link">
								<a href="Patientlogin.aspx">Login / Signup</a>
							</li>
                            <%
                            }
                            else
                            {
                        %>
							<li class="login-link">
								<a href="/logout.aspx">Logout</a>
							</li>
                            <%
                            }
                                            %>
						</ul>		 
					</div>		 
					<ul class="nav header-navbar-rht">
                           <% if (Session["user"] == null)
                            {
                        %>
						<li class="nav-item contact-item">
							<div class="header-contact-img">
								<i class="far fa-hospital"></i>							
							</div>
							<div class="header-contact-detail">
								<p class="contact-header">Contact</p>
								<p class="contact-info-header"> +91 8115873303</p>
							</div>
						</li>
						<li class="nav-item">
							<a class="nav-link header-login" href="Patientlogin.aspx">login / Signup </a>
						</li>
                           <%
                            }
                            else
                            {
                        %>
                        <li class="nav-item contact-item">
							<div class="header-contact-img">
								<i class="far fa-hospital"></i>							
							</div>
							<div class="header-contact-detail">
								<p class="contact-header">Contact</p>
								<p class="contact-info-header"> +91 8115873303</p>
							</div>
						</li>
                        <li class="nav-item">
							<a class="nav-link header-login" href="/logout.aspx">logout</a>
						</li>
                          <%
                            }
                           %>
					</ul>
				</nav>
			</header>
</form>