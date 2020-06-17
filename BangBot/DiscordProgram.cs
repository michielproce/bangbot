using System;
using System.Reflection;
using System.Threading.Tasks;
using BangBot.Command;
using BangBot.Output;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace BangBot
{
    public class DiscordProgram
    {
        private DiscordSocketClient client;
        private CommandProcessor commandProcessor;
        private ulong guildId;
        private ulong channelId;

        public async Task MainAsync(string[] args)
        {
            string token = args[1];
            guildId = UInt64.Parse(args[2]);
            channelId = UInt64.Parse(args[3]);
            
            client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += OnMessageReceived;
                        
            commandProcessor = new CommandProcessor();
            Out.main = new DiscordOutput(client, guildId, channelId);
            
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task OnMessageReceived(SocketMessage msg)
        {
            if (msg.Channel.Id != channelId)
            {
                return Task.CompletedTask;
            }

            if (msg.Author.Id == client.CurrentUser.Id || msg.Author.IsBot)
            {
                return Task.CompletedTask; 
            }

            commandProcessor.Process($"{msg.Author.Username}#{msg.Author.Discriminator}", msg.Content);
            
            return Task.CompletedTask;
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}