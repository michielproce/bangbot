using System;
using System.Linq;
using BangBot.Output;
using Discord;
using Discord.WebSocket;

namespace BangBot
{
    public class DiscordOutput : IOutput
    {
        private DiscordSocketClient client;
        private ulong guildId;
        private ulong channelId;

        public DiscordOutput(DiscordSocketClient client, ulong guildId, ulong channelId)
        {
            this.client = client;
            this.guildId = guildId;
            this.channelId = channelId;
        }

        public void Write(params string[] messages)
        {
            client.GetGuild(guildId).GetTextChannel(channelId).SendMessageAsync(string.Join("\n", messages));
        }

        public void WritePrivate(string user, params string[] messages)
        {
            SocketGuildUser socketUser = client.GetGuild(guildId).Users.First(o => string.Equals($"{o.Username}#{o.Discriminator}", user));
            socketUser.SendMessageAsync(string.Join("\n", messages));
        }
    }
}