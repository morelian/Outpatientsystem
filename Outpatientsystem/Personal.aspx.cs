using Outpatientsystem.BusinessLogicLayer;
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
 
         IUserBll UserBll = new UserBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["No"] is null)
            {
                Response.Redirect("Login.aspx");
            }


            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = "SELECT * FROM tb_User WHERE No=@No;";
            //sqlCommand.Parameters.AddWithValue("@No", Session["No"].ToString());
            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //if (sqlDataReader.Read())
            //{
            //    this.lbname.Text = sqlDataReader["Name"].ToString();
            //    this.Image1.ImageUrl = sqlDataReader["Photo"].ToString();
            //}
            ////sqlConnection.Close();
            this.lbname.Text = Login.User.Name;
            this.Image1.ImageUrl = Login.User.PhotoFile;
        }




        /// <summary>
        /// 改头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.CommandText = $"UPDATE tb_User SET Photo='{this.Image1.ImageUrl}' WHERE No='{Session["No"]}'";
                ////sqlConnection.Open();
                //sqlCommand.Connection= sqlConnection;
                //sqlCommand.ExecuteNonQuery();
                ////sqlConnection.Close();
                this.UserBll.changeimage(Login.User,this.Image1.ImageUrl);
               
            }
        }
        /// <summary>
        /// 改名字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Buttonchangename_Click(object sender, EventArgs e)
        {
            this.UserBll.changename(Login.User, this.Textnewname.Text);
            ////sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.CommandText = $"UPDATE tb_User SET Name={this.Textnewname} WHERE No='{Session["No"].ToString()}'";
            ////sqlConnection.Open();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.ExecuteNonQuery();
            ////sqlConnection.Close();
            //Response.Write("<script language='javascript'>alert('修改成功!');</script>");
            this.lbname.Text = this.Textnewname.Text;
        }


        /// <summary>
        /// 改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Buttonchangepw_Click(object sender, EventArgs e)
        {
            this.UserBll.changepw(Login.User, this.Textnew1.Text.Trim());
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.CommandText = $"UPDATE tb_User SET Password=HASHBYTES('MD5','{this.Textnew1.Text.Trim()}') WHERE No='{Session["No"].ToString()}'";
            //sqlConnection.Open();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.ExecuteNonQuery();
            //sqlConnection.Close();
            //Response.Write("<script language='javascript'>alert('修改成功!');</script>");
        }
       /// <summary>
       /// 取消预约
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        protected void yy_Click(object sender, EventArgs e)
        {

 
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string no = GridView1.Rows[row].Cells[0].Text.ToString();
            UserBll.cancelyy(Login.User, no);
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnection;
            //sqlConnection.Open();
            //sqlCommand1.CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{no}';";
            //SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            //if (sqlDataReader1.Read()) 
            //{
            //    return;
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>alert('取消成功!');</script>");
            //    SqlCommand sqlCommand = new SqlCommand();
            //    sqlCommand.Connection = sqlConnection;
            //    sqlCommand.CommandText = $@"DELETE tb_Booking WHERE No='{no}';";
            //    int n = sqlCommand.ExecuteNonQuery();
            //    Response.Redirect("Personal.aspx");
            //}
            Response.Redirect("Personal.aspx");
        }
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pay_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string no = GridView1.Rows[row].Cells[0].Text.ToString();
            UserBll.Pay(Login.User, 1, no);
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnection;
            //sqlConnection.Open();
            //sqlCommand1.CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{no}';";
            //SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            //if (sqlDataReader1.Read() )
            //{
            //    if (sqlDataReader1["Paid"].ToString() == "False")
            //    {
            //        Response.Write("<script language='javascript'>alert('支付成功!');</script>");
            //        SqlCommand sqlCommand = new SqlCommand();
            //        sqlCommand.Connection = sqlConnection;
            //        sqlCommand.CommandText = $@"UPDATE tb_Diagnosticlist SET Paid=1 WHERE No='{no}'";
            //        sqlCommand.ExecuteNonQuery();
            //    }
            //    else
            //    {
            //        Response.Write("<script language='javascript'>alert('请勿多次支付!');</script>");
            //    }
            //}
            //else
            //{
            //    Response.Write("<script language='javascript'>alert('还未就诊!');</script>");
                
            //}
           
        }
    }
}