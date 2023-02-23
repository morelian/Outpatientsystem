using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Outpatientsystem.Modle;
namespace Outpatientsystem.DataAccessLayer
{
    /// <summary>
    /// EduBase数据库上下文（基类）
    /// </summary>
    public abstract partial class EduBase : DbContext
    {
		public EduBase(string nameOrConnectionString)
			: base(nameOrConnectionString)
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
