<%@ Page Title="Home" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Webstop.Pages.Home" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="/wwwroot/css/home.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <header>
    <h1>Welcome to Webstop!</h1>
    <p>Your ultimate destination for website grading and evaluation.</p>
  </header>

  <items>
    <div>
      <h2><strong>Trusted Evaluations</strong></h2><p>Our team of experienced professionals meticulously assesses each website using a thorough evaluation process. We take into account various factors, including security measures, privacy policies, content quality, user experience, and reliability. You can trust that our evaluations are accurate, unbiased, and backed by expertise.</p>
    </div>
    <div>
      <h2><strong>Comprehensive Criteria</strong></h2><p>We understand that website safety encompasses a wide range of aspects. That's why our evaluation process considers multiple parameters to provide you with a holistic view of each website's performance. We leave no stone unturned when it comes to assessing the safety and reliability of the sites we evaluate.</p>
    </div>
    <div>
      <h2> <strong>User-Centric Approach</strong></h2><p>At Webstop, your safety is our top priority. We strive to empower you with the information you need to make informed decisions. Our evaluations are designed to be user-friendly, presenting you with clear and concise ratings that allow you to quickly determine the safety level of a website.</p>
    </div>
    <div>
      <h2><strong>Regular Updates</strong></h2><p>The online landscape is constantly evolving, and so are websites. We understand the importance of providing you with the most current information. Our team at Webstop regularly updates our evaluations to ensure that you have access to the latest insights and can make decisions based on the most accurate data available.</p>
    </div>
    <div>
      <h2><strong>Community Engagement</strong></h2><p>Webstop is not just a grading platform; it's a community. We encourage users like you to actively participate by sharing your experiences, reporting any concerns, and engaging in discussions. Together, we can create a safer online environment and support each other in making informed choices.</p>
    </div>
  </items>

  <section>
    <h2>Join Webstop today!</h2>
    <p>Embark on a journey towards a safer online experience. With our reliable evaluations and community support, you can confidently explore the web, knowing that you have the information you need to stay safe.</p>
    <p>Sign up now and make informed decisions about the websites you visit!</p>
  </section>
</asp:Content>