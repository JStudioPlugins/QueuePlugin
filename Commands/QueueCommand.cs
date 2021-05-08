using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Chat;

namespace QueuePlugin.Command
{
    class QueueCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "queue";

        public string Help => "Gives you info on the queue";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "queue.pass" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedChat.Say(caller, QueuePlugin.Instance.Translate("QueueCommand", QueuePlugin.Instance.Configuration.Instance.PlayerLimit));
        }
    }
}
