<%@ Page Title="" Language="C#" MasterPageFile="~/Navigate.Master" AutoEventWireup="true" CodeBehind="showdoc.aspx.cs" Inherits="Outpatientsystem.showdoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   
   
          <div class="docTc">
         <asp:Image ID="Image1" ImageUrl="Image/inde-logo.png"  runat="server" class="docPic" />



    <div class="docBox">
      <div class="docNav"><span><i>      
    <asp:Label ID="Laname" runat="server" Text="Label"   ></asp:Label>
              </i>  <asp:Label ID="title" runat="server"> </asp:Label>           
   </span></div>
      <div class="docCon">
  
    <asp:Label ID="Laintroduction" runat="server" Text="Label"  ></asp:Label>

      </div>
    
    </div>
  
<div style="height:100px;width:100%;"></div>

    <div style="height:500px;width:100%;font-size:15px;color:black;text-align:center;">
        
        <div style="height:200px;width:100%;font-size:20px;color:black; position:center;">
          <%--  <h1>排班表</h1>--%>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="No" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" RowStyle-Height="20px" Width="481px" HeaderStyle-Height="30px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="No" HeaderText="No" ReadOnly="True" />
                <asp:BoundField DataField="DoctorNo" HeaderText="DoctorNo" SortExpression="DoctorNo" Visible="False" />
                <asp:BoundField DataField="Time" HeaderText="时间" SortExpression="Time" />
                <asp:BoundField DataField="是否可预约" HeaderText="是否可预约" ReadOnly="True" SortExpression="是否可预约" />
                <asp:TemplateField HeaderText="操作"><ItemTemplate>
                    <asp:Button runat="server" ID="yy" Text="预约" OnClick="yy_Click" style="height:18px;width:30px;color:black;background-color:azure" />

                                   </ItemTemplate>
                </asp:TemplateField>
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
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT * FROM [WorksheetView] WHERE ([DoctorNo] = @DoctorNo)">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="2230105001" Name="DoctorNo" QueryStringField="医生编号" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

    </div>
        </div>
    
</asp:Content>
