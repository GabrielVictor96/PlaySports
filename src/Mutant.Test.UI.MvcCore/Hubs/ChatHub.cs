﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PlaySports.Models;
using PlaySports.Repositories;
using System.Threading.Tasks;

namespace PlaySports.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionsRepository _connections = new ConnectionsRepository();

        /// <summary>
        /// Override para inserir cada usuário no nosso repositório, lembrando que esse repositório está em memória
        /// </summary>
        /// <returns> Retorna lista de usuário no chat e usuário que acabou de logar </returns>
        public override Task OnConnectedAsync()
        {
            var user = JsonConvert.DeserializeObject<User>(Context.GetHttpContext().Request.Query["user"]);
            _connections.Add(Context.ConnectionId, user);
            //Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
            Clients.All.SendAsync("chat", _connections.GetAllUser(), user);
            return base.OnConnectedAsync();
        }


        /// <summary>
        /// Método responsável por encaminhar as mensagens pelo hub
        /// </summary>
        /// <param name="ChatMessage">Este parâmetro é nosso objeto representando a mensagem e os usuários envolvidos</param>
        /// <returns></returns>
        public async Task SendMessage(Message chat)
        {
            //Ao usar o método Client(_connections.GetUserId(chat.destination)) eu estou enviando a mensagem apenas para o usuário destino, não realizando broadcast
            await Clients.Client(_connections.GetUserId(chat.destination)).SendAsync("Receive", chat.sender, chat.message);
        }

        public IEnumerable<string> GetAllUsers()
        {
            return _connections.GetAllUser().Select(x => x.name);
        }
    }
}
