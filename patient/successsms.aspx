<%@ Page Title="" Language="C#" MasterPageFile="~/patient/PatientMaster.master" AutoEventWireup="true" CodeFile="successsms.aspx.cs" Inherits="success" %>

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
    <div class="container-fluid">
				
					<div class="row justify-content-center">
						<div class="col-lg-6">
						
							<!-- Success Card -->
							<div class="card success-card">
								<div class="card-body">
									<div class="success-cont">
										<i class="fas fa-check"></i>
										<h3>Appointment booked Successfully!</h3>
										<p>Appointment booked with <strong><asp:Label ID="lbldoctor" runat="server" Text='' /></strong><br> on <strong><asp:Label ID="lblAppointDate" runat="server" Text='' /></strong></p>
										<%--<a href="Invoice.aspx" class="btn btn-primary view-inv-btn">View Invoice</a>--%>
									</div>
								</div>
							</div>
							<!-- /Success Card -->
							
						</div>
					</div>
        </div>
</asp:Content>

