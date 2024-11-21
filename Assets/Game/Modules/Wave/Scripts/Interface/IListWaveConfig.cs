// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: IListWaveConfig.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Game.Modules.Wave.Interface
{
    public interface IListWaveConfig
    {
        IReadOnlyList<IWaveData> GetListWaveConfig();
    }
}