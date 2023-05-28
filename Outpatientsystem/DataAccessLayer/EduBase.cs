using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Outpatientsystem.Modle;
namespace Outpatientsystem.DataAccessLayer
{
    /// <summary>
    /// EduBase���ݿ������ģ����ࣩ
    /// </summary>
    public abstract partial class EduBase : DbContext
    {
		public EduBase(string nameOrConnectionString)
			: base(nameOrConnectionString)
		{
		}
        /// <summary>
        /// ʵ�弯���û�����
        /// </summary>
        public virtual DbSet<User> User { get; set; }
        /// <summary>
        /// ����ģ��ʱ��
        /// </summary>
        /// <param name="modelBuilder">ģ�ͽ�����</param>
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
        /// ��ʼ�����ݿ⣻
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
