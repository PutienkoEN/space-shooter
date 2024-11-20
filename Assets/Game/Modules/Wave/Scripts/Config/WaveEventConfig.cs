// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveDelayConfig.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Wave.Config
{
    [CreateAssetMenu(
        fileName = "WaveEventConfig",
        menuName = "SpaceShooter/Wave/WaveEventConfig")]
    public sealed class WaveEventConfig : WaveConfig
    {
        public override IWaveData GetWaveData()
        {
            return new WaveEventData();
        }
    }

    public struct WaveEventData : IWaveData
    {
        
    }
}