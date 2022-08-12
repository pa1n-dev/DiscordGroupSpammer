using System;
using System.Collections.Generic;
using System.Threading;
using Discord;
using Discord.Gateway;

namespace DiscordGroupSpammer
{
    class Program
    {
        public static string token;
        public static ulong[] targets = new ulong[2];

        static void Main(string[] args)
        {
            Console.Title = "DiscordGroupSpammer by somestuff.tech";

            Console.Write("Token: ");
            token = Console.ReadLine();

            Console.Write("TargetID: ");
            targets[0] = UInt64.Parse(Console.ReadLine());

            Console.Write("TargetID: ");
            targets[1] = UInt64.Parse(Console.ReadLine());

            DiscordClient client = new DiscordClient(token, new DiscordConfig() { RetryOnRateLimit = true });

            for(; ; )
            {
                DiscordGroup group = client.CreateGroup(new List<ulong> { targets[0], targets[1] });
                 
                for (int i = 0; i < 5; i++)
                    group.SendMessageAsync(new MessageProperties() { Content = " @everyone https://i.gifer.com/14ll.gif" });

                Console.WriteLine("[" + DateTime.Now + "] Group created: " + group.Id);
            }
        }
    }
}
