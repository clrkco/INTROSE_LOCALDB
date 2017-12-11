<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="INTROSE_JGC.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<style>
    
    .login{
        width: 360px;
        padding: 8% 0 0;
        margin: auto;
    }
    
    
    .form{
        position: relative;
        z-index:1;
        background: #FFFFFF;
        max-width: 360px;
        margin: 0 auto 20px;
        padding: 45px;
        text-align: center;
    
    }
    
    .form input{
        font-family: sans-serif;
        outline: 0;
        background: #f2f2f2;
        width: 100%;
        border: 0;
        margin: 0 0 15px;
        padding: 15px;
        box-sizing: border-box;
        font-size: 14px;
    }
    
    .form button{
        font-family: sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 100%;
        border: 0;
        padding: 15px;
        color: #FFFFFF;
        font-size: 14px;
        margin-bottom: 10px;
    }
    
    .pass{
        display: inline-block;
        position: relative;
        left: 165px;
        font-size: 12px;
        font-family: sans-serif;
    }
    
    body{
        padding:0;
        margin:0;
    }
    
    .message{
        font-size: 14px;
        margin: 15px;
        font-family: sans-serif;

    }
    
    header{
        background-color: black;
    }
    
    footer{
        background-color: lightgrey;
        position: absolute;
        right: 0;
        bottom: 0;
        left: 0;
        padding: 15px;
        text-align: left;
        font-family: sans-serif;
        font-size:14px;
    }
    
    .foot{
        font-family: sans-serif;
        font-size: 12px;
    }
    
    .imgcontainer{
        position: relative;
        display: inline-block;
    }
    
    .home{
        display: inline-block;
        color: white;
        position: relative;
        font-size: 15px;
        bottom: 45px;
        margin-left: 12px;
        margin-right: 10px;
        left: 20px;
        font-family: sans-serif;

    }

    .dropbtn {
        background-color: #4CAF50;
        color: white;
        padding: 16px;
        font-size: 16px;
        border: none;
        cursor: pointer;
    }

    .dropdown {
        position: relative;
        display: inline-block;
    }

    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f9f9f9;
        min-width: 160px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 1;
    }

    .dropdown-content a {
        color: black;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
    }

    .dropdown-content a:hover {background-color: #f1f1f1}

    .dropdown:hover .dropdown-content {
        display: block;
    }

    .dropdown:hover .dropbtn {
        background-color: #3e8e41;
    }
    a:link {
        text-decoration: none;
        color: black;
            
    }

    a:visited {
        text-decoration: none;
        color: black;
    }

    a:hover {
        text-decoration: underline;
    }

    a:active {
        text-decoration: underline;
    }
		
    a.menu:link {
        text-decoration: none;
        color: white;
            
    }

    a.menu:visited {
        text-decoration: none;
        color: white;
    }
    .home3{
        display: inline-block;
        color: white;
        position: relative;
        font-size: 15px;
        bottom: 43px;
        margin-left: 12px;
        margin-right: 10px;
        left: 946px;
        font-family: sans-serif;

    }
</style>

<head runat="server">
    <title>Change Password</title>
    <script runat="server">
    
    </script>
</head>
<body>
        <header>
        <div class="imgcontainer">
            <a href="/Default.aspx"><img src="jgc.png" alt="Avatar" class="avatar"> </a>
        </div>
        <div class = "home">
            <a href="/Default.aspx" class = "menu">Home</a>
        </div>
        <div class = "home dropdown">
                <div class = "dropdown">Projects</div>
                <div class="dropdown-content">
                    <a href="/Module1.aspx">Project Infrastructure Cost Estimate </a>
                    <a href="/Module2.aspx">Project Engineering and Management Software Cost Estimate </a>
                    <a href="/Module6.aspx">Engineering Software License Allocation Monitoring System </a>
                </div>
            </div>
            <div class = "home">
                      <a href="/Module7.aspx" class = "menu">Admin/IT</a>             
             </div>
            <div class = "home3">
            <a href="/UserProfile.aspx" class = "menu">User Profile</a>
        </div>

    </header>
    <form id="form1" runat="server">
    <div class = "login">
    <div class="form">
    <div class = "message" >Change Your Password</div>
    <input runat="server" type="text" placeholder="Old Password" name="opassname" id="txtOld" required>
    <input runat="server" type="text" placeholder="New Password" name="npassname" id="txtNew" required>
    <input runat="server" type="text" placeholder="Confirm New Password" name="cnpassname" id= "txtNewC" required>
   <asp:Button runat="server" ID="btnChangePass" Text="ChangePassword" ForeColor="White" BackColor="#4CAF50" OnClick="btnChangePass_Click" />
   <asp:Button runat="server" ID="btnCancel" Text="Cancel" ForeColor="White" BackColor="#4CAF50" OnClick="btnCancel_Click" />
    <asp:Label runat="server" ID="lblStatus" ForeColor="Red"></asp:Label>
     <asp:Label runat="server" ID="lblSuccess" ForeColor="Green"></asp:Label>

    </div>

    </div>
    </form>
    <footer>
        <div class ="foot"> &copy; JGC Philippines INC.</div>
    </footer>
</body>
</html>
