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
        public int TPSWarnThreshhold;
        public int UPSWarnThreshold;
        public void LoadDefaults()
        {
            DelayBetweenChecks = 500;
            TPSWarnThreshhold = 45;
            UPSWarnThreshold = 55;
        }
    }
}
