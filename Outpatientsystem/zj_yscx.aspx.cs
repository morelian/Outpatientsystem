using Outpatientsystem.BusinessLogicLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Outpatientsystem
{
    public partial class zj_yscx : System.Web.UI.Page
    {
        private SqlConnection sqlConnection=new SqlConnection();
        IUserBll userBll=new UserBll();
        IDoctorBll doctorBll=new DoctorBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            if (!IsPostBack)
            {
                Treebind();
                doctorbind("2230105001");
            }
         
        }
        private void doctorbind(string no)
        {
            //sqlConnection.Close();
            //sqlConnection.Open();
            //string no =dno;
            //    SqlCommand sqlCommand = new SqlCommand();
            //    sqlCommand.Connection = sqlConnection;
            //    sqlCommand.CommandText = "SELECT D.Name AS '姓名',T.Name AS 'title',D.Photo AS '照片',D.Introduction AS'介绍' FROM tb_Doctor AS D JOIN tb_Pro_title AS T ON T.No=D.ProtitleNo WHERE D.No=@No;";
            //    sqlCommand.Parameters.AddWithValue("@No", no);

            //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //    if (sqlDataReader.Read())
            //    {
            //        this.Laname.Text = sqlDataReader["姓名"].ToString() + "  ";
            //        this.Image1.ImageUrl = sqlDataReader["照片"].ToString();
            //        this.title.Text = sqlDataReader["title"].ToString();
            //        this.Laintroduction.Text = "介绍：" + sqlDataReader["介绍"].ToString();
            //    }

            //    sqlConnection.Close();
            DoctorModle doctor = doctorBll.Show(no);
            this.Laname.Text = doctor.Name + "  ";
            this.Image1.ImageUrl = doctor.PhotoFile;
            this.title.Text = doctor.Title;
            this.Laintroduction.Text = "介绍：" + doctor.Concent;
        }
        private void Treebind()
        {
            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = "SELECT * FROM tb_Keshi;SELECT * FROM tb_Doctor";
            DataSet dataSet = this.doctorBll.buildkesitree();

            //SqlDataAdapter sqlDataAdapter=new SqlDataAdapter();
            //sqlDataAdapter.SelectCommand = sqlCommand;
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //sqlDataAdapter.Fill(dataSet);
            DataTable kesitable = dataSet.Tables[0];
            DataTable doctortable = dataSet.Tables[1];
            DataRelation[] dataRelations =                                                              //声明数据关系数组；
            {
                new DataRelation                                                                        //实例化数据关系，实现院系表、专业表之间的层次关系；
                    ("Keshi_Doctor",                                                                //数据关系名称；
                     kesitable.Columns["No"],                                                     //父表的被参照列为院系表的编号列；
                     doctortable.Columns["keshiNo"]),                                                //子表的参照列为专业表的院系编号列；不要求后端数据库在子表的参照列上创建外键约束；                                                 //子表的参照列为班级表的专业编号列；
            };
            dataSet.Relations.AddRange(dataRelations);
            TreeNode basicnode =new TreeNode();
            basicnode.Text = "科室";
            tree_doc.Nodes.Add(basicnode);
            foreach(DataRow keshirow in kesitable.Rows)
            {
                TreeNode newnode = new TreeNode();
                newnode.Text = keshirow["Name"].ToString();
                basicnode.ChildNodes.Add(newnode);
                foreach(DataRow doctorrow in keshirow.GetChildRows("Keshi_Doctor"))
                {
                  
                    TreeNode chnode=new TreeNode();
                    chnode.Text = doctorrow["Name"].ToString();
                    chnode.Value = doctorrow["No"].ToString();
                    newnode.ChildNodes.Add(chnode);
                }
            }
            this.tree_doc.ExpandDepth = 1;
        }

        protected void yy_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string wkno = GridView1.Rows[row].Cells[0].Text.ToString();
            this.userBll.yy(Login.User, wkno);
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //SqlCommand sqlCommand4 = new SqlCommand();
            //sqlCommand4.Connection = sqlConnection;
            //sqlCommand4.CommandText = $@"SELECT * FROM tb_User WHERE No='{Session["No"]}'";
            //SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            //if (sqlDataReader2.Read())
            //{

            //    if (sqlDataReader2["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlDataReader2["Betitled"].ToString()) > DateTime.Now)
            //    {
            //        Response.Write($"<script language='javascript'>alert('你已经在一个月内连续违约2次当前不可预约!解封时间{DateTime.Parse(sqlDataReader2["Betitled"].ToString())}');</script>");
            //        return;
            //    }
            //    else if (sqlDataReader2["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlDataReader2["Betitled"].ToString()) <= DateTime.Now)
            //    {
            //        SqlCommand sqlCommand1 = new SqlCommand();
            //        sqlConnection = sqlCommand1.Connection;
            //        sqlCommand1.CommandText = $@"UPDATE tb_User SET ViolationRecord=0  WHERE No='{Session["No"]}'";
            //        sqlCommand1.ExecuteNonQuery();

            //    }
            //}
            //sqlCommand.CommandText = $@"SELECT * FROM UWYView AS U WHERE U.患者编号='{Session["No"].ToString()}';";
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //if (sqlDataReader.Read())
            //{
            //    if (int.Parse(sqlDataReader["数量"].ToString()) >= 2)
            //    {
            //        SqlCommand sqlCommand2 = new SqlCommand();
            //        sqlCommand2.Connection = sqlConnection;
            //        sqlCommand2.CommandText = $@"UPDATE tb_User SET Betitled=(SELECT MAX(W.Time+30)  FROM tb_Booking AS B
            //                                    JOIN tb_Worksheet AS W ON W.No=B.WorkNo
            //                                    WHERE B.UserNo='{Session["No"]}'AND B.Deal=0),ViolationRecord=1 WHERE No='{Session["No"]}';
            //                                    UPDATE tb_Booking SET Deal=1 WHERE UserNo='{Session["No"]}';";
            //        sqlCommand2.ExecuteNonQuery();
            //        Response.Write("<script language='javascript'>alert('你已经在一个月内连续违约2次当前不可预约!');</script>");
            //    }
            //}
            //else
            //{
            //    int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            //    string wkno = GridView1.Rows[row].Cells[0].Text.ToString();
            //    SqlCommand sqlCommand1 = new SqlCommand();
            //    sqlCommand1.Connection = sqlConnection;
            //    sqlCommand1.CommandText = $@"SELECT  * FROM tb_Booking AS B WHERE B.WorkNo='{wkno}';";
            //    SqlDataReader reader = sqlCommand1.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        Response.Write("<script language='javascript'>alert('此时间端已被预约!');</script>");
            //    }
            //    else
            //    {
            //        SqlCommand sqlCommand2 = new SqlCommand();
            //        sqlCommand2.Connection = sqlConnection;
            //        SqlCommand sqlCommand3 = new SqlCommand();
            //        sqlCommand3.Connection = sqlConnection;
            //        sqlCommand3.CommandText = $@"SELECT TOP 1 * FROM tb_Booking AS M ORDER BY NO DESC";
            //        SqlDataReader sqlDataReader1 = sqlCommand3.ExecuteReader();
            //        string No = "101";
            //        if (sqlDataReader1.Read())
            //        {
            //            No = (int.Parse(sqlDataReader1["No"].ToString()) + 1).ToString();
            //        }

            //        sqlCommand2.CommandText = $"INSERT INTO tb_Booking (No,WorkNo,UserNo,Deal) VALUES('{No}','{wkno}','{Session["No"].ToString()}','0')";
            //        sqlCommand2.ExecuteNonQuery();
            //        Response.Write("<script language='javascript'>alert('预约成功!');</script>");
            //        GridView1.Rows[row].Cells[3].Text = "否";
            //    }

            //}
            //sqlConnection.Close();
        }

        protected void tree_doc_SelectedNodeChanged(object sender, EventArgs e)
        {
            long number;
            string selectedValue = tree_doc.SelectedNode.Value;
            if (long.TryParse(selectedValue, out number))
                doctorbind(selectedValue);
            else return;

        }
    }
}