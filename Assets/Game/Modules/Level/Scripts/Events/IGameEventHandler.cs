using System.Threading;
using Cysharp.Threading.Tasks;

namespace SpaceShooter.Game.Level.Events
{
    public interface IGameEventHandler
    {
        public UniTask Start();
    }
}