// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: IWave.cs
// ------------------------------------------------------------------------------

using System;

namespace Game.Modules.Wave.Interface
{
    public interface IWave
    {
        event Action OnWaveFinished;
        void StartWave();
        void Dispose();
    }
}