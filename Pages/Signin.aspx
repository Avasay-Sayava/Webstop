<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Webstop.Pages.Signin" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <!-- Include custom CSS for sign-up page -->
  <link rel="stylesheet" href="wwwroot/css/sign.min.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <div class="container" id="container">
    <div class="form-container sign-up-container">
      <!-- Sign-up form -->
      <form action="Signup" method="post" id="up">
        <h1>Create Account</h1>
        <input name="up-name" id="up-name" type="text" placeholder="Full Name" />
        <label for="up-name">Invalid names. Your names must start with an uppercase letter and must contain more than 1 letter.</label>
        <input name="up-email" id="up-email" type="text" placeholder="Email" />
        <label for="up-email">Invalid email.</label>
        <asp:label id="exist" runat="server" for="up-email" ForeColor="Red">Email exists.</asp:label>
        <input name="up-password" id="up-password" type="password" placeholder="Password" />
        <label for="up-password">Invalid password. Your password must contain at least eight characters, one number, lowercase and uppercase letters, and a special character.</label>
        <input name="up-password-confirm" id="up-password-confirm" type="password" placeholder="Confirm Password" />
        <label for="up-password-confirm">Passwords don't match.</label>
        <input id="up-submit" class="button" value="Sign Up" type="button" />
        <dialog id="terms-and-license">
          <i class="fa fa-times" onclick="document.getElementById('terms-and-license').close()"></i>
          <h1>Terms & License</h1>
          <p>Amidst the chronicles of 2019, a technological apparatus fortuitously crossed my path,
          Visual Studio IDE is extolled as an epitome of programming's virtuosic aftermath.
          Alas! Its grandiloquent claims were swiftly eclipsed by a gnawing disillusionment,
          As an avalanche of glitches and cataclysmic crashes ensued, causing perturbation and lamentation.</p>

          <p>Oh, Visual Studio, what an intractable quandary to behold,
          The 2019 rendition, an arduous odyssey, alas, ill-foretold.
          Yet, even in the year 2022, when improvements sought their rightful space,
          Visual Studio IDE persistently cast lingering shadows, leaving no respite, no solace to embrace.</p>

          <p>Visual Studio IDE, the preceding iteration, exhibited a surfeit of deficiencies,
          A plethora of errors and inopportune malfunctions, quelling the ardor for fervent efficiencies.
          Compilation delays and performance languished at its very core,
          Plunging developers into depths of consternation, yearning for a panacea, an unknown shore.</p>

          <p>Within the realm of coding, tribulations ascended to precipitous heights,
          Nocturnal hours consumed in tireless debugging, amid relentless and formidable fights.
          Undeterred, we pressed forward, yearning for a transcendent grace,
          Only to be confronted with new setbacks in the labyrinthine labyrinth of the software's interface.</p>

          <p>Visual Studio IDE, the 2022 edition endeavored to assuage our collective distress,
          Seeking to ameliorate prior woes, though not entirely absolving the mess.
          Intermittent crashes and obstinate memory leaks continued to persist,
          A stark reminder that the pursuit of perfection in this realm remains an elusive tryst.</p>

          <p>Thus, as the dust settled and the echoes died,
          The truth remained, neither version could fully abide.
          Visual Studio's flaws persisted, like lingering shadows cast,
          A reminder that both renditions, in the end, faltered and passed.</p>
          <input type="submit" name="up-submit" value="Accept & Procced" />
          <input type="button" value="No, Nevermind" onclick="document.getElementById('terms-and-license').close()" />
        </dialog>
      </form>
    </div>
    <div class="form-container sign-in-container">
      <!-- Sign-in form -->
      <form action="Signin" method="post" id="in">
        <h1>Sign in</h1>
        <asp:label runat="server" id="error" for="in-submit">Invalid email or password</asp:label>
        <input name="in-email" id="in-email" type="text" placeholder="Email" />
        <input name="in-password" id="in-password" type="password" placeholder="Password" />
        <input name="in-submit" id="in-submit" class="button" value="Sign In" type="submit" />
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
