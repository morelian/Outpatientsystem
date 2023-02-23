<%@ Page Title="" Language="C#" MasterPageFile="~/Navigate.Master" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="Outpatientsystem.Personal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .rightover{
              float:right;
        }
        .auto-style2 {
            height: 30px;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="height:50px;width:100%;">
  </div>
    <div  style="text-align:center;height:500px;width:100%;">
  <div style="height:200px;width:100%;">
          头像：
        <asp:Image ID="Image1" ImageUrl="Image/inde-logo.png"  runat="server" style="height:100px;width:100px;" />
        <br />更换头像：<asp:FileUpload ID="fupImage" runat="server" />
          <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="fupImage"
            ErrorMessage="不能为空"></asp:RequiredFieldValidator><br />
         <asp:Button ID="btnphoto" runat="server" OnClick="btnphoto_Click1" Text="上传头像" CausesValidation="false"  style="height:30px; background-color:aliceblue;color:black;font-size:15px;" BorderStyle="Double" />
                
        </div>
      <div style="height:160px;width:100%;">
            <asp:Label ID="Label1" runat="server" Text="名字:  " style="color:black;font-size:16px;"></asp:Label> &nbsp;&nbsp;
        <asp:Label ID="lbname" runat="server" Text="名字" style="color:black;font-size:16px;"></asp:Label> 
          <div style="height:30px;width:100%;"></div>
         
        <asp:Label ID="Label3" runat="server" Text="修改名字" style="color:black;font-size:16px;"></asp:Label>
                  <asp:TextBox ID="Textnewname" runat="server"></asp:TextBox><div style="height:10px;width:100%;"></div>
        <asp:Button ID="Buttonchangename" runat="server" OnClick="Buttonchangename_Click" Text="确认修改" BorderStyle="Double" CausesValidation="false"  />
     &nbsp; &nbsp; &nbsp;
     </div>
        <div style="text-align:center; height:200px;width:100%;">
           <br />    <br />    <br />    <br />    <br /> 
          <div style="height:30px;width:100%;">
              <asp:Label ID="Label2" runat="server" Text="修改密码" style="color:aqua;font-size:16px;"></asp:Label>
          </div>
            <div style="height:30px;width:100%;">
                <asp:Label ID="Label5" runat="server" Text="原密码：" style="color:black;font-size:16px;"></asp:Label>
                <asp:TextBox ID="Textold" runat="server"></asp:TextBox><br /><br /><br />
            </div>
             <div class="auto-style2">
            <asp:Label ID="Label6" runat="server" Text="新密码：" style="color:black;font-size:16px;"></asp:Label>
      <asp:TextBox ID="Textnew1" runat="server"></asp:TextBox><br /><br /><br />
                 </div>
              <div style="height:30px;width:100%;">
            <asp:Label ID="Label7" runat="server" Text="再一次：" style="color:black;font-size:16px;"></asp:Label>
          <asp:TextBox ID="Textnew2" runat="server"></asp:TextBox><br /><br /><br />
                  </div>
          <br />
          <br />
              <div style="height:50px;width:100%;">
                  <asp:Button ID="Buttonchangepw" runat="server" Text="确认修改" OnClick="Buttonchangepw_Click"  style="height:30px; background-color:aliceblue;color:black;font-size:15px;" BorderStyle="Double" CausesValidation="false" />
          </div>
              <div style="height:50px;width:100%;">
                  <asp:Label ID="lblm" runat="server" Text="旧密码错误" Visible="false"  style="height:30px; background-color:aliceblue;color:black;font-size:20px;"></asp:Label>
                  </div>
          </div>
  
        
               <div style="height:500px;width:100%;font-size:15px;color:black;text-align:center;">
        
        <div style="height:200px;width:100%;font-size:20px;color:black; position:center;">
            <h1 style="height:50px;width:100%;">预约记录</h1>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HeaderStyle-Height="30px" RowStyle-Height="20px" Width="618px" AutoGenerateColumns="False" DataKeyNames="预约号" DataSourceID="SqlDataSource1" style="margin:0 auto" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="预约号" HeaderText="预约号" ReadOnly="True" SortExpression="预约号" />
                        <asp:BoundField DataField="预约时间" HeaderText="预约时间" SortExpression="预约时间" />
                        <asp:BoundField DataField="医生名字" HeaderText="医生名字" SortExpression="医生名字" />
                        <asp:BoundField DataField="是否就诊" HeaderText="是否就诊" ReadOnly="True" SortExpression="是否就诊" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate><asp:Button runat="server" ID="yy" Text="取消预约" OnClick="yy_Click" style="height:18px;width:60px;color:black;background-color:azure" CausesValidation="false"  /> </ItemTemplate> </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate><asp:Button runat="server" ID="pay" Text="付费" OnClick="pay_Click" style="height:18px;width:60px;color:black;background-color:azure" CausesValidation="false"  /> </ItemTemplate> </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT [预约号], [预约时间], [医生名字], [是否就诊] FROM [YYView] WHERE ([患者编号] = @患者编号)">
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="3210707001" Name="患者编号" SessionField="No" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </div>
                   </div>
          </div>
      



        <br />
    <!--<div class="boxTc" id="boxLogin">
  <form action="#"> 
  <div class="loginTc">
    <a href="javascript:void(0)" class="btnCloseTc" id="closeLogin"><i></i></a>
    <img src="images/logo.png" class="loginLogo" />
    <ul>
      <li>
        <input type="text" class="inputLogin" id="loginId" placeholder="手机号码">
        <div class="tipsErr" id="phoneNull">请输入手机号码</div>
        <div class="tipsErr" id="phoneErr">请输入正确的手机号码</div>
      </li>
      <li>
        <input type="text" class="inputLogin" id="loginYzm" placeholder="验证码">
        <button class="btnYzm" id="btnYzm">获取验证码</button>
        <div class="tipsErr" id="yzmNull">请输入验证码</div>
        <div class="tipsErr" id="yzmErr">验证码错误</div>
        <div class="tipsOk" id="yzmYfs">验证码已发送到你手机，请注意查看</div>
      </li>
      <li><input type="submit" class="submitLogin" value="登 录"></li>
    </ul>
  </div>
  </form>  
</div>-->
</asp:Content>