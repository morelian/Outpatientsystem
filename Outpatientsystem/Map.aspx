<%@ Page Title="" Language="C#" MasterPageFile="~/Navigate.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="Outpatientsystem.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

       <div class="docTc">
           <div style="height:500px;width:100%;font-size:15px;color:black;text-align:center;">
               <asp:GridView ID="dgv_concent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" RowStyle-Height="20px" Width="481px" HeaderStyle-Height="30px">
                   <AlternatingRowStyle BackColor="White" />
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
               </div>
           </div>
</asp:Content>
