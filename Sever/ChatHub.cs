
using Microsoft.AspNetCore.SignalR;

namespace Sever
{
    public class ChatHub:Hub
    {
        private static Dictionary<string, string> dictUsers = new Dictionary<string, string>();


        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"ID:{Context.ConnectionId} 已连接");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"ID:{Context.ConnectionId} 已断开");
            return base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// 向客户端发送信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Task Send(string msg)
        {
            return Clients.Caller.SendAsync("SendMessage", msg);
        }

        /// <summary>
        /// 登录功能，将用户ID和ConntectionId关联起来
        /// </summary>
        /// <param name="userId"></param>
        public void Login(string userId)
        {
            if (!dictUsers.ContainsKey(userId))
            {
                dictUsers[userId] = Context.ConnectionId;
            }
            Console.WriteLine($"{userId}登录成功，ConnectionId={Context.ConnectionId}");
            //向所有用户发送当前在线的用户列表
            Clients.All.SendAsync("Users", dictUsers.Keys.ToList());
        }

        /// <summary>
        /// 一对一聊天
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="targetUserId"></param>
        /// <param name="msg"></param>
        public void Chat(string userId, string targetUserId, string msg)
        {
            string newMsg = $"{userId}|{msg}";//组装后的消息体
            //如果当前用户在线
            if (dictUsers.ContainsKey(targetUserId))
            {
                Clients.Client(dictUsers[targetUserId]).SendAsync("ChatInfo", newMsg);
            }
            else
            {
                //如果当前用户不在线，正常是保存数据库，等上线时加载，暂时不做处理
            }
        }

        /// <summary>
        /// 退出功能，当客户端退出时调用
        /// </summary>
        /// <param name="userId"></param>
        public void Logout(string userId)
        {
            if (dictUsers.ContainsKey(userId))
            {
                dictUsers.Remove(userId);
            }
            Console.WriteLine($"{userId}退出成功，ConnectionId={Context.ConnectionId}");
        }


    }
}
