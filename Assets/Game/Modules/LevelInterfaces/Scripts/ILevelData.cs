using System.Collections.Generic;
using SpaceShooter.Game.Level.Events;

namespace Game.Modules.LevelInterfaces.Scripts
{
    public interface ILevelData
    {
        public List<ILevelEventData> GameLevelEvents { get; }
    }
}