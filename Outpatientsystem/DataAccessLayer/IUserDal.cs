using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outpatientsystem.DataAccessLayer
{
    internal interface IUserDal
    {
        /// <summary>
		/// 插入用户；
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>受影响行数</returns>
		int Insert(User user);
        /// <summary>
        /// 查询用户；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>用户</returns>
        User Select(string userNo);
        /// <summary>
        /// 查询用户计数;
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>计数</returns>
        int SelectCount(string userNo);
        /// <summary>
        /// 更新用户；
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>受影响行数</returns>
        int Update(User user);
        /// <summary>
        /// 用户支付
        /// </summary>
        /// <returns></returns>
        void Pay(User User, float money,string orderno);
        /// <summary>
        /// 用户预约
        /// </summary>
        void yy(User User, string docno);
        /// <summary>
        /// 取消预约
        /// </summary>
        void cancelyy(User User, string yyno);
        void changepw(User user);
        void changename(User user);
        void changeimage(User user);
    }
}
