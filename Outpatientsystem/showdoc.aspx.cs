using Microsoft.SqlServer.Server;
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
        public SqlConnection sqlConnection = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            string no = "2230105001";
            if (Request.QueryString["医生编号"] != null)
            {
                no= Request.QueryString["医生编号"].ToString();
            }
  
            if (!IsPostBack) {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT D.Name AS '姓名',T.Name AS 'title',D.Photo AS '照片',D.Introduction AS'介绍' FROM tb_Doctor AS D JOIN tb_Pro_title AS T ON T.No=D.ProtitleNo WHERE D.No=@No;";
                sqlCommand.Parameters.AddWithValue("@No", no);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    this.Laname.Text = sqlDataReader["姓名"].ToString()+"  ";
                    this.Image1.ImageUrl = sqlDataReader["照片"].ToString();
                    this.title.Text = sqlDataReader["title"].ToString();
                    this.Laintroduction.Text= "介绍："+sqlDataReader["介绍"].ToString();
                }
               
                sqlConnection.Close();
            }
     
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
          int a=  e.NewSelectedIndex;
            
        }

        protected void yy_Click(object sender, EventArgs e)
        {
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            sqlConnection.Open();
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string wkno = GridView1.Rows[row].Cells[0].Text.ToString(); 
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            sqlCommand1.CommandText = $@"SELECT  * FROM tb_Booking AS B WHERE B.WorkNo='{wkno}';";
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            if (reader.Read())
            {
                Response.Write("<script language='javascript'>alert('此时间端已被预约!');</script>");
            }
            else
            {
                SqlCommand sqlCommand2 = new SqlCommand();
                sqlCommand2.Connection = sqlConnection;
                SqlCommand sqlCommand3 = new SqlCommand();
                sqlCommand3.Connection = sqlConnection;
                sqlCommand3.CommandText = $@"SELECT TOP 1 * FROM tb_Booking AS M ORDER BY NO DESC";
                SqlDataReader sqlDataReader1 = sqlCommand3.ExecuteReader();
                string No = "101";
                if (sqlDataReader1.Read())
                {
                    No = (int.Parse(sqlDataReader1["No"].ToString()) + 1).ToString();
                }

                sqlCommand2.CommandText = $"INSERT INTO tb_Booking (No,WorkNo,UserNo) VALUES('{No}','{wkno}','{Session["No"].ToString()}')";
                sqlCommand2.ExecuteNonQuery();
                Response.Write("<script language='javascript'>alert('预约成功!');</script>");
                GridView1.Rows[row].Cells[3].Text = "否";
            }
            sqlConnection.Close();

        }
    }
}