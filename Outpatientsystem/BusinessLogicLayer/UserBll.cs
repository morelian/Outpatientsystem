﻿using Outpatientsystem.DataAccessLayer;
using Outpatientsystem.Modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Outpatientsystem.BusinessLogicLayer
{
    public class UserBll:IUserBll
    {
        /// <summary>
		/// 用户（数据访问层）；
		/// </summary>
		private IUserDal UserDal { get; set; }
        /// <summary>
        /// 登录失败次数上限；
        /// </summary>
        private int LogInFailCountMax => 3;
        /// <summary>
        /// 用户号最小长度；
        /// </summary>
        public int UserNoMinLength => 7;
        /// <summary>
        /// 用户号最大长度；
        /// </summary>
        public int UserNoMaxLength => 10;
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
        /// 处理用户不存在；
        /// </summary>
        /// <param name="user">用户</param>
        private void HandleUserNotExist(User user)
        {
            if (user == null)
            {
                string errorMessage = "用户号不存在！";
                throw new ApplicationException(errorMessage);
            }
        }
        /// <summary>
        /// 处理用户被冻结；
        /// </summary>
        /// <param name="user">用户</param>
        private void HandleUserNotActivated(User user)
        {
            if (!user.IsActivated)
            {
                string errorMessage = "用户已被冻结，需要手机验证！";
                throw new ApplicationException(errorMessage);
            }
        }
        /// <summary>
        /// 处理用户登录失败次数过多；
        /// </summary>
        /// <param name="user">用户</param>
        private void HandleUserLoginFailTooManyTimes(User user)
        {
            if (user.LoginFailCount >= this.LogInFailCountMax)
            {
                user.IsActivated = false;
                this.UserDal.Update(user);
            }
        }
        /// <summary>
        /// 处理用户登录失败；
        /// </summary>
        /// <param name="user">用户</param>
        private void HandleUserLoginFail(User user)
        {
            user.LoginFailCount++;
            this.UserDal.Update(user);
        }
        /// <summary>
        /// 处理用户密码错误；
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">密码</param>
        private void HandleUserPasswordNotMatch(User user, string password)
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
        /// 处理用户登录成功；
        /// </summary>
        /// <param name="user">用户</param>
        private void HandleUserLoginOk(User user)
        {
            if (user.LoginFailCount != 0)
            {
                user.LoginFailCount = 0;
                this.UserDal.Update(user);
            }
            this.HasLoggedIn = true;
            this.Message = "登录成功。";
        }
        /// <summary>
        /// 检查是否存在；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>是否存在</returns>
        public bool CheckExist(string userNo)
        => this.UserDal.SelectCount(userNo) == 1;
        /// <summary>
        /// 检查是否不存在；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <returns>是否不存在</returns>
        public bool CheckNotExist(string userNo)
        => !this.CheckExist(userNo);
        /// <summary>
        /// 登录；
        /// </summary>
        /// <param name="userNo">用户号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        public User LogIn(string userNo, string password)
        {
            this.HasLoggedIn = false;
            User user = this.UserDal.Select(userNo);
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
        /// <param name="userNo">用户号</param>
        /// <param name="password">密码</param>
        /// <returns>用户</returns>
        public User SignUp(string userNo, string password,string name,string phone,string email,bool gender)
        {
            this.HasSignedUp = false;
            User user = new User()
            {
                No = userNo,
                Password = Md5(password),
                IsActivated = true,
                Phone = phone,
                Email = email,
                Name = name,
                Gender = gender,
                LoginFailCount= 0
            };
            try
            {
                this.UserDal.Insert(user);
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
        public UserBll()
        {
            this.UserDal = new UserDal();
        }
        /// <summary>
        /// 用户预约
        /// </summary>
        /// <param name="docno">医生编号</param>
        public void yy(User User, string docno)
        {
            this.UserDal.yy(User, docno);
        }
        /// <summary>
        /// 取消预约
        /// </summary>
        /// <param name="yyno">预约号</param>
        public void cancelyy(User User, string yyno) 
        {
            this.UserDal.cancelyy(User, yyno);
        }
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="money">费用</param>
        public void Pay(User User, float money,string no)
        {
            this.UserDal.Pay(User, money,no);
        }
        public User changepw(User user, string pw)
        {
            user.Password = Md5(pw);
            this.UserDal.changepw(user);
            this.Message = "修改成功";
            return user;
        }
       public User changename(User user, string name)
        {
            user.Name = name;
            this.UserDal.changename(user);
            this.Message = "修改成功";
            return user;
        }
      public  void changeimage(User user, string filename)
        {
            user.PhotoFile= filename;
            this.UserDal.changeimage(user);
            this.Message = "修改成功";
        }
    }
}