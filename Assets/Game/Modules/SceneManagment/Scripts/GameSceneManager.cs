using Game.Modules.LevelInterfaces.Scripts;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class GameSceneManager
    {
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}