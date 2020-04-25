using BLL.Interfaces;
using BLL.ModelDTO;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly IRoomService _roomService;
        public MessageHub(IMessageService _messageService, IRoomService _roomService)
        {
            this._messageService = _messageService;
            this._roomService = _roomService;
        }

        public async Task NewMessage(string friendName, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var userName = Context.User.Claims.First().Value;
                var group = await _roomService.GetRoom(userName, friendName);
                string groupName = group.Name;
                if (!string.IsNullOrEmpty(groupName))
                {
                    var date = DateTime.Now;
                    await Clients.Group(groupName).SendAsync("MessageReceived", userName, message, date.ToString());
                    MessageDTO messageDTO = new MessageDTO { MessageText = message, SenderId = userName, ReapientId = friendName, RoomId = group.RoomId, Date = DateTime.Now };
                    await _messageService.CreateMessage(messageDTO);
                }
            }                  
        }
        public async Task Enter(string friendName)
        {
            var userName = Context.User.Claims.First().Value;
            if (String.IsNullOrEmpty(userName) && String.IsNullOrEmpty(friendName))
            {
                await Clients.Caller.SendAsync("Notify", "Для входа в чат введите логин");
            }
            else
            {
                var id = Context.ConnectionId;
                var group = await _roomService.GetRoom(userName,friendName);              
                if (group==null)
                {
                    try
                    {
                        
                        string groupName = _messageService.CodeName(userName, friendName);
                        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                        RoomDTO roomDTO = new RoomDTO { Name = groupName, FirstUserId = userName, SecondUserId = friendName  };
                        await _roomService.CreateRoom(roomDTO);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    string groupName = group.Name;
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
                }
            }
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

    }
}
