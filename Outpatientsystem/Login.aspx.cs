﻿using Outpatientsystem.BusinessLogicLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Outpatientsystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UserBll=new UserBll();
        }
        /// <summary>
        /// 用户；
        /// </summary>
        public static User User{ get; set; }
        /// <summary>
        /// 用户（业务逻辑层）；
        /// </summary>
        private IUserBll UserBll { get; set; }
        protected void Buttonlogin_Click(object sender, EventArgs e)
        {
            //          SqlConnection sqlConnection = new SqlConnection();                           
            //          sqlConnection.ConnectionString =
            //              "Server=(local);Database=OutpatientDemo;Integrated Security=sspi";            
            //          sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand = new SqlCommand();                           
            //          sqlCommand.Connection = sqlConnection;                                        
            //          sqlCommand.CommandText =                                                      
            //              $"SELECT COUNT(1) FROM tb_User" +
            //              $" WHERE No='{this.TextBoxid.Text.Trim()}'" +							
            //              $" AND Password=HASHBYTES('MD5','{this.TextBoxpw.Text.Trim()}');";
            //          sqlConnection.Open();                                                           
            //          int rowCount = (int)sqlCommand.ExecuteScalar();                                

            //          sqlConnection.Close();                                                        
            //          if (rowCount == 1)                                                             
            //          {
            //              Session["No"] = this.TextBoxid.Text;
            //              Response.Redirect($"Index.aspx?Id={this.TextBoxid.Text}");
            //              //
            //              //if (Request.Headers["user-agent"] != null && Request.Headers["user-agent"].ToLower().ToString().IndexOf("mozilla") != -1)
            //              //    Response.Redirect("www/index.aspx");
            //              //else
            //              //    Response.Redirect("wap/index.aspx");
            //              //
            //              Labelmgls.Text = "登陆成功";									
            //          }
            //          else                                                                          
            //          {
            //              Labelmgls.Text = "账号或者密码错误！";						
            //              this.TextBoxpw.Focus();                                                 

            //          }
            //          this.Labelmgls.Visible = true;
            Login.User = this.UserBll.LogIn(TextBoxid.Text, TextBoxpw.Text);
            MessageBox.Show(this.UserBll.Message);
            if (!this.UserBll.HasLoggedIn)
            {
                this.TextBoxid.Focus();
                return;
            }
            Session["No"] = this.TextBoxid.Text;
            MessageBox.Show($"即将打开{User.No}的主界面。");
            Response.Redirect($"Index.aspx?Id={this.TextBoxid.Text}");
        }
    }
}
