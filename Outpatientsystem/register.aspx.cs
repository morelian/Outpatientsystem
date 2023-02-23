using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Windows;
using Outpatientsystem.BusinessLogicLayer;
using Outpatientsystem.Modle;

namespace Outpatientsystem
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         UserBll UserBll=new UserBll();
          User User;
        protected void Buttonreg_Click(object sender, EventArgs e)
        {
            //string n;
            //if (this.CheckBox1.Checked) n = "女";
            //else n = "男";
            //SqlConnection sqlConnection = new SqlConnection();                                          //声明并实例化SQL连接；
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;                   //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();                                      //调用SQL连接的方法CreateCommand来创建SQL命令；该命令将绑定SQL连接；
            //sqlCommand.CommandText =
            //    $@"INSERT tb_User (No,Password,Name,Gender,Phone,Email) VALUES(@No,HASHBYTES('MD5',@Password),
            //           @Name,@Gender,@Phone,@Email);";                 //指定SQL命令的命令文本；命令文本包含参数；
            //sqlCommand.Parameters.AddWithValue("@No", this.TextBoxid.Text.Trim());                     //向SQL命令的参数集合添加参数的名称、值；
            //sqlCommand.Parameters.AddWithValue("@Password", this.TextBoxpw.Text.Trim());
            //sqlCommand.Parameters.AddWithValue("Name",this.TextBoxname.Text.Trim());
            //sqlCommand.Parameters.AddWithValue("Email",this.TextBoxemail.Text.Trim());
            //sqlCommand.Parameters.AddWithValue("Gender", n);
            //sqlCommand.Parameters.AddWithValue("Phone",this.TextBoxphone.Text.Trim());
            //sqlCommand.Parameters["@Password"].SqlDbType = SqlDbType.VarChar;                           //将密码参数的类型设为变长字符串；
            //                                                                                            //SQL参数自动识别类型；若参数值为字符串，则类型自动设为NVARCHAR，且可在执行时自动转换；但对于相同密码，VARCHAR/NVARCHAR类型所获得的散列值不同，故需手动将SQL参数类型统一设为VARCHAR;
            //int rowAffected = 0;                                                                        //声明整型变量，用于保存受影响行数；
            //try                                                                                         //尝试；
            //{
            //    sqlConnection.Open();                                                                   //打开SQL连接；
            //    rowAffected = sqlCommand.ExecuteNonQuery();                                             //调用SQL命令的方法ExecuteNonQuery来执行命令，向数据库写入数据，并返回受影响行数；
            //}
            //catch (SqlException sqlEx)                                                                  //捕捉SQL异常；
            //{
            //    if (sqlEx.Number == 2627)                                                               //若SQL异常编号为2627，则违反主键/唯一约束，即插入重复值；
            //    {
            //        this.Labelmgls.Text = "此用户已存在";
            //        this.Labelmgls.Visible = true;//给出适当的错误提示；
            //    }
            //    else
            //    {
            //        this.Labelmgls.Text = "注册失败！请联系管理员！";
            //        this.Labelmgls.Visible = true;//显示错误提示；
            //    }
            //}
            //finally                                                                                     //结束；
            //{
            //    sqlConnection.Close();                                                                  //关闭SQL连接；
            //}
            //if (rowAffected == 1)                                                                       //若成功写入1行记录；
            //{
            //    this.Labelmgls.Text = "注册成功！";
            //    this.Labelmgls.Visible = true;//显示正确提示；
            //}
            //else                                                                                        //否则；
            //{
            //    this.Labelmgls.Text = "注册失败！";
            //    this.Labelmgls.Visible = true;//显示错误提示；
            //}
            string userNo = this.TextBoxid.Text.Trim();
            string userPassword = this.TextBoxpw.Text.Trim(); 
            this.User = this.UserBll.SignUp(userNo, userPassword,TextBoxname.Text,TextBoxphone.Text,TextBoxemail.Text,this.CheckBox1.Checked);
            MessageBox.Show(this.UserBll.Message);
            
        }
    }
}