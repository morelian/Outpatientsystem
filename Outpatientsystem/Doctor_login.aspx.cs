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
    public partial class Doctor_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static public DoctorModle doctor { get; set; }
         IDoctorBll doctorBll = new DoctorBll();
        protected void Buttonlogin_Click(object sender, EventArgs e)
        {
           doctor= doctorBll.LogIn(this.TextBoxid.Text.Trim(), this.TextBoxpw.Text.Trim());

            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    "Server=(local);Database=OutpatientDemo;Integrated Security=sspi";
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText =
            //    $"SELECT COUNT(1) FROM tb_Doctor" +
            //    $" WHERE No='{this.TextBoxid.Text.Trim()}'" +
            //    $" AND Password=HASHBYTES('MD5','{this.TextBoxpw.Text.Trim()}');";
            //sqlConnection.Open();
            //int rowCount = (int)sqlCommand.ExecuteScalar();

            //sqlConnection.Close();
            //if (rowCount == 1)
            //{
            //    Session["Id"] = this.TextBoxid.Text;
            Response.Redirect($"Doctor_Index.aspx?Id={this.TextBoxid.Text}");
            //    Labelmgls.Text = "登陆成功";
            //}
            //else
            //{
            //    Labelmgls.Text = "账号或者密码错误！";
            //    this.TextBoxpw.Focus();

            //}
            //this.Labelmgls.Visible = true;

        }
    }
}