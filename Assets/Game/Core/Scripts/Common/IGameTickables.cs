// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: IGameTickables.cs
// ------------------------------------------------------------------------------

namespace SpaceShooter.Game.Core.Common
{
    public interface IGameTickable
    {
        void Tick(float deltaTime);
    }
    
    public interface IGameFixedTickable
    {
        void FixedTick(float deltaTime);
    }
    
    public interface IGameLateTickable
    {
        void LateTick(float deltaTime);
    }
}