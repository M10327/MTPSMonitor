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
            if (Provider.debugTPS <= Configuration.Instance.WarnThreshhold)
            {
                Rocket.Core.Logging.Logger.LogWarning($"TPS Drop detected. Current TPS: {Provider.debugTPS}");
            }
        }

        protected override void Unload()
        {
            aTimer.Stop();
            aTimer.Elapsed -= OnTimedEvent;
        }
    }
}
