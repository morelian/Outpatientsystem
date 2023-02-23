using Outpatientsystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Outpatientsystem
{
    public partial class Worksheet : System.Web.UI.Page
    {
        string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        public SqlConnection sqlConnection = new SqlConnection();
        /// <summary>
        /// 工作表
        /// </summary>
        public DataTable WorkTable;
        /// <summary>
        /// 工作表视图
        /// </summary>
        public DataView WorkView;

        IDoctorBll doctorBll= new DoctorBll();
        protected void Page_Load(object sender, EventArgs e)
        {

            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;


            //    sqlConnection.Open();
            //    SqlCommand sqlCommand = new SqlCommand();
            //    SqlCommand sqlCommand2 = new SqlCommand();
            //    sqlCommand.Connection = sqlConnection;
            //    sqlCommand.CommandText = "SELECT No AS '编号',Dno AS '医师编号',Name '医师姓名',ks AS '科室',zc AS '职称',Time AS '时间' FROM WkView";
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //    sqlDataAdapter.SelectCommand = sqlCommand;
            //    sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //    //打开SQL连接；
            //    sqlDataAdapter.Fill(this.WorkTable); //SQL数据适配器读取数据，并填充课程数据表；
            //    sqlConnection.Close();
            //    DataColumn[] pk = new DataColumn[] { WorkTable.Columns[0], WorkTable.Columns[1] };
            //    WorkTable.PrimaryKey = pk;
            WorkTable = doctorBll.WorksheetShow();
                this.GridView1.DataSource = WorkTable;
                this.WorkView = new DataView(WorkTable);
                this.WorkView.Sort = "编号 ASC";
            
            ChangeTimeToWeek();
            GridView1.DataBind();
        }

        /// <summary>
        /// 把时间转换成星期
        /// </summary>
        private void ChangeTimeToWeek( )
        {
            for(int i=0;i<GridView1.Rows.Count;i++)
            {
                GridView1.Rows[i].Cells[6].Text = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            }
          
        }


        protected void drop_ks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] searchResultRowViews =
               this.WorkTable.Select($"科室 LIKE '%{this.drop_ks.Text.Trim()}%'");                                //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
            DataTable searchResultTable = this.WorkTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRow dataRow in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
            {
                searchResultTable.ImportRow(dataRow);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
            }
            this.GridView1.DataSource = searchResultTable;
            ChangeTimeToWeek();
            this.GridView1.DataBind();
        }

        protected void drop_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] searchResultRowViews =
               this.WorkTable.Select($"时间 LIKE '%{this.drop_time.Text}%'");                                //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
            DataTable searchResultTable = this.WorkTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRow dataRow in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
            {
                searchResultTable.ImportRow(dataRow);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
            }
            this.GridView1.DataSource = searchResultTable;
            ChangeTimeToWeek();
            this.GridView1.DataBind();
        }


    }
}