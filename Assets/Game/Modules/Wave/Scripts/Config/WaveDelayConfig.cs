// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveDelayConfig.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Wave.Config
{
    [CreateAssetMenu(
        fileName = "WaveDelayConfig",
        menuName = "SpaceShooter/Wave/WaveDelayConfig")]
    public sealed class WaveDelayConfig : WaveConfig
    {
        [SerializeField] private float duration;
        
        public override IWaveData GetWaveData()
        {
            return new WaveDelayData(duration);
        }
    }

    public struct WaveDelayData : IWaveData
    {
        public float Duration { get; private set; }
        
        public WaveDelayData(float duration)
        {
            Duration = duration;
        }
    }
}