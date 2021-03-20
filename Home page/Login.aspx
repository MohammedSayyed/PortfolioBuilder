<%@ Page Title="" Language="C#" MasterPageFile="~/Home page/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PortfolioBuilder.Home_page.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

         <style>
*, *:before, *:after {
  -moz-box-sizing: border-box;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
}

body {
  
  color: #384047;
}
label{
    font-size:large;
}
form {
  max-width: 500px;
  margin: 10px auto;
  padding: 10px 20px;
  background: #f4f7f8;
  border-radius: 8px;
}


input[type="text"],
input[type="password"],
input[type="date"],
input[type="datetime"],
input[type="email"],
input[type="number"],
input[type="search"],
input[type="tel"],
input[type="time"],
input[type="url"],
textarea,
select {
  background: rgba(255,255,255,0.1);
  border: none;
  font-size: 16px;
  height: auto;
  margin: 0;
  outline: 0;
  padding: 15px;
  width: 100%;
  background-color: #e8eeef;
  color: #8a97a0;
  box-shadow: 0 1px 0 rgba(0,0,0,0.03) inset;
  margin-bottom: 30px;
}

input[type="radio"],
input[type="checkbox"] {
  margin: 0 4px 8px 0;
}

select {
  padding: 6px;
  height: 32px;
  border-radius: 2px;
}

.button {
  padding: 19px 39px 18px 39px;
  color: #FFF;
  background-color: #e24313;
  font-size: 18px;
  text-align: center;
  font-style: normal;
  border-radius: 5px;
  width: 100%;
  border: 1px solid #b12e25;
  border-width: 1px 1px 3px;
  box-shadow: 0 -1px 0 rgba(255,255,255,0.1) inset;
  margin-bottom: 10px;
}

fieldset {
  margin-bottom: 30px;
  border: none;
}

legend {
  font-size: 1.4em;
  margin-bottom: 10px;
}

label {
  display: block;
  margin-bottom: 8px;
}

label.light {
  font-weight: 300;
  display: inline;
}

.number {
  background-color: #a8461f;
  color: #fff;
  height: 30px;
  width: 30px;
  display: inline-block;
  font-size: 0.8em;
  margin-right: 4px;
  line-height: 30px;
  text-align: center;
  text-shadow: 0 1px 0 rgba(255,255,255,0.2);
  border-radius: 100%;
}

#login {
  margin: 0 0 30px 0;
  text-align: center;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1 id="login">Login</h1>
         
           <label for="mail">Email:</label>
          <input type="email" runat="server" id="email" name="user_email" required>
          <%--<asp:TextBox ID="mail" runat="server" placeholder="E-Mail" required></asp:TextBox>--%>
          <label for="password">Password:</label>
         <input type="password" runat="server" id="password" name="user_password " required>
          <%--<asp:TextBox ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>--%>
        <a href="Signup.aspx"><input id="Signup" class="button" type="button" value="SignUp" /></a>
       <%--<button type="submit" class="button"  >Sign UUp</button>--%>
        <asp:Button ID="Login" CssClass="button" runat="server" Text="Login" OnClick="Button1_Click" />
    
</asp:Content>
