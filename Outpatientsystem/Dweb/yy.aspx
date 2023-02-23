<%@ Page Title="" Language="C#" MasterPageFile="~/doctorui.Master" AutoEventWireup="true" CodeBehind="yy.aspx.cs" Inherits="Outpatientsystem.yy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid mt-3">
    <div class="Nsb_layout_r">
   <div style="font-size:20px;text-align:center;position:center;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="Nsb_r_list Nsb_table">
            <Columns>
                <asp:BoundField DataField="预约号" HeaderText="预约号" SortExpression="预约号" />
                <asp:BoundField DataField="患者编号" HeaderText="患者编号" SortExpression="患者编号" />
                <asp:BoundField DataField="患者姓名" HeaderText="患者姓名" SortExpression="患者姓名" />
                <asp:BoundField DataField="预约时间" HeaderText="预约时间" SortExpression="预约时间" />
                <asp:BoundField DataField="医生编号" HeaderText="医生编号" SortExpression="医生编号" Visible="False" />
                <asp:BoundField DataField="是否就诊" HeaderText="是否就诊" ReadOnly="True" SortExpression="是否就诊" />
                <asp:HyperLinkField DataNavigateUrlFields="预约号" DataNavigateUrlFormatString="patient.aspx?yyh={0}" DataTextFormatString="{c:0}" HeaderText="操作" Text="查看|修改" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OutpatientDemoConnectionString %>" SelectCommand="SELECT * FROM [YYView] WHERE ([医生编号] = @医生编号)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="2230105001" Name="医生编号" SessionField="Id" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
        </div>
        </div>
</asp:Content>
