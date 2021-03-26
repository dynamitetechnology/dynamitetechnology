<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendcall.aspx.cs" Inherits="patient_Attendcall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
		<title>Doctor Call</title>
		<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0"/>
		
		<!-- Favicons -->
		<link href="../assets/img/favicon.png" rel="icon"/>
		
		<!-- Bootstrap CSS -->
		<link rel="stylesheet" href="../assets/css/bootstrap.min.css"/>
		
		<!-- Fontawesome CSS -->
		<link rel="stylesheet" href="../assets/plugins/fontawesome/css/fontawesome.min.css"/>
		<link rel="stylesheet" href="../assets/plugins/fontawesome/css/all.min.css"/>
		
		<!-- Main CSS -->
		<link rel="stylesheet" href="../assets/css/style.css"/>
</head>
<body>
   
           <div class="main-wrapper">
		
			<!-- Header -->
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
						<a href="#" class="navbar-brand logo">
							<img src="../assets/img/logo.png" class="img-fluid" alt="Logo">
						</a>
					</div>
					<div class="main-menu-wrapper">
						<div class="menu-header">
							<a href="#" class="menu-logo">
								<img src="../assets/img/logo.png" class="img-fluid" alt="Logo">
							</a>
							<a id="menu_close" class="menu-close" href="javascript:void(0);">
								<i class="fas fa-times"></i>
							</a>
						</div>
						<ul class="main-nav">
							<li>
								<a href="Pdashboard.aspx">Dashboard</a>
							</li>
							
						</ul>
					</div>		 
			<%--		<ul class="nav header-navbar-rht">
						<li class="nav-item contact-item">
							<div class="header-contact-img">
								<i class="far fa-hospital"></i>							
							</div>
							<div class="header-contact-detail">
								<p class="contact-header">Contact</p>
								<p class="contact-info-header"> +1 315 369 5943</p>
							</div>
						</li>
						
						<!-- User Menu -->
						<li class="nav-item dropdown has-arrow logged-item">
							<a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown">
								<span class="user-img">
									<img class="rounded-circle" src="../assets/img/patients/patient.jpg" width="31" alt="Ryan Taylor">
								</span>
							</a>
							<div class="dropdown-menu dropdown-menu-right">
								<div class="user-header">
									<div class="avatar avatar-sm">
										<img src="../assets/img/patients/patient.jpg" alt="User Image" class="avatar-img rounded-circle">
									</div>
									<div class="user-text">
										<h6>Richard Wilson</h6>
										<p class="text-muted mb-0">Patient</p>
									</div>
								</div>
								<a class="dropdown-item" href="patient-dashboard.html">Dashboard</a>
								<a class="dropdown-item" href="profile-settings.html">Profile Settings</a>
								<a class="dropdown-item" href="login.html">Logout</a>
							</div>
						</li>
						<!-- /User Menu -->
						
					</ul>--%>
				</nav>
			</header>
			<!-- /Header -->
			
			<!-- Page Content -->
			<div class="content">
				<div class="container-fluid">
				
								<iframe id="myIframe" width="360" height="600" scrolling="auto" allow="microphone; camera" ></iframe>
						
					
				</div>

			</div>		
			<!-- /Page Content -->
   
			
		   
		</div>
    <script src="../assets/js/jquery.min.js"></script>
		
		<!-- Bootstrap Core JS -->
		<script src="../assets/js/popper.min.js"></script>
		<script src="../assets/js/bootstrap.min.js"></script>
		
		<!-- Custom JS -->
		<script src="../assets/js/script.js"></script>
       
    <script src="../assets/js/jquery.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
    
   <%--   <iframe
        src="https://tokbox.com/embed/embed/ot-embed.js?embedId=127d555f-ba9b-4ad4-aacc-91e968b880b8&room=DEFAULT_ROOM&iframe=true"
        width="800px"
        height="640px"
        scrolling="auto"
        allow="microphone; camera"
      ></iframe>--%>
    
    <script type="text/javascript">    
        $(document).ready(function () {
            debugger;
             var url = window.location.search;
            url = url.replace("?", '');
            url = url.replace("id=", '');
            var roomid = "Room" + url;
            var embed = "127d555f-ba9b-4ad4-aacc-91e968b880b8";
            var frame = "true";    
            $('#myIframe').attr('src', "https://tokbox.com/embed/embed/ot-embed.js?embedId=" + embed + "&room=" + roomid + "&iframe="+frame);
        })          
    </script>
</body>
</html>
