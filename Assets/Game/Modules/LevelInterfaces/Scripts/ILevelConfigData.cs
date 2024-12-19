using System.Collections.Generic;
using SpaceShooter.Game.Level.Events;

namespace Game.Modules.LevelInterfaces.Scripts
{
    public interface ILevelConfigData
    {
        public List<ILevelEventData> GameLevelEvents { get; }
    }
}