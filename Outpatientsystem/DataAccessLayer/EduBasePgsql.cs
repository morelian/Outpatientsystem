﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outpatientsystem.DataAccessLayer
{
    using Npgsql;
    using Outpatientsystem.Modle;
    using System;
    using System.Data.Entity;
    /// <summary>
    /// EduBase数据库上下文（基于PostgreSQL）；
    /// </summary>
    public partial class EduBasePgsql : MyDbContext
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public EduBasePgsql()
            : base("name=EduBasePgsql")
        {
        }
        /// <summary>
        /// 实体集（用户）；
        /// </summary>
        public virtual DbSet<User> User { get; set; }
        /// <summary>
        /// 创建模型时；
        /// </summary>
        /// <param name="modelBuilder">模型建造器</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<User>().ToTable("tb_user");
            modelBuilder.Entity<User>()
                .Property(e => e.No)
                .IsFixedLength()
                .IsUnicode(false)
                .HasColumnName("no");
            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasColumnName("password");
            modelBuilder.Entity<User>()
                .Property(e => e.IsActivated)
                .HasColumnName("is_activated");
            modelBuilder.Entity<User>()
                .Property(e => e.LoginFailCount)
                .HasColumnName("login_fail_count");
        }
        /// <summary>
        /// 保存更改；
        /// </summary>
        /// <param name="notUniqueErrorMessage">不唯一错误消息</param>
        /// <returns>受影响行数</returns>
        public override int SaveChanges(string notUniqueErrorMessage)
        {
            int rowAffected = 0;
            try
            {
                rowAffected = this.SaveChanges();
            }
            catch (Exception ex)
            {
                NpgsqlException pgsqlEx = ex.InnerException.InnerException as NpgsqlException;
                if (pgsqlEx.Message.Substring(0, 5) == "23505")
                {
                    throw new ApplicationException(notUniqueErrorMessage);
                }
                throw;
            }
            return rowAffected;
        }
    }
}