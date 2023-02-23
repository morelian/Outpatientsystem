using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Text;
using Outpatientsystem.BusinessLogicLayer;

namespace Outpatientsystem
{
    public partial class Patient : System.Web.UI.Page
    {

        IDoctorBll doctorBll=new DoctorBll();
        public SqlConnection sqlConnection = new SqlConnection();
        /// <summary>
        /// 药品表
        /// </summary>
        public DataTable DrugTable;
        /// <summary>
        /// 药品视图
        /// </summary>
        public DataView DrugView;

        /// <summary>
        /// 已选药品数据表；
        /// </summary>
        private DataTable SelectedDrugTable =new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

            string n = "1111111";
            if (Request.QueryString["yyh"] != null)
            {
                n = Request.QueryString["yyh"].ToString();
            }

            SqlCommand sqlCommand = new SqlCommand();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            sqlConnection.Open();
            sqlCommand1.CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{n}';";
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            if (!sqlDataReader1.Read())
            {
                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Connection = sqlConnection;
                sqlCommand3.CommandText = $"INSERT INTO tb_Diagnosticlist(No,BookingNo,Time,Content,ZZ,PriceType,Prices)VALUES\r\n('{n}','{n}','{DateTime.Now}','','','自费',0)";
                sqlCommand3.ExecuteNonQuery();
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand sqlCommand4 = new SqlCommand();
            sqlCommand4.Connection = sqlConnection;
            sqlCommand4.CommandText = $"SELECT * FROM ZDView AS Z WHERE Z.No='{n}'";
            SqlDataReader sqlDataReader = sqlCommand4.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.lbl_chufangNo.Text = sqlDataReader["No"].ToString();
                this.lbl_doctor.Text = sqlDataReader["DoctorName"].ToString();
                this.lbl_gender.Text = sqlDataReader["Gender"].ToString();
                this.lbl_name.Text = sqlDataReader["Pname"].ToString();
                this.lbl_kesi.Text = sqlDataReader["KeSi"].ToString().ToLower();
                this.lbl_phone.Text = sqlDataReader["Phone"].ToString();
                this.lbl_no.Text = sqlDataReader["Pno"].ToString();
                this.lbl_time.Text = DateTime.Now.ToString();
                this.lbl_age.Text = sqlDataReader["Age"].ToString();
                this.lbl_address.Text = sqlDataReader["Address"].ToString();
                this.lbl_diagnosis.Text = sqlDataReader["zz"].ToString();
                this.lbl_after.Text = "";
            }
            //SqlCommand sqlCommand2 = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = "SELECT * FROM DrugView";
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //sqlDataAdapter.SelectCommand = sqlCommand;
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ////打开SQL连接；
            //sqlDataAdapter.Fill(this.DrugTable); //SQL数据适配器读取数据，并填充课程数据表；
            //sqlConnection.Close();
            //DataColumn[] pk = new DataColumn[] { DrugTable.Columns[0], DrugTable.Columns[5] };
            //DrugTable.PrimaryKey = pk;
            DrugTable = this.doctorBll.buildtable();
            this.GridDrugtable.DataSource = DrugTable;
            this.DrugView = new DataView(DrugTable);
            this.DrugView.Sort = "分类编号 ASC";
            //this.DrugView.Table = this.DrugTable;
            this.GridDrugtable.DataBind();


            // if (!IsPostBack)
            // {
            //     this.GridDrugSelected.DataBind();
            //     //btn_countprice_Click();

            // }
           // this.lbl_price.Text =                                                                       //在标签中显示已选课程的学分总和；
           //$"共{this.SelectedDrugTable.Compute("SUM(数量)", "")}元";
        }
        /// <summary>
        /// 分类查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (this.Dropselectcondition.Text.Trim() == "")
            {
                this.GridDrugtable.DataSource = DrugTable;
                this.GridDrugtable.DataBind();
            }
            else  if (this.Dropselectcondition.SelectedValue=="1")
            {//按药名
                DataRow[] searchResultRowViews =
                this.DrugTable.Select($"药名 LIKE '%{this.Search.Text.Trim()}%'");                                //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
                DataTable searchResultTable = this.DrugTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
                foreach (DataRow dataRow in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
                {
                    searchResultTable.ImportRow(dataRow);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
                }
                this.GridDrugtable.DataSource = searchResultTable;
                this.GridDrugtable.DataBind();
            }
            else if (this.Dropselectcondition.SelectedValue == "2")
            {//按分类
                DataRow[] searchResultRows =
    this.DrugTable.Select($"药品分类 LIKE '%{this.Search.Text.Trim()}%'");                  //借助本窗体的课程数据表的方法Select，并提供与SQL类似的谓词表达式作为查询条件，根据拼音缩写进行模糊查询（仅支持%通配符）；查询将返回数据行数组；
                DataTable searchResultTable = this.DrugTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
                foreach (DataRow row in searchResultRows)                                                       //遍历搜索结果所在数据行数组；
                {
                    searchResultTable.ImportRow(row);                                                           //数据行导入数据表；
                }
                this.GridDrugtable.DataSource = searchResultTable;
                this.GridDrugtable.DataBind();
            }
            else if(this.Dropselectcondition.SelectedValue == "3")
            {//按拼音
                DataRow[] searchResultRows =
    this.DrugTable.Select($"拼音 LIKE '%{this.Search.Text.Trim()}%'");                  //借助本窗体的课程数据表的方法Select，并提供与SQL类似的谓词表达式作为查询条件，根据拼音缩写进行模糊查询（仅支持%通配符）；查询将返回数据行数组；
                DataTable searchResultTable = this.DrugTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
                foreach (DataRow row in searchResultRows)                                                       //遍历搜索结果所在数据行数组；
                {
                    searchResultTable.ImportRow(row);                                                           //数据行导入数据表；
                }
                this.GridDrugtable.DataSource = searchResultTable;
                    this.GridDrugtable.DataBind();
            }
        }

        protected void Drugtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView[] searchResultRowViews =
    this.DrugView.FindRows(this.Drugtype.SelectedValue);                            //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
            DataTable searchResultTable = this.DrugTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRowView dataRowView in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
            {
                searchResultTable.ImportRow(dataRowView.Row);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
            }
            this.GridDrugtable.DataSource = searchResultTable;
            GridDrugtable.DataBind();
        }
        /// <summary>
        /// 导出成Excel的设置
        /// </summary>
        /// <param name="FileType"></param>
        /// <param name="FileName"></param>
        /// <param name="ExcelContent"></param>
        public void ExportToExcel(string FileType, string FileName, string ExcelContent)
        {
            HttpContext.Current.Response.ContentType = FileType;
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
            StringWriter tw = new StringWriter();
            HttpContext.Current.Response.Output.Write(ExcelContent.ToString());
            /*乱码BUG修改 20140505*/
            //如果采用以上代码导出时出现内容乱码，可将以下所注释的代码覆盖掉上面【System.Web.HttpContext.Current.Response.Output.Write(ExcelContent.ToString());】即可实现。
            //System.Web.HttpContext.Current.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=utf-8\"/>" + ExcelContent.ToString());
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }
        public void Print()
        {


            //命名导出表格的StringBuilder变量
            StringBuilder sHtml = new StringBuilder(string.Empty);
            //打印表头
            sHtml.Append("<table  align=\"center\" border=\"0\" style=\"border-collapse: collapse; >");
            //打印内容
            sHtml.Append(" <tr style=\"border: 0px solid black; border-image: none;\">\r\n" +
                         $" <td align=\"center\" colspan=\"7\" style=\"border: 0px solid black; border-image: none; font-size: 16px; font-weight: bold;text-align:center;\">沐兰门诊诊单</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" +
                         $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">费别：</td>\r\n" +
                         $" <td align=\"center\" colspan=\"2\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                         $"{this.Drop_pricetype.Text}</td>\r\n" +
                         $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">处方编号:</td>\r\n" +
                         $" <td align=\"center\" colspan=\"3\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                         $"{lbl_chufangNo.Text}</td>\r\n</tr>" );
            sHtml.Append("<tr >\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">科室：</td>\r\n" +
                          $"<td align=\"center\" colspan=\" 3\" style=\"border: 1px solid black; border-image: none;\">{this.lbl_kesi.Text}</td>\r\n" +
                          "\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">发药时间：</td>\r\n" +
                          $"<td align=\"center\" colspan=\" 2\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_time.Text}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" + "<td align=\"center\"  rowspan=\"2\" style=\"border: 1px solid black; border-image: none;\">姓名</td>\r\n" +
                         $"<td align=\"center\"colspan=\"2\" rowspan=\"2\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_name.Text}</td>\r\n" +
                         "\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">性别：</td>\r\n" +
                         $"<td align=\"center\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_gender.Text}</td>\r\n" +
                          "\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">年龄：</td>\r\n" +
                         $"<td align=\"center\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_age.Text}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" + "\r\n" + "<td align=\"center\" colspan=\"2\" style=\"border: 1px solid black; border-image: none;\">患者编号：</td>\r\n" +
                        $"<td align=\"center\" colspan=\"2\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_no .Text}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">单位或家庭地址：</td>\r\n" +
                         $"<td align=\"center\" colspan=\" 3\" style=\"border: 1px solid black; border-image: none;\">{this.lbl_address.Text}</td>\r\n" +
                         "\r\n" + "<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">电话：</td>\r\n" +
                         $"<td align=\"center\" colspan=\" 2\"  style=\"border: 1px solid black; border-image: none;\">{this.lbl_phone.Text}</td>\r\n</tr>");
            for (int i = 0; i < GridDrugSelected.Rows.Count; i++)
            {
                string drug = "";
                TextBox txtQty = new TextBox();
                txtQty = (TextBox)GridDrugSelected.Rows[i].FindControl("text_num");
               int num= int.Parse(txtQty.Text);
                for (int j = 0; j < GridDrugSelected.Columns.Count; j++)
                {
                    if (j == 1)
                    {
                        string m = drug;
                        drug=m+"" +num;
                    }
                    string n = drug;
                    drug = n + GridDrugSelected.Rows[i].Cells[j].Text.ToString() + " ";
                }
                sHtml.Append("<tr >\r\n" + $"<td align=\"center\"colspan=\"7\"   style=\"border: 1px solid black; border-image: none;height:30px\">{drug+"元"}</td>\r\n</tr>");
            }
            //sHtml.Append("<tr >\r\n" +$"<td align=\"center\"colspan=\"7\"   style=\"border: 1px solid black; border-image: none;height:200px\">{drug}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" + $"<td align=\"center\"colspan=\"7\"  style=\"border: 1px solid black; border-image: none;text-align:left\">处方说明:{this.text_explain.Text.Trim()}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" +$"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">医师：</td>\r\n" +
                        $" <td align=\"center\" colspan=\"3\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                        $"{this.lbl_doctor.Text}</td>\r\n" +
                        $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">药品金额:</td>\r\n" +
                        $" <td align=\"center\" colspan=\"2\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                        $"{lbl_price.Text}</td>\r\n</tr>");
            sHtml.Append("<tr >\r\n" +
                        $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">审核调配：</td>\r\n" +
                        $"<td align=\"center\" colspan=\"3\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                        $"{this.text_allocate.Text}</td>\r\n" +
                        $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">核对发药:</td>\r\n" +
                        $" <td align=\"center\" colspan=\"2\" style=\"border: 1px solid black; border-image: none;\">\r\n" +
                        $"{text_Check.Text}</td>\r\n</tr>");
            //打印表尾
            sHtml.Append($"\"<tr>\\r\\n\" " +
                         $"<td align=\"center\" style=\"border: 1px solid black; border-image: none;\">打印日期</td>" +
                         $"<td align=\"center\"center\" colspan=\"6\" style=\"border: 1px solid black; border-image: none;\">{DateTime.Now}</td>" +
                         "</table>");
            //调用输出Excel表的方法
            ExportToExcel("application/ms-excel", $"就诊信息卡片.xlsx", sHtml.ToString());
        }
        /// <summary>
        /// 打印按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_print_Click(object sender, EventArgs e)
        {
            Print();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 鼠标停留在行上时变色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridDrugtable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            for (int i = 0; i <= GridDrugtable.Rows.Count; i++)
            {
                //首先判断是否是数据行
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //当鼠标停留时更改背景色
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#00A9FF'");
                    //当鼠标移开时还原背景色
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                    //单击行的任意列会自动选中此行
                    e.Row.Attributes.Add("onclick", "__doPostBack('GridView1','Select$" + e.Row.RowIndex + "')");
 
                    e.Row.Attributes["style"] = "cursor:hand";
                    PostBackOptions myPostBackOptions = new PostBackOptions(this);
                    myPostBackOptions.AutoPostBack = false;
                    myPostBackOptions.PerformValidation = false;
                    myPostBackOptions.RequiresJavaScriptProtocol = true; //加入javascript:头
                    String evt = Page.ClientScript.GetPostBackClientHyperlink(sender as GridView, "Select$" + e.Row.RowIndex.ToString());
                    e.Row.Attributes.Add("onclick", evt);
                }
            }


        }
        /// <summary>
        /// 开药
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridDrugtable_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string no = this.GridDrugtable.SelectedRow.Cells[0].Text;
            string zno=this.lbl_chufangNo.Text;
           doctorBll.ExtractRoot(no, zno);
                this.GridDrugSelected.DataBind();
             
         
        }

        protected void GridDrugtable_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
       
        
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        protected void GridDrugSelected_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void GridDrugSelected_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
  
        }

        protected void Select(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridDrugSelected_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument); // 获取被点击的行的行索引
                int row = index + GridDrugSelected.PageIndex * GridDrugSelected.PageSize; // 计算行坐标
                string name = GridDrugSelected.Rows[row].Cells[0].Text;
                SqlCommand sqlCommand6 = new SqlCommand();
                sqlCommand6.CommandText = $@"SELECT* FROM tb_Drug WHERE  Name='{name}'";
                sqlCommand6.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand6.ExecuteReader();
                string zno = this.lbl_chufangNo.Text;
                if (sqlDataReader.Read())
                {
                    string no = sqlDataReader["No"].ToString();
                    SqlCommand sqlCommand9 = new SqlCommand();
                    sqlCommand9.CommandText = $@"DELETE  tb_UseDrug WHERE DrugNo='{no}'AND ZDNo='{zno}'";
                    sqlCommand9.Connection = sqlConnection;
                    sqlCommand9.ExecuteNonQuery();
                    this.GridDrugSelected.DataBind();
                }                                                        // 处理行坐标
            }
            sqlConnection.Close();
        }
        /// <summary>
        /// 计算价格
        /// </summary>
        protected void btn_countprice_Click()
        {
            sqlConnection.Close();
            sqlConnection.Open();
            float p = 0;
            for(int i=0;i<this.GridDrugSelected.Rows.Count;i++)
            {

                TextBox txtp = new TextBox();
                txtp = (TextBox)GridDrugSelected.Rows[i].FindControl("text_num");
                p += float.Parse(txtp.Text) * float.Parse(GridDrugSelected.Rows[i].Cells[3].Text);
         
                string name = GridDrugSelected.Rows[i].Cells[0].Text;
                SqlCommand sqlCommand6 = new SqlCommand();
                sqlCommand6.CommandText = $@"SELECT* FROM tb_Drug WHERE  Name='{name}'";
                sqlCommand6.Connection = sqlConnection;
               
                SqlDataReader sqlDataReader = sqlCommand6.ExecuteReader();
                string zno = this.lbl_chufangNo.Text;
                if (sqlDataReader.Read())
                {
                    string no = sqlDataReader["No"].ToString();
                    SqlCommand sqlCommand9 = new SqlCommand();
                    sqlCommand9.CommandText = $@"UPDATE  tb_UseDrug SET Num='{float.Parse(txtp.Text)}' WHERE DrugNo='{no}'AND ZDNo='{zno}'";
                    sqlCommand9.Connection = sqlConnection;
                    sqlCommand9.ExecuteNonQuery();

                }                                                        // 处理行坐标
            }
            this.GridDrugSelected.DataBind();
            sqlConnection.Close();
            this.lbl_price.Text = p.ToString();
        }
        /// <summary>
        /// 计算函数调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_count_price(object sender, EventArgs e)
        {
            btn_countprice_Click();
        }

        protected void GridDrugtable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDrugtable.PageIndex = e.NewPageIndex;
            GridDrugtable.DataBind();
        }

        protected void GridDrugtable_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridDrugSelected_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridDrugtable_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}