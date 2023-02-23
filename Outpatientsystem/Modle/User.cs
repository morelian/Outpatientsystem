using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outpatientsystem.Modle
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户号；
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 密码（加密）；
        /// </summary>
        public byte[] Password { get; set; }
        /// <summary>
        /// 是否激活；
        /// </summary>
        public bool IsActivated { get; set; }
        /// <summary>
        /// 登录错误次数；
        /// </summary>
        public int LoginFailCount { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string PhotoFile {get;set;}

        /// <summary>
        /// 违约标记
        /// </summary>
        public int ViolationRecord { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public float Balance { get; set; }

    }
}