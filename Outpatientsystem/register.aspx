<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Outpatientsystem.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>沐兰门诊系统注册页面</title>
    <link href="Css/blue.css" rel="stylesheet" />
    <link href="Css/common.css" rel="stylesheet" />
    <link href="Css/workstation.css" rel="stylesheet" />
</head>
<body style="background-image:url('images/0.jfif');">
    <form id="form1" runat="server">
        <link href="Css/common.css" rel="stylesheet" />
        <div style="height:100px"></div>
        <div style="text-align:center;">
           <%--  <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/index_02.png" />--%>
        </div>
        <div style="text-align:center;">
           
 <div style="width:50%;height:100%;float:left;"></div>
            
            <div>

                   
            <br />    <br />  
         &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="账号："></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxid" runat="server"></asp:TextBox><br />
        <br />
                         <asp:Label ID="Label3" runat="server" Text="电话号码:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxphone" runat="server"></asp:TextBox><br />
        <br />
                         &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="姓名："></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxname" runat="server"></asp:TextBox><br />
        <br />
                         &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label6" runat="server" Text="性别："></asp:Label>
&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="女" /><asp:CheckBox ID="CheckBox2" runat="server" Text="男" />
               
        <br />
                         &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" Text="邮箱："></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxemail" runat="server"></asp:TextBox><br />
        <br />
           &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Text="密码："></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxpw" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="Buttonreg" runat="server" Text="注册"  OnClick="Buttonreg_Click"/>
              <br />  <asp:Label ID="Labelmgls" runat="server" Text="账户或密码错误！" Visible="false" style="color:red;font-size:14px;"> </asp:Label>
        </div>
                </div>
        <br />
         <div class="Nsb_rights" style="text-align:center">Copyright (C) 沐兰门诊系统 2023-2033 All Rights Reserved 闽ICP 备12345678号</div>
    </form>
</body>
</html>
