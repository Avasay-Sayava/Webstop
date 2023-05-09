<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Webstop.Pages.Signin" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" href="wwwroot/css/sign.min.css"/>
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <div class="container" id="container">
		<div class="form-container sign-up-container">
			<form action="#">
				<h1>Create Account</h1>
				<div class="social-container">
					<a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
					<a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
					<a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
				</div>
				<span>or use your email for registration</span>
				<input type="text" placeholder="Name" />
				<input type="email" placeholder="Email" />
				<input type="password" placeholder="Password" />
				<button style="margin: 7px;">Sign Up</button>
			</form>
		</div>
		<div class="form-container sign-in-container">
			<form action="#">
				<h1>Sign in</h1>
				<div class="social-container">
					<a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
					<a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
					<a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
				</div>
				<span>or use your account</span>
				<input type="email" placeholder="Email" />
				<input type="password" placeholder="Password" />
				<a href="#">Forgot your password?</a>
				<button>Sign In</button>
			</form>
		</div>
		<div class="overlay-container">
			<div class="overlay">
				<div class="overlay-panel overlay-left">
					<h1>Welcome Back!</h1>
					<p>To keep connected with us please login with your personal info.</p>
					<button class="ghost" id="signIn">Sign In</button>
				</div>
				<div class="overlay-panel overlay-right">
					<h1>Hello There!</h1>
					<p>Enter your personal details to register to Webstop.</p>
					<button class="ghost" id="signUp">Sign Up</button>
				</div>
			</div>
		</div>
	</div>
	<script>
		const signUpButton = document.getElementById('signUp');
		const signInButton = document.getElementById('signIn');
		const container = document.getElementById('container');

		signUpButton.addEventListener('click', () => {
			container.classList.add("right-panel-active");
			history.replaceState({}, null, "Signup");
			document.title = "Sign Up - Webstop";
		});

		signInButton.addEventListener('click', () => {
			container.classList.remove("right-panel-active");
			history.replaceState({}, null, "Signin");
			document.title = "Sign In - Webstop";
		});
  </script>
</asp:Content>