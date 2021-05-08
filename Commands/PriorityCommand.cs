using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;

namespace QueuePlugin.Commands
{
    class PriorityCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "priority";

        public string Help => "Tells you where to get priority queue!";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "queue.main" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (player.HasPermission("queue.pass"))
            {
                UnturnedChat.Say(caller, QueuePlugin.Instance.Translate("BuyQueue", QueuePlugin.Instance.Configuration.Instance.BuyLink));
            }
        }
    }
}
