using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows;
using Outpatientsystem.DataAccessLayer;

using System.Security.Cryptography;
using System.Text;

namespace Outpatientsystem.DataAccessLayer
{
    public class UserDal:IUserDal
    {
        /// <summary>
		/// 查询用户计数;
		/// </summary>
		/// <param name="userNo">用户号</param>
		/// <returns>计数</returns>
        /// 
        public int SelectCount(string userNo)
        => EfHelper.SelectCount<User>(u => u.No == userNo);
        //public int SelectCount(string userNo)
        //      {
        //          string commandtext= $"SELECT COUNT(*) FROM tb_User" +
        //              $" WHERE No=@No";
        //          SqlHelper sqlHelper = new SqlHelper(commandtext);
        //          //SqlConnection sqlConnection = new SqlConnection();
        //          //sqlConnection.ConnectionString =
        //          //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
        //          //SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
        //          //sqlCommand1.CommandText =
        //          //    $"SELECT COUNT(*) FROM tb_User" +
        //          //    $" WHERE No=@No";
        //          //sqlHelper.NewParameter("@No", userNo);

        //          ////sqlCommand1.CommandType = CommandType.StoredProcedure;
        //          //sqlCommand1.Parameters.AddWithValue("@No", userNo);
        //          //sqlConnection.Open();
        //          //int count = /*(int)sqlCommand1.ExecuteScalar();*/
        //                int count = sqlHelper.NonQuery();
        //          //sqlConnection.Close();
        //          return count;
        //      }
        /// <summary>
        /// 查询用户；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>用户</returns>
        public User Select(string userNo)
        {
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = $"SELECT * FROM tb_User WHERE No=@No";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@No", userNo);
            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            User user = null;
            string commandtext = $"SELECT * FROM tb_User WHERE No=@No";
            SqlHelper sqlHelper = new SqlHelper(commandtext);
            sqlHelper.NewParameter("@No", userNo);
            sqlHelper.GenerateReader();
            if (sqlHelper.Reader.Read())
            {
                user = new User()
                {
                    No = userNo,
                    Name= sqlHelper.Reader["Name"].ToString(),
                    Password = (byte[])sqlHelper.Reader["Password"],
                    IsActivated = !(bool)sqlHelper.Reader["ViolationRecord"],
                    LoginFailCount = (int)sqlHelper.Reader["FailCount"],
                    PhotoFile= sqlHelper.Reader["Photo"].ToString(),
                };
            }
            sqlHelper.Close();
            //sqlDataReader.Close();
            return user;
        }
        /// <summary>
        /// 更新用户；
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        public int Update(User user)
        {
            string commandtext = "UPDATE tb_User SET FailCount=@FailCount WHERE No=@No AND Password=@PassWord";
            SqlHelper sqlHelper = new SqlHelper(commandtext);
            sqlHelper.NewParameter("@No", user.No);
            sqlHelper.NewParameter("@Password", user.Password);
            sqlHelper.NewParameter("@FailCount", user.LoginFailCount);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "UPDATE tb_User SET FailCount=@FailCount WHERE No=@No AND Password=@PassWord";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@No", user.No);
            //sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            ////sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
            //sqlCommand.Parameters.AddWithValue("@FailCount", user.LoginFailCount);
            //sqlConnection.Open();
            int rowAffected = sqlHelper.NonQuery();
            sqlHelper.Close();
            return rowAffected;
        }
        /// <summary>
        /// 插入用户；
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        public int Insert(User user)
        {
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = $@"INSERT tb_User (No,Password,Name,Gender,Phone,Email,FailCount) VALUES(@No,HASHBYTES('MD5',@Password),
            //           @Name,@Gender,@Phone,@Email,@FailCount);";
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            string commandtext= $@"INSERT tb_User (No,Password,Name,Gender,Phone,Email,FailCount) VALUES(@No,HASHBYTES('MD5',@Password),
                       @Name,@Gender,@Phone,@Email,@FailCount);";
            SqlHelper sqlHelper = new SqlHelper(commandtext);
            sqlHelper.NewParameter("@No", user.No);
            sqlHelper.NewParameter("@Password", user.Password);
            sqlHelper.NewParameter("@Name", user.Name);
            sqlHelper.NewParameter("@Gender", user.Gender);
            sqlHelper.NewParameter("@Phone", user.Phone);
            sqlHelper.NewParameter("@Email", user.Email);
            sqlHelper.NewParameter("@FailCount", user.LoginFailCount);
            //sqlCommand.Parameters.AddWithValue("@No", user.No);
            //sqlCommand.Parameters.AddWithValue("@Password", user.Password);
            //sqlCommand.Parameters.AddWithValue("@Name", user.Name);
            //sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
            //sqlCommand.Parameters.AddWithValue("@Phone", user.Phone);
            //sqlCommand.Parameters.AddWithValue("@Email", user.Email);
            //sqlCommand.Parameters.AddWithValue("@FailCount", user.LoginFailCount);
            //sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
            int rowAffected = 0;
            try
            {
                //sqlConnection.Open();
                rowAffected = sqlHelper.NonQuery();
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 2627)
                {
                    throw new ApplicationException("您提交的用户号已存在");
                }
                throw sqlEx;
            }
            finally
            {
                sqlHelper.Close();
            }
            return rowAffected;
        }
        /// <summary>
        /// 用户预约
        /// </summary>
        /// <param name="kono">预约编号</param>
        public void yy(User User, string kono)
        {
            string CommandText = $@"SELECT * FROM tb_User WHERE No='{User.No}'";
            SqlHelper sqlHelper = new SqlHelper(CommandText);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //SqlCommand sqlCommand4 = new SqlCommand();
            //sqlCommand4.Connection = sqlConnection;
            //sqlCommand4.CommandText = $@"SELECT * FROM tb_User WHERE No='{User.No}'";
            //SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
            sqlHelper.GenerateReader();
            if (sqlHelper.Reader.Read())
            {

                if (sqlHelper.Reader["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlHelper.Reader["Betitled"].ToString()) > DateTime.Now)
                {
                    MessageBox.Show($"你已经在一个月内连续违约2次当前不可预约!解封时间{DateTime.Parse(sqlHelper.Reader["Betitled"].ToString())}");
                    return;
                }
                else if (sqlHelper.Reader["ViolationRecord"].ToString() == "True" && DateTime.Parse(sqlHelper.Reader["Betitled"].ToString()) <= DateTime.Now)
                {   string CommandText1 = $@"UPDATE tb_User SET ViolationRecord=0  WHERE No='{User.No}'";
                    SqlHelper sqlHelper1 = new SqlHelper(CommandText1);
                    //SqlCommand sqlCommand1 = new SqlCommand();
                    //sqlConnection = sqlCommand1.Connection;
                    //sqlCommand1.CommandText = $@"UPDATE tb_User SET ViolationRecord=0  WHERE No='{User.No}'";
                    //sqlCommand1.ExecuteNonQuery();
                    sqlHelper1.NonQuery();
                    sqlHelper1.Close();
                }
            }
            sqlHelper.Close();
            string CommandText2 = $@"SELECT * FROM UWYView AS U WHERE U.患者编号='{User.No}';";
            SqlHelper sqlHelper2 = new SqlHelper(CommandText2);
            //sqlCommand.CommandText = $@"SELECT * FROM UWYView AS U WHERE U.患者编号='{User.No}';";
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlHelper2.GenerateReader();
            if (sqlHelper2.Reader.Read())
            {
                if (int.Parse(sqlHelper2.Reader["数量"].ToString()) >= 2)
                {

                    //SqlCommand sqlCommand2 = new SqlCommand();
                    //sqlCommand2.Connection = sqlConnection;
                    //sqlCommand2.CommandText = $@"UPDATE tb_User SET Betitled=(SELECT MAX(W.Time+30)  FROM tb_Booking AS B
                    //                            JOIN tb_Worksheet AS W ON W.No=B.WorkNo
                    //                            WHERE B.UserNo='{User.No}'AND B.Deal=0),ViolationRecord=1 WHERE No='{User.No}';
                    //                            UPDATE tb_Booking SET Deal=1 WHERE UserNo='{User.No}';";
                    //sqlCommand2.ExecuteNonQuery();
                    string commandtext3= $@"UPDATE tb_User SET Betitled=(SELECT MAX(W.Time+30)  FROM tb_Booking AS B
                                                JOIN tb_Worksheet AS W ON W.No=B.WorkNo
                                                WHERE B.UserNo='{User.No}'AND B.Deal=0),ViolationRecord=1 WHERE No='{User.No}';
                                                UPDATE tb_Booking SET Deal=1 WHERE UserNo='{User.No}';";
                    SqlHelper sqlHelper3= new SqlHelper(commandtext3);
                    sqlHelper3.NonQuery();
                    sqlHelper3.Close();
                    MessageBox.Show("你已经在一个月内连续违约2次当前不可预约!");
                }
                sqlHelper2.Close();
            }
            else
            {
                string CommandText5 = $@"SELECT  * FROM tb_Booking AS B WHERE B.WorkNo='{kono}';";
                SqlHelper sqlHelper5 = new SqlHelper(CommandText5);
                //SqlCommand sqlCommand1 = new SqlCommand();
                //sqlCommand1.Connection = sqlConnection;
                //sqlCommand1.CommandText = $@"SELECT  * FROM tb_Booking AS B WHERE B.WorkNo='{kono}';";
                //SqlDataReader reader = sqlCommand1.ExecuteReader();
                sqlHelper5.GenerateReader();
                if (sqlHelper5.Reader.Read())
                {
                    MessageBox.Show("此时间端已被预约!");
                    sqlHelper5.Close();
                }
                else
                {
                    string CommandText1= $@"SELECT TOP 1 * FROM tb_Booking AS M ORDER BY NO DESC";
                    SqlHelper sqlHelper6 = new SqlHelper(CommandText1);
                    sqlHelper6.GenerateReader();
                    string No = "101";
                    if (sqlHelper6.Reader.Read())
                    {
                        No = (int.Parse(sqlHelper6.Reader["No"].ToString()) + 1).ToString();
                    }
                    string CommandText3= $"INSERT INTO tb_Booking (No,WorkNo,UserNo,Deal) VALUES('{No}','{kono}','{User.No.ToString()}','0')";
                    SqlHelper sqlHelper7= new SqlHelper(CommandText3);
                    //SqlCommand sqlCommand2 = new SqlCommand();
                    //sqlCommand2.Connection = sqlConnection;
                    //SqlCommand sqlCommand3 = new SqlCommand();
                    //sqlCommand3.Connection = sqlConnection;
                    //sqlCommand3.CommandText = $@"SELECT TOP 1 * FROM tb_Booking AS M ORDER BY NO DESC";
                    //SqlDataReader sqlDataReader1 = sqlCommand3.ExecuteReader();



                    sqlHelper7.NonQuery();
                    sqlHelper6.Close();
                    sqlHelper7.Close();
                    MessageBox.Show("预约成功!");
                    
                }

            }
    
        }
        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="yyno">预约号</param>
        public void cancelyy(User User, string yyno)
        {
            string CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{yyno}';";
            SqlHelper sqlHelper=new SqlHelper(CommandText);
            sqlHelper.GenerateReader();
            //SqlConnection sqlConnection=new SqlConnection();
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnection;
            //sqlConnection.Open();
            //sqlCommand1.CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{yyno}';";
            //SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            if (sqlHelper.Reader.Read())
            {

                MessageBox.Show("不可取消!");
                sqlHelper.Close();
                return;
            }
            else
            {
                sqlHelper.Close();
                MessageBox.Show("取消成功!");
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.Connection = sqlConnection;
                //sqlCommand.CommandText = $@"DELETE tb_Booking WHERE No='{yyno}';";
                //int n = sqlCommand.ExecuteNonQuery();
                string CommandText1 = $@"DELETE tb_Booking WHERE No='{yyno}';";
               SqlHelper sqlHelper1= new SqlHelper(CommandText);
                sqlHelper1.NonQuery();
                sqlHelper1.Close();
            }
       
        }
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="money">费用</param>
        public void Pay(User User, float money,string no)
        {
            string CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{no}';";
            SqlHelper sqlHelper = new SqlHelper(CommandText);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnection;
            //sqlConnection.Open();
            //sqlCommand1.CommandText = $"SELECT * FROM tb_Diagnosticlist AS DS WHERE DS.No='{no}';";
            //SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            sqlHelper.GenerateReader();
            if (sqlHelper.Reader.Read())
            {
                if (sqlHelper.Reader["Paid"].ToString() == "False")
                {
                    MessageBox.Show("支付成功!");
                    //SqlCommand sqlCommand = new SqlCommand();
                    //sqlCommand.Connection = sqlConnection;
                    //sqlCommand.CommandText = $@"UPDATE tb_Diagnosticlist SET Paid=1 WHERE No='{no}'";
                    //sqlCommand.ExecuteNonQuery();
                    SqlHelper sqlHelper1= new SqlHelper($@"UPDATE tb_Diagnosticlist SET Paid=1 WHERE No='{no}'");
                    sqlHelper1.NonQuery();
                    sqlHelper1.Close();
                }
                else
                {
                    MessageBox.Show("请勿多次支付!");
                }
            }
            else
            {
                MessageBox.Show("支付成功!");

            }
            sqlHelper.Close();
        }
        public void changepw(User user)
        {
            SqlHelper sqlHelper = new SqlHelper("UPDATE tb_User SET Password=@PassWord WHERE No=@No ");
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "UPDATE tb_User SET Password=@PassWord WHERE No=@No ";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlHelper.NewParameter("@No", user.No);
            sqlHelper.NewParameter("@Password", user.Password);

            int rowAffected = sqlHelper.NonQuery();
            sqlHelper.Close();
        }
        public void changename(User user)
        {
            SqlHelper sqlHelper = new SqlHelper("UPDATE tb_User SET Name=@Name WHERE No=@No ");
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "UPDATE tb_User SET Name=@Name WHERE No=@No ";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlHelper.NewParameter("@No", user.No);
            sqlHelper.NewParameter("@Name", user.Name);
          
            int rowAffected = sqlHelper.NonQuery();
            sqlHelper.Close();
        }

       public void changeimage(User user)
        {
            SqlHelper sqlHelper = new SqlHelper("UPDATE tb_User SET Photo=@Photofile WHERE No=@No ");
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "UPDATE tb_User SET Photo=@Photofile WHERE No=@No ";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlHelper.NewParameter("@No", user.No);
            sqlHelper.NewParameter("@Photofile", user.PhotoFile);
    
            int rowAffected = sqlHelper.NonQuery();
            sqlHelper.Close();
        }

    }
}