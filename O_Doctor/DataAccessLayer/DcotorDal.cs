using Outpatientsystem.BusinessLogicLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Outpatientsystem.DataAccessLayer
{
    public class DcotorDal:IDoctorDal
    {
        /// <summary>
        /// 查询医生计数;
        /// </summary>
        /// <param name="doctorno">医生号</param>
        /// <returns>计数</returns>
        public int SelectCount(string doctorno)
        {
            string commandtext = $"SELECT COUNT(*) FROM tb_Doctor" +
                $" WHERE No=@No";
            SqlHelper sqlHelper = new SqlHelper(commandtext);
            sqlHelper.NewParameter("@No", doctorno);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
            //sqlCommand1.CommandText =
            //    $"SELECT COUNT(*) FROM tb_Doctor" +
            //    $" WHERE No=@No";

            ////sqlCommand1.CommandType = CommandType.StoredProcedure;
            //sqlCommand1.Parameters.AddWithValue("@No", doctorno);
            //sqlConnection.Open();
            int count = sqlHelper.NonQuery();
            sqlHelper.Close();
            return count;
        }
        /// <summary>
        /// 查询医生；
        /// </summary>
        /// <param name="doctorno">医生号</param>
        /// <returns>医生</returns>
        public Doctor Select(string doctorno)
        {
            string CommandText = $"SELECT * FROM tb_Doctor WHERE No=@No";
            SqlHelper sqlHelper=new SqlHelper(CommandText);
            sqlHelper.NewParameter("@No", doctorno);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = $"SELECT * FROM tb_Doctor WHERE No=@No";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@No", userNo);
            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlHelper.GenerateReader();
            Doctor doctor = null;
            if (sqlHelper.Reader.Read())
            {
                doctor = new Doctor()
                {
                    No = doctorno,
                    Password = (byte[])sqlHelper.Reader["Password"],
                    IsActivated = !(bool)sqlHelper.Reader["ViolationRecord"],
                    LoginFailCount = (int)sqlHelper.Reader["FailCount"]
                };
            }
            sqlHelper.Close();
            return doctor;
        }
        /// <summary>
        /// 更新医生；
        /// </summary>
        /// <param name="doctor">医生</param>
        /// <returns>受影响行数</returns>
        public int Update(Doctor doctor)
        {
            string commandtext= "UPDATE tb_Doctor SET FailCount=@LoginFailCount WHERE No=@No AND Password=@PassWord";
            SqlHelper sqlHelper=new SqlHelper(commandtext);
            sqlHelper.NewParameter("@No", doctor.No);
            sqlHelper.NewParameter("@Password", doctor.Password);
            //sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
            sqlHelper.NewParameter("@FailCount", doctor.LoginFailCount);
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "UPDATE tb_Doctor SET FailCount=@LoginFailCount WHERE No=@No AND Password=@PassWord";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@No", doctor.No);
            //sqlCommand.Parameters.AddWithValue("@Password", doctor.Password);
            ////sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
            //sqlCommand.Parameters.AddWithValue("@FailCount", doctor.LoginFailCount);
            int rowAffected = sqlHelper.NonQuery();
            sqlHelper.Close();
            return rowAffected;
        }
        /// <summary>
        /// 插入医生；
        /// </summary>
        /// <param name="doctor">医生</param>
        /// <returns>受影响行数</returns>
        public int Insert(Doctor doctor)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["Sql"].ToString();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = $@"INSERT tb_Doctor (No,Password,Name,Gender,Phone,Email,FailCount) VALUES(@No,HASHBYTES('MD5',@Password),
                       @Name,@Gender,@Phone,@Email,@FailCount);";
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@No", doctor.No);
            sqlCommand.Parameters.AddWithValue("@Password", doctor.Password);
            sqlCommand.Parameters.AddWithValue("@Name", doctor.Name);
            sqlCommand.Parameters.AddWithValue("@Gender", doctor.Gender);
            sqlCommand.Parameters.AddWithValue("@Phone", doctor.Phone);
            sqlCommand.Parameters.AddWithValue("@Email", doctor.Email);
            sqlCommand.Parameters.AddWithValue("@FailCount", doctor.LoginFailCount);
            //sqlCommand.Parameters.AddWithValue("@IsActivated", user.IsActivated);
            int rowAffected = 0;
            try
            {
                sqlConnection.Open();
                rowAffected = sqlCommand.ExecuteNonQuery();
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
                sqlConnection.Close();
            }
            return rowAffected;
        }
        /// <summary>
        /// 开方
        /// </summary>
        /// <param name="no">药品编号</param>
        /// <param name="zno">诊单编号</param>
        public void ExtractRoot(string no,string zno)
        {
            string CommandText1 = $@"SELECT * FROM tb_UseDrug WHERE DrugNo='{no}'AND ZDNo='{zno}'";
            string CommandText2 = $@"INSERT INTO tb_UseDrug (DrugNo,ZDNo,Num) VALUES('{no}','{zno}','{1}')";
            SqlHelper sqlHelper = new SqlHelper(CommandText1);
            sqlHelper.GenerateReader();
            if (!sqlHelper.Reader.Read())
            {
                sqlHelper.Close();
                SqlHelper sqlHelper1=new SqlHelper(CommandText2);
                sqlHelper1.NonQuery();
                sqlHelper1.Close();
            }
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //sqlConnection.Open();
            //SqlCommand sqlCommand1 = new SqlCommand();
            //sqlCommand1.Connection = sqlConnection;
            //sqlCommand1.CommandText = $@"SELECT * FROM tb_UseDrug WHERE DrugNo='{no}'AND ZDNo='{zno}'";
            //SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            //if (!sqlDataReader.Read())
            //{
            //    SqlCommand sqlCommand = new SqlCommand();
            //    sqlCommand.CommandText = $@"INSERT INTO tb_UseDrug (DrugNo,ZDNo,Num) VALUES('{no}','{zno}','{1}')";
            //    sqlCommand.Connection = sqlConnection;

            //    sqlCommand.ExecuteNonQuery();
            //}
            //sqlConnection.Close();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="no">编号</param>
        /// <param name="pw">密码</param>
       public void changepw(string no, string pw)
        {

        }
        /// <summary>
        /// 展示医生基本信息
        /// </summary>
        /// <param name="No">医生编号</param>
        /// <returns></returns>
        public Doctor Show(string No)
        {
            string CommandText = $"SELECT * FROM DoctorView WHERE 编号=@No";
            SqlHelper sqlHelper=new SqlHelper(CommandText);
            sqlHelper.NewParameter("@No", No);
            sqlHelper.GenerateReader();
            Doctor user = null;
            if (sqlHelper.Reader.Read())
            {
                user = new Doctor()
                {
                    No = No,
                    PhotoFile = sqlHelper.Reader["照片"].ToString(),
                    Title = sqlHelper.Reader["职称"].ToString(),
                    Name = sqlHelper.Reader["姓名"].ToString()
                };
                
            }
            sqlHelper.Close();
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString =
            //    ConfigurationManager.ConnectionStrings["Sql"].ToString();
            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
            //sqlCommand.CommandText = $"SELECT * FROM DoctorView WHERE 编号=@No";
            ////sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@No", No);
            //sqlConnection.Open();
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //Doctor user = null;
            //if (sqlDataReader.Read())
            //{
            //    user = new Doctor()
            //    {
            //        No = No,
            //        PhotoFile= sqlDataReader["照片"].ToString(),
            //        Title = sqlDataReader["职称"].ToString(),
            //        Name = sqlDataReader["姓名"].ToString()
            //    };
            //}
            //sqlDataReader.Close();
            return user;
        }
        /// <summary>
        /// 构建table
        /// </summary>
        /// <returns></returns>
        public DataTable buildtable()
        {
            string CommandText = "SELECT * FROM DrugView";
            SqlHelper sqlHelper = new SqlHelper(CommandText);
            DataTable DrugTable= sqlHelper.Fill();
            sqlHelper.Close();
            //SqlConnection sqlConnection = new SqlConnection();
            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //SqlCommand sqlCommand= sqlConnection.CreateCommand();
            //sqlCommand.CommandText = "SELECT * FROM DrugView";
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //sqlDataAdapter.SelectCommand = sqlCommand;
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ////打开SQL连接；
            //sqlDataAdapter.Fill(DrugTable); //SQL数据适配器读取数据，并填充课程数据表；
            //sqlConnection.Close();
            DataColumn[] pk = new DataColumn[] { DrugTable.Columns[0], DrugTable.Columns[5] };
            DrugTable.PrimaryKey = pk;
            return DrugTable;
        }
      public  DataTable WorksheetShow()
        {
            string CommandText = "SELECT No AS '编号',Dno AS '医师编号',Name '医师姓名',ks AS '科室',zc AS '职称',Time AS '时间' FROM WkView";
            DataTable WorkTable = new DataTable(CommandText);
            SqlHelper sqlHelper=new SqlHelper(CommandText);
            sqlHelper.Fill(WorkTable);
            sqlHelper.Close();
            //SqlConnection sqlConnection = new SqlConnection();

            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;


            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //SqlCommand sqlCommand2 = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = "SELECT No AS '编号',Dno AS '医师编号',Name '医师姓名',ks AS '科室',zc AS '职称',Time AS '时间' FROM WkView";
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //sqlDataAdapter.SelectCommand = sqlCommand;
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ////打开SQL连接；
            //sqlDataAdapter.Fill(WorkTable); //SQL数据适配器读取数据，并填充课程数据表；
            //sqlConnection.Close();
            DataColumn[] pk = new DataColumn[] { WorkTable.Columns[0], WorkTable.Columns[1] };
            WorkTable.PrimaryKey = pk;
            return WorkTable;
        }
        public DataSet buildkesitree()
        {
            //SqlConnection sqlConnection = new SqlConnection();

            //sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

            //sqlConnection.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.CommandText = "SELECT * FROM tb_Keshi;SELECT * FROM tb_Doctor";
            //DataSet dataSet = new DataSet();
            string CommandText = "SELECT * FROM tb_Keshi;SELECT * FROM tb_Doctor";
            SqlHelper sqlHelper=new SqlHelper(CommandText);
            DataSet dataSet = sqlHelper.FillSet();
            sqlHelper.Close();
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //sqlDataAdapter.SelectCommand = sqlCommand;
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //sqlDataAdapter.Fill(dataSet);
            return dataSet;
        }
    }

}