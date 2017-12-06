<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="INTROSE_JGC.Login" %>

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
        padding 45px;
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
    
    label{
        font-size: 12px;
        position: relative;
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

    .pass{
        display: inline-block;
        position: relative;
        font-size: 12px;
        font-family: sans-serif;
        left: 260px;
        bottom: 19px;
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
</style>

<head runat="server">
    <title>Login</title>
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
                    <a href="/Module1.aspx">Module 1</a>
                    <a href="/Module2.aspx">Module 2</a>
                    <a href="/Module6.aspx">Module 6</a>
                </div>
            </div>
            <div class = "home dropdown">
                <div class = "dropdown">Admin/IT</div>
                <div class="dropdown-content">
                    <a href="#">Link 1</a>
                    <a href="#">Link 2</a>
                    <a href="#">Link 3</a>
                </div>
            </div>
        <div class = "home">
            <a href="#" class = "menu">About</a>
        </div>
        <div class = "home">
            <a href="#" class = "menu">Contact</a>
        </div>
        <div class = "home">
            <a href="/Login.aspx" class = "menu">Login</a>
        </div>
    </header>
    <form id="form1" runat="server">
    <div class = "login">
  <div class="form">
    <input type="text" placeholder="Username" name="uname" required>

    <input type="password" placeholder="Password" name="psw" required>

    <button type="submit" class="loginbutton">Login</button>

    </div>
    <div>
        <label><input type="checkbox"> Remember me </label>

        <div class="modifypass">
        <div class ="pass"> <a href="/ChangePassword.aspx">Change password</a></div>
    </div>
    </div>

    </div>
    </form>
    <footer>
        <div class ="foot"> &copy; JGC Philippines INC.</div>
    </footer>
</body>
</html>
