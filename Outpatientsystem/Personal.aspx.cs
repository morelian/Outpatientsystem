using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Outpatientsystem
{
    public partial class Personal : System.Web.UI.Page
    {
      public   SqlConnection sqlConnection = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["No"] is null)
            {
                Response.Redirect("Login.aspx");
            }


            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM tb_User WHERE No=@No;";
            sqlCommand.Parameters.AddWithValue("@No", Session["No"].ToString());
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.lbname.Text = sqlDataReader["Name"].ToString();
                this.Image1.ImageUrl = sqlDataReader["Photo"].ToString();
            }
            //sqlConnection.Close();
        }



 

        protected void btnphoto_Click1(object sender, EventArgs e)
        {
            string fileName;
            string fileFolder;
            string dateTime = "";
            fileName = Path.GetFileName(fupImage.PostedFile.FileName);
            dateTime += DateTime.Now.Year.ToString();
            dateTime += DateTime.Now.Month.ToString();
            dateTime += DateTime.Now.Day.ToString();
            dateTime += DateTime.Now.Hour.ToString();
            dateTime += DateTime.Now.Minute.ToString();
            dateTime += DateTime.Now.Second.ToString();
            fileName = dateTime + fileName;
            fileFolder = Server.MapPath("~/") + "Image\\" + "\\";
            fileFolder = fileFolder + fileName;
            fupImage.PostedFile.SaveAs(fileFolder);

            {
                //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
                this.Image1.ImageUrl = "\\Image" + "\\" + fileName;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = $"UPDATE tb_User SET Photo='{this.Image1.ImageUrl}' WHERE No='{Session["No"]}'";
                //sqlConnection.Open();
                sqlCommand.Connection= sqlConnection;
                sqlCommand.ExecuteNonQuery();
                //sqlConnection.Close();
            }
        }

        protected void Buttonchangename_Click(object sender, EventArgs e)
        {

            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE tb_User SET Name={this.Textnewname} WHERE No='{Session["No"].ToString()}'";
            //sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            //sqlConnection.Close();
            Response.Write("<script language='javascript'>alert('修改成功!');</script>");
        }



        protected void Buttonchangepw_Click(object sender, EventArgs e)
        {
            
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE tb_User SET Password=HASHBYTES('MD5','{this.Textnew1.Text.Trim()}') WHERE No='{Session["No"].ToString()}'";
            //sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            //sqlConnection.Close();
            Response.Write("<script language='javascript'>alert('修改成功!');</script>");
        }

        protected void yy_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('取消成功!');</script>");
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string no = GridView1.Rows[row].Cells[0].Text.ToString();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            sqlCommand1.CommandText = $@"DELETE tb_Booking WHERE No='{no}';";
         int n=  sqlCommand1.ExecuteNonQuery();
            Response.Redirect("Personal.aspx");
        }
    }
}