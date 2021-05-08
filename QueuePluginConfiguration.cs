using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Rocket.API;

namespace QueuePlugin
{
    public class QueuePluginConfiguration : IRocketPluginConfiguration
    {
        public int PlayerLimit { get; set; }
        public Int32 AutoRemind { get; set; }
        public string BuyLink { get; set; }
        public void LoadDefaults()
        {
            PlayerLimit = 5;
            AutoRemind = 600000;
            BuyLink = "www.thismightysiteisawesome.com/shop/priority";
        }
    }
}
