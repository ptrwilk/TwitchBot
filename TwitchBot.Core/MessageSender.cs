using System.Net.Sockets;

namespace TwitchBot.Core;

public class MessageSender
{
    public void Send()
    {
        string twitchUsername = "";
        string twitchOAuth = "";
        string twitchChannel = "";

        using (TcpClient client = new TcpClient("irc.chat.twitch.tv", 6667))
        using (StreamReader reader = new StreamReader(client.GetStream()))
        using (StreamWriter writer = new StreamWriter(client.GetStream()))
        {
            writer.WriteLine($"PASS {twitchOAuth}");
            writer.WriteLine($"NICK {twitchUsername}");
            writer.WriteLine($"JOIN #{twitchChannel}");
            writer.Flush();

            writer.WriteLine($"PRIVMSG #{twitchChannel} :{"!rip"}");
            writer.Flush();
        }
    }
}