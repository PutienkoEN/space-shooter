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
        
        private Button Button => GetComponent<Button>();

        public void SetActive(bool value)
        {
            Button.gameObject.SetActive(value);
        }
        
        private void Awake()
        {
            Button.onClick.AddListener(HandleOnClick);
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(HandleOnClick);
        }

        private void HandleOnClick()
        {
            OnClick?.Invoke();
        }
    }
}