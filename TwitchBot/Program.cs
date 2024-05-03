// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using TwitchBot;
using TwitchBot.Data;
using TwitchBot.Factories;
using TwitchBot.Models;

var sender = new MessageSender();
var reader = new KeyReader();
var darkSoulsLogic = new DarkSoulsLogic(new DarkSouls());

var context = new DataContextFactory().Create(DatabaseType.DeadAlive);

var zzzz = context.Results.ToList();

darkSoulsLogic.CharacterDied += () =>
{
  // Console.WriteLine("DIED");
   //sender.Send();
};

reader.KeyPressed += () =>
{
   sender.Send();
};
reader.Start();


Console.WriteLine("cxzczxcx");
Console.ReadKey();


// var swed = new Swed("DarkSoulsRemastered");
//
// var moduleBase = swed.GetModuleBase("DarkSoulsRemastered.exe");
//
// var address = swed.ReadPointer(moduleBase, 0x01C77E50, 0x68, 0x7B8, 0x70, 0x60, 0x468, 0x578) + 0x14;
//
// var hp = swed.ReadInt(address);
//
// Console.WriteLine($"TEST {hp}");
//
// Console.ReadKey();
//
// int[] offsets2 = { 0x14, 0x578, 0x468, 0x60, 0x70, 0x7B8, 0x68 };
// int[] offsets = { 0x68 , 0x7B8, 0x70, 0x60, 0x468, 0x578, 0x14 };

//
// string twitchUsername = "iamnotapeppapig";
// string twitchOAuth = "oauth:h549qtme2joytof1g892ttgzb11l42";
// string twitchChannel = "Hexaners";
//
// using (TcpClient client = new TcpClient("irc.chat.twitch.tv", 6667))
// using (StreamReader reader = new StreamReader(client.GetStream()))
// using (StreamWriter writer = new StreamWriter(client.GetStream()))
// {
//     writer.WriteLine($"PASS {twitchOAuth}");
//     writer.WriteLine($"NICK {twitchUsername}");
//     writer.WriteLine($"JOIN #{twitchChannel}");
//     writer.Flush();
//     
//     writer.WriteLine($"PRIVMSG #{twitchChannel} :{"!rip"}");
//     writer.Flush();
// }