using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outpatientsystem.BusinessLogicLayer
{
    internal interface IDoctorBll
    {
        /// <summary>
        /// 医生号最小长度；
        /// </summary>
        int DoctorNoMinLength { get; }
        /// <summary>
        /// 医生号最大长度；
        /// </summary>
        int DoctorNoMaxLength { get; }
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
        /// <param name="userNo">医生号</param>
        /// <returns>是否存在</returns>
        bool CheckExist(string userNo);
        /// <summary>
        /// 检查是否不存在；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <returns>是否不存在</returns>
        bool CheckNotExist(string userNo);
        /// <summary>
        /// 登录；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        DoctorModle LogIn(string userNo, string password);
        /// <summary>
        /// 注册；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <param name="password">密码</param>
        /// <returns>医生</returns>
        DoctorModle SignUp(string userNo, string password, string phone, string email, string name, bool gender);
        /// <summary>
        /// 开药
        /// </summary>
        /// <param name="No">药品编号</param>
        /// <param name="zno">诊单编号</param>
        void ExtractRoot(string No,string zno);
        DoctorModle Show(string no);
        DataTable buildtable();
        DataTable WorksheetShow();
        DataSet buildkesitree();
    }
}
