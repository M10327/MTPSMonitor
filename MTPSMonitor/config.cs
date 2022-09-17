using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPSMonitor
{
    public class config : IRocketPluginConfiguration
    {
        public int DelayBetweenChecks;
        public int WarnThreshhold;
        public void LoadDefaults()
        {
            DelayBetweenChecks = 500;
            WarnThreshhold = 45;
        }
    }
}
