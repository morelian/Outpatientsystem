using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outpatientsystem.Modle;

namespace Outpatientsystem.BusinessLogicLayer
{
    /// <summary>
    /// 用户逻辑层
    /// </summary>
    internal interface IUserBll
    {
        /// <summary>
		/// 用户号最小长度；
		/// </summary>
		int UserNoMinLength { get; }
        /// <summary>
        /// 用户号最大长度；
        /// </summary>
        int UserNoMaxLength { get; }
        /// <summary>
        /// 是否完成登录；
        /// </summary>
        bool HasLoggedIn { get; }
        /// <summary>
        /// 是否完成注册；
        /// </summary>
        bool HasSignedUp { get; }
        /// <summary>
        /// 消息；
        /// </summary>
        string Message { get; }
        /// <summary>
        /// 检查是否存在；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>是否存在</returns>
        bool CheckExist(string userNo);
        /// <summary>
        /// 检查是否不存在；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>是否不存在</returns>
        bool CheckNotExist(string userNo);
        /// <summary>
        /// 登录；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        User LogIn(string userNo, string password);
        /// <summary>
        /// 注册；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        User SignUp(string userNo, string password, string phone, string email, string name, bool gender);
        /// <summary>
        /// 用户支付
        /// </summary>
        /// <returns></returns>
        void Pay(User User,float money, string no);
        /// <summary>
        /// 用户预约
        /// </summary>
        void yy(User User,string docno);
        /// <summary>
        /// 取消预约
        /// </summary>
        void cancelyy(User User, string yyno);

        User changepw(User user, string pw);
        User changename(User user, string name);
        void changeimage(User user, string filename);
    }
}
