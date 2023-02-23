using Microsoft.SqlServer.Server;
using Outpatientsystem.BusinessLogicLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Outpatientsystem
{
    public partial class showdoc : System.Web.UI.Page
    {
        private IUserBll UserBll=new UserBll();
        private IDoctorBll DoctorBll=new DoctorBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string no = "2230105001";
            if (Request.QueryString["医生编号"] != null)
            {
                no= Request.QueryString["医生编号"].ToString();
            }
  
            if (!IsPostBack) {
              DoctorModle doctor=  DoctorBll.Show(no);
                //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.Connection = sqlConnection;
                //sqlCommand.CommandText = "SELECT D.Name AS '姓名',T.Name AS 'title',D.Photo AS '照片',D.Introduction AS'介绍' FROM tb_Doctor AS D JOIN tb_Pro_title AS T ON T.No=D.ProtitleNo WHERE D.No=@No;";
                //sqlCommand.Parameters.AddWithValue("@No", no);
                //sqlConnection.Open();
                //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //if (sqlDataReader.Read())
                //{
                this.Laname.Text = doctor.Name + "  ";
                this.Image1.ImageUrl = doctor.PhotoFile;
                this.title.Text = doctor.Title;
                this.Laintroduction.Text = "介绍：" + doctor.Concent;
                //}

                //sqlConnection.Close();
            }
     
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
          int a=  e.NewSelectedIndex;
            
        }
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void yy_Click(object sender, EventArgs e)
        {
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //sqlConnection.Open();
            //SqlCommand sqlCommand= new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //SqlCommand sqlCommand4 = new SqlCommand();
            //sqlCommand4.Connection = sqlConnection;
            //sqlCommand4.CommandText = $@"SELECT * FROM tb_User WHERE No='{Session["No"]}'";
            //SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            //if (sqlDataReader2.Read())
            //{
              
            //    if (sqlDataReader2["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlDataReader2["Betitled"].ToString())>DateTime.Now)
            //    {
            //        Response.Write($"<script language='javascript'>alert('你已经在一个月内连续违约2次当前不可预约!解封时间{DateTime.Parse(sqlDataReader2["Betitled"].ToString())}');</script>");
            //        return;
            //    }
            //    else if(sqlDataReader2["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlDataReader2["Betitled"].ToString())<=DateTime.Now)
            //        {
            //        SqlCommand sqlCommand1 = new SqlCommand();
            //        sqlConnection= sqlCommand1.Connection;
            //        sqlCommand1.CommandText = $@"UPDATE tb_User SET ViolationRecord=0  WHERE No='{Session["No"]}'";
            //        sqlCommand1.ExecuteNonQuery();
                   
            //         }
            //}
            //sqlCommand.CommandText = $@"SELECT * FROM UWYView AS U WHERE U.患者编号='{Session["No"].ToString()}';";
            //SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();
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
                int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
                string wkno = GridView1.Rows[row].Cells[0].Text.ToString();
                UserBll.yy(Login.User,wkno);
            Response.Redirect("showdoc.aspx?医生编号=2230105001");
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
    }
}