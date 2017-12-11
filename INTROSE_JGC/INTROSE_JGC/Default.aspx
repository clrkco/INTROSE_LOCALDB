<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="INTROSE_JGC.Default" %>
<!DOCTYPE html>
<html>
<style>
    
    .login{
        width: 360px;
        padding: 8% 0 0;
        margin: auto;
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

    form{
		text-align: center;
		margin: 0 auto 20px;
        padding 45px;
		}
        table #t01{
            float:left;
            width:50%;
		}

        table #t02{
            float:left;
            width:50%;
        }
    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
		margin: 0 0 15px;
        padding: 15px;
		display: inline-block;
		postion:relative;
		width:500px;
		height:auto;
        overflow:scroll;
    }



    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }

	caption{
        font-family: sans-serif;
		align: top;
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
    <title>Homepage</title>
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
                <asp:LoginView ID="DefaultLoginView" runat="server">
                    <AnonymousTemplate>
                        <asp:HyperLink runat="server" NavigateUrl="~/Module7.aspx" Text="Admin" ForeColor="White"></asp:HyperLink>
                    </AnonymousTemplate>
                </asp:LoginView>
                              
             </div>
        
        <div class = "home3">
            <a href="/UserProfile.aspx" class = "menu">User Profile</a>
        </div>
        <%--<div class = "home">
            <a href="/Login.aspx" class = "menu">Login</a>
        </div>--%> 
        <%-- PUT LOGOUT IN CONJUNCTION WITH FORMS AUTHENTICATION --%>
    </header>
    <form id="form1" runat="server" style = "white-space:nowrap">
    <table id="t01">
	    <caption >Projects</caption>
	  <tr>
        <th>Name</th>
        <th>Department</th> 
        <th>Start Date</th>
      </tr>
      <tr>
        <td>Project 1</td>
        <td>IT</td> 
        <td>28-01-2017</td>
      </tr>
    </table>
    <table id="t02">
	  <caption>Activity Log</caption>
	  <tr>
        <th>Name</th>
        <th>Project</th> 
        <th>Date</th>
      </tr>
      <tr>
        <td>Eve</td>
        <td>Project 1</td> 
        <td>05-11-2017</td>
      </tr>
    </table>
    </form>
    <footer>
        <div class ="foot"> &copy; JGC Philippines INC.</div>
    </footer>
</body>
</html>
