using Blog.Common.EnumType;
using Blog.IServices;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Blog.API
{
    public class ChatHub : Hub
    {
        private readonly ILogger _logger;
            
        public ChatHub()
        {

        }
        #region 重写事件
        public override Task OnConnected()
        {
            //_logger.Log("{0}.OnConnected Success", Context.ConnectionId);
            _logger.Log(LogType.Message,Context.ConnectionId + ".OnConnected Success");
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            try
            {
                _logger.Log("{0}.OnConnected Success", Context.ConnectionId);
                _logger.Log(LogType.Message, Context.ConnectionId + ".OnReconnected Success");
            }
            catch (Exception ex)
            {
                var i = 0;
            }

            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _logger.Log("{0}.OnDisconnected Success{1}", Context.ConnectionId, stopCalled);
            DisconnectClient(Context.ConnectionId, stopCalled);

            //return base.OnDisconnected(stopCalled);
            // 缺少扩展参数
            return base.OnDisconnected(stopCalled);
        }

        private void DisconnectClient(string clientId, bool useThreshold = false)
        {
            //chatclient client = _repository.GetClientById(clientId);
            //if (client == null)
            //{
            //    _logger.Log(LogType.Message, System.DateTime.Now.ToString() + @"   Link.WebChat.Web\Hubs\ChatHub.cs 方法 DisconnectClient 报错,client == null,clientId = " + clientId);
            //    return;
            //}
            //wx_userinfo user = _repository.GetUserById(client.User_Key);
            //user.Status = (int)UserStatus.Offline;
            //_repository.Update(user);
            //if (client == null || user == null)
            //{
            //    _logger.Log("没有找到客户端或用户");
            //}
            //if (user.IsKefu == 1)
            //{
            //    //退出用户所在的所有房间
            //    var rooms = _repository.GetAllowedRooms(user.ID);
            //    foreach (var room in rooms)
            //    {
            //        var userViewModel = new UserViewModel(user);
            //        Clients.OthersInGroup(GetRoomName(room)).leave(userViewModel, GetRoomName(room));
            //    }
            //}
            //else
            //{
            //    sys_skill room = _repository.GetRoomById((int)user.SkillCode);
            //    if (room != null)
            //    {
            //        var userViewModel = new UserViewModel(user);
            //        Clients.OthersInGroup(GetRoomName(room)).leave(userViewModel, GetRoomName(room));
            //    }
            //    //离线后
            //    _repository.EndServiceSession(user.ID, 0);
            //}


            ////退出连接的客户端
            //int userid = _service.DisconnectClient(clientId);

            //if (useThreshold)
            //{
            //    Thread.Sleep(_disconnectThreshold);
            //}


            //_logger.Log("{0}:{1} disconnected", user.NickName, Context.ConnectionId);

            ////如果是客服，则需要将该客服的对话转移给别人
            //if (user.IsKefu == 1)
            //{
            //    _service.CloseChatByAgent(user);
            //}
            //else
            //{
            //    _service.CloseChatByUser(user);
            //}

            //ClientMessageViewModel mes = new ClientMessageViewModel();
            //mes.attachmentid = 0;
            //mes.content = "客户下线";
            //mes.url = "";
            //mes.id = Guid.NewGuid().ToString();
            //mes.messagetype = 99;
            //mes.roomid = 0;
            //mes.sessionid = 0;
            //mes.toopenid = "";
            //AddSystemMessage(mes, user.ID);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // _repository.Dispose();
            }

            base.Dispose(disposing);
        }


        #endregion

    }
    
    /// <summary>
    /// 日志扩展
    /// </summary>
    public static class LoggingExtensions
    {
        public static void Log(this ILogger logger, Exception exception)
        {
            logger.Log(LogType.Error, "Exception:\r\n" + exception.ToString());
        }

        public static void LogError(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogType.Error, String.Format(message, args));
        }

        public static void Log(this ILogger logger, string message, params object[] args)
        {
            logger.Log(LogType.Message, String.Format(message, args));
        }
    }
}