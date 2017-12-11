<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Module6.aspx.cs" Inherits="INTROSE_JGC.Module6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/javascript">
        function CheckSoft(val) {
            var element = document.getElementById('soft');
            if (val == 'others')
                element.style.display = 'block';
            else
                element.style.display = 'none';
        }

</script> 
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
        right: 11px;
        bottom: 309px;
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
        text-align: left;
        margin: 0 auto 20px;
        padding 45px;
    }



    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
        margin: 0 0 15px;
        padding: 10px;
        display: inline-block;
        position: relative;
        width:500px;
        float: left;
        overflow-y: scroll;
        height: 300px;
    }


    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        width: 200px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }

    caption{
        font-family: sans-serif;
    }
    
    .textboxid{
        height:100px;
        font-size:12pt;
        
    }

    textarea {
        width: 300px;
        padding: 10px;
        height: 100px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        resize: none;
        display: inline-block;
        vertical-align: text-top;
    }
    
    input[type=text], input[type=month],input[type=number], select {
    width: 300px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    resize: none;
    display: inline-block;
    vertical-align: text-top;
    }
.info {
    border-radius: 5px;
    padding: 20px;
    float: left;
    width: 600px;
    font-family: sans-serif;
}
.col-25 {
    width: 150px;
    display: inline-block;
    padding: 10px;
}

/* Floating column for inputs: 75% width */
.col-75 {
  width: 200px;
  margin-top: 6px;
        padding: 15px;
    display: inline-block;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}
    
     form button{
        font-family: sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 30%;
        border: 0;
        margin-top: 10px;
        margin-right:117px;
        display: inline-block;
        padding: 10px;
        color: #FFFFFF;
        font-size: 14px;
        
    }
    
     .submit {
        font-family: sans-serif;
        text-transform: uppercase;
        outline: 0;
        background: #4CAF50;
        width: 20%;
        border: 0;
        margin: 30px;
        padding: 10px;
        color: #FFFFFF;
        font-size: 14px;
        float: right;
        
    }
    .tabletitle{
        font-family:sans-serif;
        padding: 10px;
        margin: 10px;

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
    <title>Module 6</title>
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
        <%--<div class = "home">
            <a href="/Login.aspx" class = "menu">Login</a>
        </div>--%> 
        <%-- PUT LOGOUT TO LOGIN IN CONJUNCTION WITH FORMS AUTHENTICATION --%>
    </header>
    <form class = "info" runat="server">
        <div class="row">
        <div class="col-25">
        Project:
        </div>
        <div class="col-75">
        <asp:DropDownList runat="server" ID="lstProject2" ></asp:DropDownList>
            <br>
        </div>
        </div>
        <div class="row">
        <div class="col-25">
        Software:
        </div>
        <div class="col-75">
        <asp:DropDownList runat="server" ID="lstSoftware"></asp:DropDownList>
            <br>
        <input type="text" name="soft" id="soft" style='display:none;'/>
        </div>
        </div>
        <div class="row">
        <div class="col-25">
        Month:
        </div>
        <div class="col-75">
        <input runat="server" type="datetime-local" name="month" id="dtMonth"/>
            <br>
        </div>
        </div>
        <div class="row">
        <div class="col-25">
        Projected To Be Used:
        </div>
        <div class="col-75">
        <input runat="server" type="number" id="txtProjToBeUsed"/><br>
        </div>
        </div>
        <div class="row">
        <div class="col-25">
        Actual Used:
        </div>
        <div class="col-75">
        <input runat="server" type="number" id="txtActualUsed"/><br>
        </div>
        </div>
            <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click"/>
           <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" />
        <asp:GridView runat="server" ID="gvSoftwareList" AutoGenerateColumns="False" DataKeyNames="PROJECT_ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="PROJECT_ID" HeaderText="PROJECT_ID" ReadOnly="True" SortExpression="PROJECT_ID" />
                <asp:BoundField DataField="SOFTWARE" HeaderText="SOFTWARE" SortExpression="SOFTWARE" />
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="PROJECTED_USE" HeaderText="PROJECTED_USE" SortExpression="PROJECTED_USE" />
                <asp:BoundField DataField="ACTUAL_USE" HeaderText="ACTUAL_USE" SortExpression="ACTUAL_USE" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;CMT_SOFTWARE_USAGE&quot;"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" SelectCommand="SELECT * FROM [CMT_SOFTWARE_USAGE]"></asp:SqlDataSource>
        <asp:Button runat="server" Text="Submit" ID="btnSubmit" OnClick="btnSubmit_Click" />
        </form>
    <div class = "tabletitle">Software List</div>
    
       
    <footer>
        <div class ="foot"> &copy; JGC Philippines INC.</div>
    </footer>
</body>
</html>