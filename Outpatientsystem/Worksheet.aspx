<%@ Page Title="" Language="C#" MasterPageFile="~/Navigate.Master" AutoEventWireup="true" CodeBehind="Worksheet.aspx.cs" Inherits="Outpatientsystem.Worksheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%--    <div class="curNav">当前位置：<a href="index.aspx">首页</a><a href="zj.aspx">专家</a><a href="javascript:void(0)">门诊排班</a></div>
<div class="navTitle"><h1><i>门诊排班</i></h1></div>
<div class="box padding40">
  <div class="boxTL"></div><div class="boxTR"></div><div class="boxBL"></div><div class="boxBR"></div> 
  <div class="boxMzxx" style="text-align:center">--%>
      <div style="color:cadetblue;height:500px;width:100%;font-size:15px;" >
         按科室选择：<asp:DropDownList ID="drop_ks" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Name" OnSelectedIndexChanged="drop_ks_SelectedIndexChanged" style="height: 17px" BackColor="#FFCCFF"></asp:DropDownList>
          <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT * FROM [tb_Keshi]"></asp:SqlDataSource>
 
            按时间选择：<asp:DropDownList ID="drop_time" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drop_time_SelectedIndexChanged" style="height: 17px" BackColor="#FFCCFF">
              <asp:ListItem>星期天</asp:ListItem>
              <asp:ListItem>星期一</asp:ListItem>
              <asp:ListItem>星期二</asp:ListItem>
              <asp:ListItem>星期三</asp:ListItem>
              <asp:ListItem>星期四</asp:ListItem>
              <asp:ListItem>星期五</asp:ListItem>
              <asp:ListItem>星期六</asp:ListItem>
          </asp:DropDownList>
 
       <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="800px" >
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:HyperLinkField DataNavigateUrlFields="医师编号" DataNavigateUrlFormatString="showdoc.aspx?医生编号={0}" DataTextFormatString="{c:0}" HeaderText="预约" Text="选择" />
              </Columns>
              <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" Height="20px" />
              <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
              <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Height="20px" />
              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
              <SortedAscendingCellStyle BackColor="#FDF5AC" />
              <SortedAscendingHeaderStyle BackColor="#4D0000" />
              <SortedDescendingCellStyle BackColor="#FCF6C0" />
              <SortedDescendingHeaderStyle BackColor="#820000" />
          </asp:GridView>
        </div>
 
   
<%--  </div>
</div>  --%>
</asp:Content>
