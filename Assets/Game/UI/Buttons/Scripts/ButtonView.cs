using System;
using Game.Modules.GameSpeed.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ButtonView : MonoBehaviour, IButton
    {
        public event Action OnClick;
        
        private Button _button => GetComponent<Button>();

        public void SetActive(bool value)
        {
            _button.gameObject.SetActive(value);
        }
        
        private void Awake()
        {
            _button.onClick.AddListener(HandleOnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(HandleOnClick);
        }

        private void HandleOnClick()
        {
            OnClick?.Invoke();
        }
    }
}