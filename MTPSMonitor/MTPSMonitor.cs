using Rocket.Core.Plugins;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MTPSMonitor
{
    public class MTPSMonitor : RocketPlugin<config>
    {
        private static Timer aTimer;
        protected override void Load()
        {
            aTimer = new System.Timers.Timer(Configuration.Instance.DelayBetweenChecks);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (!Level.isLoaded) return;
            if (Configuration.Instance.TPSWarnThreshhold != -1 && Provider.debugTPS <= Configuration.Instance.TPSWarnThreshhold)
            {
                Rocket.Core.Logging.Logger.LogWarning($"TPS Drop detected. Current TPS: {Provider.debugTPS}");
            }
            if (Configuration.Instance.UPSWarnThreshold != -1 && Provider.debugUPS <= Configuration.Instance.UPSWarnThreshold)
            {
                Rocket.Core.Logging.Logger.LogWarning($"UPS Drop detected. Current UPS: {Provider.debugUPS}");
            }
        }

        protected override void Unload()
        {
            aTimer.Stop();
            aTimer.Elapsed -= OnTimedEvent;
        }
    }
}
