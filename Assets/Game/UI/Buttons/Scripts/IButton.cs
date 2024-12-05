using System;

namespace Game.Modules.GameSpeed.Scripts
{
    public interface IButton
    {
        public event Action OnClick;
        public void SetActive(bool value);
    }
}