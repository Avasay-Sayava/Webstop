<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Webstop.Pages.Signup" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <!-- Include custom CSS for sign-up page -->
  <link rel="stylesheet" href="wwwroot/css/sign.min.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <div class="container right-panel-active" id="container">
    <div class="form-container sign-up-container">
      <!-- Sign-up form -->
      <form action="Signup" method="post" id="up">
        <h1>Create Account</h1>
        <div class="social-container">
          <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
          <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
          <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
        </div>
        <span>or use your email for registration</span>
        <input name="up-name" id="up-name" type="text" placeholder="Full Name" />
        <label for="up-name">Invalid names. Your names must start with an uppercase letter and must contain more than 1 letter.</label>
        <input name="up-email" id="up-email" type="text" placeholder="Email" />
        <label for="up-email">Invalid email.</label>
        <asp:label id="exist" runat="server" for="up-email" ForeColor="Red">Email exists.</asp:label>
        <input name="up-password" id="up-password" type="password" placeholder="Password" />
        <label for="up-password">Invalid password. Your password must contain at least eight characters, one number, lowercase and uppercase letters, and a special character.</label>
        <input name="up-password-confirm" id="up-password-confirm" type="password" placeholder="Confirm Password" />
        <label for="up-password-confirm">Passwords don't match.</label>
        <input name="up-submit" id="up-submit" class="button" value="Sign Up" type="submit" />
      </form>
    </div>
    <div class="form-container sign-in-container">
      <!-- Sign-in form -->
      <form action="Signin" method="post" id="in">
        <h1>Sign in</h1>
        <div class="social-container">
          <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
          <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
          <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
        </div>
        <span>or use your account</span>
        <asp:label runat="server" id="error" for="in-submit">Invalid email or password</asp:label>
        <input name="in-email" id="in-email" type="text" placeholder="Email" />
        <input name="in-password" id="in-password" type="password" placeholder="Password" />
        <input name="in-submit" id="in-submit" class="button" value="Sign In" type="submit" />
        <a href="#">Forgot your password?</a>
      </form>
    </div>
    <div class="overlay-container">
      <div class="overlay">
        <div class="overlay-panel overlay-left">
          <h1>Welcome Back!</h1>
          <p>To keep connected with us, please login with your personal info.</p>
          <button class="ghost" id="signin">Sign In</button>
        </div>
        <div class="overlay-panel overlay-right">
          <h1>Hello There!</h1>
          <p>Enter your personal details to register with Webstop.</p>
          <button class="ghost" id="signup">Sign Up</button>
        </div>
      </div>
    </div>
  </div>
  <!-- Include sign.js script -->
  <script type="text/javascript" src="Scripts/Sign.js"></script>
</asp:Content>
