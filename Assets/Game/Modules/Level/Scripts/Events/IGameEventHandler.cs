using Cysharp.Threading.Tasks;

namespace Game.Modules.Enemy.Scripts
{
    public interface IGameEventHandler
    {
        public UniTask Start();
    }
}