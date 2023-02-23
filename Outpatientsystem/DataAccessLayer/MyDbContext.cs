using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Outpatientsystem.DataAccessLayer
{
    /// <summary>
	/// 自定义数据库上下文；
	/// </summary>
    public abstract class MyDbContext : DbContext
    {
        /// <summary>
		/// 保存更改；
		/// </summary>
		/// <param name="message">消息</param>
		/// <returns>受影响行数</returns>
		public abstract int SaveChanges(string message);
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="nameOrConnectionString">数据库名称或连接字符串名称</param>
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            ;
        }

        /// <summary>
        /// 初始化数据库；
        /// </summary>
        /// <returns></returns>
        public static bool InitDb()
        {
            using (var eduBase = EfHelper.GetDbContext())
            {
                if (eduBase.Database.Exists())
                {
                    eduBase.Database.ExecuteSqlCommand("SELECT pg_terminate_backend(A.pid) FROM pg_stat_activity AS A WHERE A.datname='EduBaseDemo' AND A.pid<>pg_backend_pid();");
                }
                eduBase.Database.Delete();
                return eduBase.Database.CreateIfNotExists();
            }
        }
    }
}