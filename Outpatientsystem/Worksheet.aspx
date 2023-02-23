<%@ Page Title="" Language="C#" MasterPageFile="~/Navigate.Master" AutoEventWireup="true" CodeBehind="Worksheet.aspx.cs" Inherits="Outpatientsystem.Worksheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="curNav">当前位置：<a href="index.aspx">首页</a><a href="zj.aspx">专家</a><a href="javascript:void(0)">门诊排班</a></div>
<div class="navTitle"><span><h1><i>门诊排班</i></h1></span></div>
<div class="box padding40">
  <div class="boxTL"></div><div class="boxTR"></div><div class="boxBL"></div><div class="boxBR"></div> 
  <div class="boxMzxx">
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="tabelMzxx" HeaderStyle-CssClass="headMzxx" DataKeyNames="No" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HeaderStyle-Height="30px" RowStyle-Height="20px" >
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="No" HeaderText="No" SortExpression="No" ReadOnly="True" Visible="False" />
              <asp:BoundField DataField="名字" HeaderText="名字" SortExpression="名字" />
              <asp:BoundField DataField="时间" HeaderText="时间" SortExpression="时间" />
              <asp:HyperLinkField DataNavigateUrlFields="No" DataNavigateUrlFormatString="showdoc.aspx?医生编号={0}" DataTextFormatString="{c:0}" HeaderText="操作" Text="预约" />
          </Columns>

          <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

<HeaderStyle CssClass="boxMzxx" BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>
          <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
          <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
          <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
          <SortedAscendingCellStyle BackColor="#FDF5AC" />
          <SortedAscendingHeaderStyle BackColor="#4D0000" />
          <SortedDescendingCellStyle BackColor="#FCF6C0" />
          <SortedDescendingHeaderStyle BackColor="#820000" />
      </asp:GridView>
   
      <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT D.No,D.Name AS '名字' ,W.Time AS '时间' FROM tb_Worksheet AS W
	JOIN tb_Doctor AS D ON D.No=W.DoctorNo"></asp:SqlDataSource>
   
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="(SELECT D.Name AS 'Monday' FROM tb_Worksheet AS W
	JOIN tb_Doctor AS D ON D.No=W.DoctorNo
	WHERE datepart(weekday,W.Time)=2)"></asp:SqlDataSource>
   
  </div>
</div>  
</asp:Content>
