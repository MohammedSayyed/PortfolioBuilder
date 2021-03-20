<%@ Page Title="" Language="C#" MasterPageFile="~/Home page/Site1.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="PortfolioBuilder.Home_page.Signup" %>
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

form {
  max-width: 500px;
  margin: 10px auto;
  padding: 10px 20px;
  background: #f4f7f8;
  border-radius: 8px;
}

.h1 {
  margin: 0 0 30px 0;
  text-align: center;
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
select, .file {
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
  font-size:large;
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



@media screen and (min-width: 480px) {

  form {
    max-width: 800px;
  }
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
     <h1 class="h1">Sign Up</h1>
        <fieldset>
          
          <label for="name">Full Name:</label>
          <input runat="server" type="text" id="name" name="user_name" required>

          <label>Gender:</label>
          <input runat="server" type="radio" id="Male" value="Male" name="Gender" checked ><label for="Male" class="light">Male</label><br>
          <input runat="server" type="radio" id="Female" value="Female" name="Gender"><label for="Female" class="light">Female</label>
          
          <br /><br />
          <label>Date of Birth:</label>            
          <input type="date" id="dob" runat="server" required><br>

        <label for="job">Current Job Role:</label>
        <select id="job_role" name="user_job">
          <optgroup label="Web">
            <option value="Front-End Developer">Front-End Developer</option>
            <option value="PHP Developer">PHP Developer</option>
            <option value="Python Developer">Python Developer</option>
            <option value="Rails Developer"> Rails Developer</option>
            <option value="Web Designer">Web Designer</option>
            <option value="WordPress Developer">WordPress Developer</option>
            <option value="Freelancer">Freelancer</option>
            <option value="UI/UX Developer"  >UI/UX Developer</option>
            
          </optgroup>
          <optgroup label="Mobile">
            <option value="Androild Developer">Androild Developer</option>
            <option value="iOS Developer">iOS Developer</option>
            <option value="Mobile Designer">Mobile Designer</option>
          </optgroup>
         
        </select>
          
          <label for="mail">Email:</label>
          <input runat="server" type="email" id="mail" name="user_email" required>

          <label for="password">Password:</label>
          <input runat="server" type="password" id="password1" name="user_password " required>

          <label for="Repeat Password">Repeat Password:</label>
          <input runat="server" id="password2" type="password" name="psw-repeat" required>
          <label for="address">Address:</label>
          <input runat="server" type="text" id="Address" name="Address" required>
          <label for="phone">Phone:</label>
          <input runat="server" type="text" id="phone" name="phone" required>

          <h1 class="h1">Info</h1>
           <label for="About">About Yourself:</label>
          <input runat="server" type="text" id="about" name="about" >
          <label for="Website">Your Website:</label>
          <input runat="server" type="text" id="website" name="website" >

          <label for="Skills">Skills:</label>
           <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Text="HTML 5" Value="HTML 5" />
            <asp:ListItem Text="Python" Value="Python" />
            <asp:ListItem Text="CSS3" Value="CSS3"/>
            <asp:ListItem Text="PHP" Value="PHP"/>
            <asp:ListItem Text="JAVA" Value="JAVA" />
          </asp:CheckBoxList>
            <br/>

          <label for="Image">Profile Image:</label>      
          <asp:FileUpload CssClass="file" ID="Profile_img" runat="server" />

          <label for="Resume">Resume:</label>      
          <asp:FileUpload CssClass="file" ID="Resume" runat="server" />
            <h1 class="h1">Education:</h1>
       <%--<label for="Eductation">Education</label> <br />--%>
          <fieldset>
          <label for="Master Degree">Master Degree:</label>
          <input runat="server" type="text" id="MDegree" >
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="MDuration" placeholder="MMM YYYY - MMM YYYY">
          <label for="College">College:</label>
          <input runat="server" type="text" id="MCollege">

          <label for="Under Graduate Degree">Under Graduate Degree:</label>
          <input runat="server" type="text" id="Bdegree">
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="BDuration" placeholder="MMM YYYY - MMM YYYY">
          <label for="College">College:</label>
          <input runat="server" type="text" id="BCollege">

          <label for="Master Degree">Junior College:</label>
          <input runat="server" type="text" id="JCStream" placeholder="Stream Ex:Science,Commerce,etc">
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="JCDuration" placeholder="MMM YYYY - MMM YYYY">
          <label for="College">College:</label>
          <input runat="server" type="text" id="JCCollege">
          </fieldset>
        </fieldset>
            <h1 class="h1">Work Experience: </h1>
          <%--<label for="Work">Work Experience:</label> <br />--%>
          <fieldset>
          <label for="Job Profile">Job Profile:</label>
          <input runat="server" type="text" id="role1" name="role1" >
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="duration1" name="duration1">
          <label for="Company">Company:</label>
          <input runat="server" type="text" id="company1" name="company1">
          <label for="Info">job info:</label>
          <textarea runat="server" id="job1" cols="20" rows="2"></textarea>
          </fieldset>
    <fieldset>
          <label for="Job Profile">Job Profile:</label>
          <input runat="server" type="text" id="role2" name="role2" >
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="duration2" name="duration2" >
          <label for="Company">Company:</label>
          <input runat="server" type="text" id="company2" name="company2" >
          <label for="Info">job info:</label>
          <textarea runat="server" id="job2" cols="20" rows="2"></textarea>
          </fieldset>
    <fieldset>
          <label for="Job Profile">Job Profile:</label>
          <input runat="server" type="text" id="role3" name="role3" >
          <label for="Duration">Duration:</label>
          <input runat="server" type="text" id="duration3" name="duration3" >
          <label for="Company">Company:</label>
          <input runat="server" type="text" id="company3" name="company3" >
          <label for="Info">job info:</label>
          <textarea runat="server" id="job3" cols="20" rows="2"></textarea>
          </fieldset>
    <asp:Button ID="signup" CssClass="button" runat="server" Text="Sign Up" OnClick="signup_Click" />
</asp:Content>
