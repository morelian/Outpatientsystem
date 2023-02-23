using Outpatientsystem.DataAccessLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Outpatientsystem.BusinessLogicLayer
{
    public class DoctorBll:IDoctorBll
    {
        /// <summary>
        /// 医生（数据访问层）；
        /// </summary>
         IDoctorDal DoctorDal { get; set; }
        /// <summary>
        /// 登录失败次数上限；
        /// </summary>
        private int LogInFailCountMax => 3; 
        ///<summary>
        /// 医生号最小长度；
        /// </summary>
        public int DoctorNoMinLength => 10;
        /// <summary>
        /// 医生号最大长度；
        /// </summary>
        public int DoctorNoMaxLength => 10;
        /// <summary>
        /// 是否完成登录；
        /// </summary>
        public bool HasLoggedIn { get; private set; }
        /// <summary>
        /// 是否完成注册；
        /// </summary>
        public bool HasSignedUp { get; private set; }
        /// <summary>
        /// 消息；
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// MD5加密；
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <returns>密文</returns>
        private byte[] Md5(string plainText)
        {
            byte[] plainBytes = Encoding.Default.GetBytes(plainText);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] cryptedBytes = md5.ComputeHash(plainBytes);
            return cryptedBytes;
        }
        /// <summary>
        /// MD5值是否相等；
        /// </summary>
        /// <param name="md5">MD5值</param>
        /// <param name="otherPlainText">另一明文</param>
        /// <returns>是否相等</returns>
        private bool Md5Equal(byte[] md5, string otherPlainText)
        => md5.SequenceEqual(this.Md5(otherPlainText));
        /// <summary>
        /// 处理医生不存在；
        /// </summary>
        /// <param name="user">医生</param>
        private void HandleUserNotExist(DoctorModle user)
        {
            if (user == null)
            {
                string errorMessage = "医生号不存在！";
                throw new ApplicationException(errorMessage);
            }
        }
        /// <summary>
        /// 处理医生被冻结；
        /// </summary>
        /// <param name="user">医生</param>
        private void HandleUserNotActivated(DoctorModle user)
        {
            if (!user.IsActivated)
            {
                string errorMessage = "医生已被冻结，需要手机验证！";
                throw new ApplicationException(errorMessage);
            }
        }
        /// <summary>
        /// 处理医生登录失败次数过多；
        /// </summary>
        /// <param name="user">医生</param>
        private void HandleUserLoginFailTooManyTimes(DoctorModle user)
        {
            if (user.LoginFailCount >= this.LogInFailCountMax)
            {
                user.IsActivated = false;
                this.DoctorDal.Update(user);
            }
        }
        /// <summary>
        /// 处理医生登录失败；
        /// </summary>
        /// <param name="user">医生</param>
        private void HandleUserLoginFail(DoctorModle user)
        {
            user.LoginFailCount++;
            this.DoctorDal.Update(user);
        }
        /// <summary>
        /// 处理医生密码错误；
        /// </summary>
        /// <param name="user">医生</param>
        /// <param name="password">密码</param>
        private void HandleUserPasswordNotMatch(DoctorModle user, string password)
        {
            bool isPasswordMatch = this.Md5Equal(user.Password, password);
            if (!isPasswordMatch)
            {
                this.HandleUserLoginFail(user);
                this.HandleUserLoginFailTooManyTimes(user);
                string errorMessage =
                    user.IsActivated ?
                    $"密码错误，请重新输入！\n您还有{this.LogInFailCountMax - user.LoginFailCount}次机会！"
                    : $"密码错误已达{this.LogInFailCountMax}次上限！";
                throw new ApplicationException(errorMessage);
            }
        }
        /// <summary>
        /// 处理医生登录成功；
        /// </summary>
        /// <param name="user">医生</param>
        private void HandleUserLoginOk(DoctorModle user)
        {
            if (user.LoginFailCount != 0)
            {
                user.LoginFailCount = 0;
                this.DoctorDal.Update(user);
            }
            this.HasLoggedIn = true;
            this.Message = "登录成功。";
        }
        /// <summary>
        /// 检查是否存在；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <returns>是否存在</returns>
        public bool CheckExist(string userNo)
        => this.DoctorDal.SelectCount(userNo) == 1;
        /// <summary>
        /// 检查是否不存在；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <returns>是否不存在</returns>
        public bool CheckNotExist(string userNo)
        => !this.CheckExist(userNo);
        /// <summary>
        /// 登录；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <param name="password">密码</param>
        /// <returns>医生</returns>
        public DoctorModle LogIn(string userNo, string password)
        {
            this.HasLoggedIn = false;
            DoctorModle user = this.DoctorDal.Select(userNo);
            try
            {
                this.HandleUserNotExist(user);
                this.HandleUserNotActivated(user);
                this.HandleUserPasswordNotMatch(user, password);
                this.HandleUserLoginOk(user);
            }
            catch (ApplicationException ex)
            {
                this.Message = ex.Message;
            }
            catch (Exception)
            {
                this.Message = "登录失败！";
            }
            return user;
        }
        /// <summary>
        /// 注册；
        /// </summary>
        /// <param name="userNo">医生号</param>
        /// <param name="password">密码</param>
        /// <returns>医生</returns>
        public DoctorModle SignUp(string userNo, string password, string name, string phone, string email, bool gender)
        {
            this.HasSignedUp = false;
            DoctorModle user = new DoctorModle()
            {
                No = userNo,
                Password = Md5(password),
                IsActivated = true,
                Phone = phone,
                Email = email,
                Name = name,
                Gender = gender,
                LoginFailCount = 0
            };
            try
            {
                this.DoctorDal.Insert(user);
                this.HasSignedUp = true;
                this.Message = "注册成功。";
            }
            catch (ApplicationException ex)
            {
                this.Message = $"{ex.Message}\n注册失败！";
            }
            catch (Exception)
            {
                this.Message = "注册失败！";
            }
            return user;
        }
        /// <summary>
        /// 构造函数；
        /// </summary>
        public DoctorBll()
        {
            this.DoctorDal = new DcotorDal();
        }
        /// <summary>
        /// 开药
        /// </summary>
        /// <param name="no">药品编号</param>
        /// <param name="zno">诊单编号</param>
        public void ExtractRoot(string no,string zno)
        {
            this.DoctorDal.ExtractRoot(no, zno);
        }

        public DoctorModle Show(string no)
        {
          return  DoctorDal.Show(no);
        }
        public DataTable buildtable()
        {
            return this.DoctorDal.buildtable();
        }
       public DataTable WorksheetShow()
        {
            return this.DoctorDal.WorksheetShow();
        }
        public DataSet buildkesitree()
        {
            return this.DoctorDal.buildkesitree();
        }
    }
}