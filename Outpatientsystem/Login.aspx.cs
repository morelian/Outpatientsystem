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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonlogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();                           
            sqlConnection.ConnectionString =
                "Server=(local);Database=OutpatientDemo;Integrated Security=sspi";            
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
  SqlCommand sqlCommand = new SqlCommand();                           
            sqlCommand.Connection = sqlConnection;                                        
            sqlCommand.CommandText =                                                      
                $"SELECT COUNT(1) FROM tb_User" +
                $" WHERE No='{this.TextBoxid.Text.Trim()}'" +							
                $" AND Password=HASHBYTES('MD5','{this.TextBoxpw.Text.Trim()}');";
            sqlConnection.Open();                                                           
            int rowCount = (int)sqlCommand.ExecuteScalar();                                
                                                                                           
            sqlConnection.Close();                                                        
            if (rowCount == 1)                                                             
            {
                Labelmgls.Text = "登陆成功";									
            }
            else                                                                          
            {
                Labelmgls.Text = "账号或者密码错误！";						
                this.TextBoxpw.Focus();                                                 
  
            }
            this.Labelmgls.Visible = true;
        }
    }
}