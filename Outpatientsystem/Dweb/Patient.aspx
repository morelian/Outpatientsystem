<%@ Page Title="" Language="C#" EnableEventValidation="false"  MasterPageFile="~/doctorui.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="Outpatientsystem.Patient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        td{
            width:50px;height:12px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <div style="text-align:center;position:center;">
            <asp:DropDownList ID="Dropselectcondition" runat="server" CssClass="accordion-item" Width="100px">
                <asp:ListItem Value="1">药名</asp:ListItem>
                <asp:ListItem Value="2">药品分类</asp:ListItem>
                <asp:ListItem Value="2">药品拼音</asp:ListItem>
            </asp:DropDownList>
        <asp:TextBox ID="Search" runat="server" Height="30px" Width="150px" ></asp:TextBox> &nbsp; <asp:Button ID="btnsearch" runat="server" Text="查找" OnClick="btnsearch_Click" />
    </div>

 <div style="float:left;">
        <asp:Button ID="print" runat="server" Text="打印" OnClick="btn_print_Click" />
        <asp:Button ID="btn_add" runat="server" Text="保存" OnClick="btn_add_Click" />
        <asp:Button ID="btn_countprice" runat="server" OnClick="btn_count_price" Text="计算价格" />
        <table style="border:solid;width:350px">
           <tr style="border:solid;text-align:center">  <td colspan="7" >沐兰门诊处方</td></tr>
           <tr>   
                <td   colspan="4">费别：<asp:DropDownList ID="Drop_pricetype" runat="server" Width="100px">
                    <asp:ListItem>自费</asp:ListItem>
                    <asp:ListItem>免费</asp:ListItem>
                    </asp:DropDownList></td>


                <td colspan="3">处方编号：<asp:Label ID="lbl_chufangNo" runat="server" Text="Label"></asp:Label></td>

            </tr>  
            <tr>   

                <td colspan="3">科室:<asp:Label ID="lbl_kesi" runat="server" Text="Label"></asp:Label></td>
                <td colspan="4">发药日期：<asp:Label ID="lbl_time" runat="server" Text="Label"></asp:Label></td>

            </tr>    
            <tr>
               
                <td style="border:solid" rowspan="2" colspan="3">姓名：<asp:Label ID="lbl_name" runat="server" Text="Label"></asp:Label></td>
                <td style="border:solid"  colspan="2">性别：<asp:Label ID="lbl_gender" runat="server" Text="Label"></asp:Label></td>
                <td style="border:solid"colspan="2">年龄：<asp:Label ID="lbl_age" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                 <td style="border:solid"  colspan="4">患者编号：<asp:Label ID="lbl_no" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                   
                <td style="border:solid" colspan="4">单位或家庭住址：<asp:Label ID="lbl_address" runat="server" Text="Label"></asp:Label></td>
                <td style="border:solid"  colspan="3">电话：<asp:Label ID="lbl_phone" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="border:solid" colspan="4" >临床诊断及症型：<asp:Label ID="lbl_diagnosis" runat="server" Text="Label"></asp:Label></td>
                <td style="border:solid" colspan="3">此诊断：<asp:Label ID="lbl_after" runat="server" Text="Label"></asp:Label></td>
            </tr>
            
            <tr >
                <td style="border:solid" colspan="7" >
                    <asp:GridView ID="GridDrugSelected" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridDrugSelected_RowDataBound" OnSelectedIndexChanged="GridDrugSelected_SelectedIndexChanged" OnRowCommand="GridDrugSelected_RowCommand" OnRowCreated="GridDrugSelected_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="药名" SortExpression="Name" />
                         
                            <asp:TemplateField HeaderText="数量">
                                <ItemTemplate>
                                  <asp:TextBox ID="text_num" runat="server" Text='<%# Bind("Num") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Unix" HeaderText="单位" SortExpression="Unix" />
                            <asp:BoundField DataField="Price" HeaderText="价格" SortExpression="Price" />
                            <asp:BoundField DataField="No" HeaderText="No" SortExpression="No" Visible="False" />
 
                            <asp:ButtonField CommandName="Select" HeaderText="操作" Text="取消" />
 
                         
 
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT * FROM [ZDrugView] WHERE ([No] = @No)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lbl_chufangNo" Name="No" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="border:solid" colspan="7">处方说明：<asp:TextBox ID="text_explain" runat="server" OnTextChanged="TextBox1_TextChanged" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td   colspan="3">医师：<asp:Label ID="lbl_doctor" runat="server" Text="Label"></asp:Label></td>
                <td>药品<br />金额：</td>
                <td  colspan="3"><asp:Label ID="lbl_price" runat="server" Text=" "></asp:Label>
                    </td>
            </tr>
            <tr>
                <td colspan="1" rowspan="2">审核<br />调配</td>
                 <td rowspan="2" colspan="2"><asp:TextBox ID="text_allocate" runat="server" width="100%"></asp:TextBox></td>
                     <td  colspan="1" rowspan="2">核对<br />发药:</td>
                <td  colspan="3" rowspan="2"><asp:TextBox ID="text_Check" runat="server" width="100%"></asp:TextBox></td>
            </tr>
        </table>
   </div>
    <div style="text-align:center;width:50%;float:right;font-size:10px;">
          <div>
        <h5>药品分类查找：</h5>
    <asp:DropDownList ID="Drugtype" runat="server" DataSourceID="sqldatadrugtype" DataTextField="Name" DataValueField="No" OnSelectedIndexChanged="Drugtype_SelectedIndexChanged" AutoPostBack="true" PagerSettings-Mode="NextPrevious" ></asp:DropDownList>

    <asp:SqlDataSource ID="sqldatadrugtype" runat="server" ConnectionString="<%$ ConnectionStrings:Sql %>" SelectCommand="SELECT * FROM [tb_Type]"></asp:SqlDataSource>
              <asp:GridView ID="GridDrugtable" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanged="GridDrugtable_PageIndexChanged" OnPageIndexChanging="GridDrugtable_PageIndexChanging" OnRowCommand="GridDrugtable_RowCommand" OnRowDataBound="GridDrugtable_RowDataBound" OnSelectedIndexChanged="GridDrugtable_SelectedIndexChanged" OnSelectedIndexChanging="GridDrugtable_SelectedIndexChanging" Width="100%">
                  <AlternatingRowStyle BackColor="#F7F7F7" />
                  <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                  <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" Height="15px" Width="20px" />
                  <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                  <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Height="15px" Width="20px" />
                  <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                  <SortedAscendingCellStyle BackColor="#F4F4FD" />
                  <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                  <SortedDescendingCellStyle BackColor="#D8D8F0" />
                  <SortedDescendingHeaderStyle BackColor="#3E3277" />
                  <PagerSettings FirstPageText="首页" LastPageText="尾页" Mode="NextPrevious" NextPageText="下一页" Position="TopAndBottom" PreviousPageText="上一页" />
    
              </asp:GridView>
   </div>
    </div>


</asp:Content>
