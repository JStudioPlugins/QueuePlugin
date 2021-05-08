using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using SDG.Unturned;
using UnityEngine.Assertions.Must;

namespace QueuePlugin
{
    public class QueuePlugin : RocketPlugin<QueuePluginConfiguration>
    {
        private static System.Timers.Timer aTimer;
        public static QueuePlugin Instance { get; private set; }
        protected override void Load()
        {
            Logger.Log("QueuePlugin is now loaded!");
            Instance = this;
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
        }

        private void Events_OnPlayerConnected(Rocket.Unturned.Player.UnturnedPlayer player)
        {
            SetTimer();
            void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                if (player.HasPermission("queue.pass") == false)
                {
                    if (Provider.clients.Count() >= Configuration.Instance.PlayerLimit)
                    {
                        UnturnedChat.Say(player, QueuePlugin.Instance.Translate("QueueRemind"));
                    }
                }
            }
            void SetTimer()
            {
                // Create a timer with a two second interval.
                aTimer = new System.Timers.Timer(Configuration.Instance.AutoRemind);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
            if (Provider.clients.Count() >= Configuration.Instance.PlayerLimit)
            {
                if (player.HasPermission("queue.pass"))
                {
                    UnturnedChat.Say(player, QueuePlugin.Instance.Translate("QueueSucceed"));
                    Logger.Log($"{player.DisplayName} has been let into the server via priority queue!");
                }
                else
                {
                    player.Kick(QueuePlugin.Instance.Translate("ExceedKick", Configuration.Instance.PlayerLimit));
                    Logger.Log($"{player.DisplayName} has been kicked since they do not have priority queue!");
                }
            }
        }

        protected override void Unload()
        {
            Logger.Log("QueuePlugin is now unloaded!");
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "ExceedKick", "This server has exceeded the queue amount of {0}" },
            { "QueueSucceed", "You have been let into the server via priority queue!" },
            { "QueueRemind", "Priority Queue is on!" },
            { "BuyQueue", "You can get priority queue at {0}" },
            { "QueueCommand", "You currently have priority queue! Max players without priority is currently {0}!" }
        };
    }
}
