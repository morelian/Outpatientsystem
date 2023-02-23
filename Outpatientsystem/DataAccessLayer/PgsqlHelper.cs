using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Outpatientsystem.DataAccessLayer
{
    public class PgsqlHelper
    {
        /// <summary>
        /// PGSQL连接
        /// </summary>
        NpgsqlConnection npgsqlConnection=new NpgsqlConnection();
        /// <summary>
        /// PGSQL命令
        /// </summary>
        NpgsqlCommand npgsqlCommand=new NpgsqlCommand();
        /// <summary>
        /// PGSQL适配器
        /// </summary>
        NpgsqlDataAdapter dataAdapter=new NpgsqlDataAdapter();
        /// <summary>
        /// PGSQL读写器
        /// </summary>
        NpgsqlDataReader reader;
        /// <summary>
        /// PGSQL参数；
        /// </summary>
        private NpgsqlParameter PgsqlParameter { get; set; }
        public void CommandText(string commcandtext)
        {
            this.npgsqlCommand.CommandText = commcandtext;
        }
        public PgsqlHelper()
        {
            npgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Pgsql"].ToString();
            npgsqlConnection.Open();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="commcandtext">命令文本</param>
        public PgsqlHelper(string commcandtext)
        {
            npgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Pgsql"].ToString();
            this.npgsqlCommand = npgsqlConnection.CreateCommand();
            this.npgsqlCommand.CommandText = commcandtext;
            npgsqlConnection.Open();
        }
        public DataTable Fill()
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection();
            pgsqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["Pgsql"].ToString();
            NpgsqlCommand pgsqlCommand = pgsqlConnection.CreateCommand();
            pgsqlCommand.CommandText = "SELECT * FROM text";
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            npgsqlDataAdapter.SelectCommand = pgsqlCommand;
            DataTable table = new DataTable();
            npgsqlDataAdapter.Fill(table);
            return table;
        }

        /// <summary>
		/// 设置PGSQL命令是否存储过程；
		/// </summary>
		/// <param name="isStoredProcedure">是否存储过程</param>
		/// <returns>PGSQL助手</returns>
		public PgsqlHelper IsStoredProcedure(bool isStoredProcedure = true)
        {
            this.npgsqlCommand.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            return this;
        }
        /// <summary>
        /// 新建PGSQL参数；
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper NewParameter(string parameterName)
        {
            this.PgsqlParameter = new NpgsqlParameter();
            this.PgsqlParameter.ParameterName = parameterName;
            this.npgsqlCommand.Parameters.Add(this.PgsqlParameter);
            return this;
        }
        /// <summary>
        /// 新建PGSQL参数；
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="value">参数值</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper NewParameter(string parameterName, object value)
        {
            this.NewParameter(parameterName);
            this.PgsqlParameter.Value = value;
            return this;
        }
        /// <summary>
        /// 设置PGSQL参数的PostgreSQL数据类型；
        /// </summary>
        /// <param name="sqlDbType">PostgreSQL数据类型</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper ParameterType(NpgsqlDbType pgsqlDbType)
        {
            this.PgsqlParameter.NpgsqlDbType = pgsqlDbType;
            return this;
        }
        /// <summary>
        /// 设置PGSQL参数的长度；
        /// </summary>
        /// <param name="size">长度</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper ParameterSize(int size)
        {
            this.PgsqlParameter.Size = size;
            return this;
        }
        /// <summary>
        /// 设置PGSQL参数的值；
        /// </summary>
        /// <param name="value">参数值</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper ParameterValue(object value)
        {
            this.PgsqlParameter.Value = value;
            return this;
        }
        /// <summary>
        /// 设置PGSQL参数的方向；
        /// </summary>
        /// <param name="parameterDirection">参数方向</param>
        /// <returns>PGSQL助手</returns>
        public PgsqlHelper ParameterDirection(ParameterDirection parameterDirection)
        {
            this.PgsqlParameter.Direction = parameterDirection;
            return this;
        }
        /// <summary>
        /// 执行PGSQL命令，获取标量；
        /// </summary>
        /// <typeparam name="T">标量类型</typeparam>
        /// <returns>标量值</returns>
        public T GetScalar<T>()
        {
            object result = null;
            this.npgsqlCommand.Connection.Open();
            result = this.npgsqlCommand.ExecuteScalar();
            this.npgsqlCommand.Connection.Close();
            return (T)result;
        }
    }
}