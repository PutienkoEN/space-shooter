using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public sealed class TouchInputHandler : IInitializable, IDisposable
    {
        public event Action<Vector2> OnTouchStarted;
        public event Action OnTouchFinished;
        public event Action<Vector2> OnTouchPositionChange;

        /*
         * Considered started when user touched screen.
         * Considered performed when user released touch from screen.
         * Sends events only two times - first upon initial touch and second upon release.
         */
        private readonly InputAction _touchStartAction;

        /*
         * Considered started when user is touching screen.
         * Sends event's every time touch position is changed.
         */
        private readonly InputAction _touchMoveAction;

        [Inject]
        public TouchInputHandler(PlayerInput playerInput)
        {
            _touchStartAction = playerInput.actions.FindAction("TouchStartPosition");
            _touchMoveAction = playerInput.actions.FindAction("TouchHoldPosition");
        }

        public void Initialize()
        {
            _touchStartAction.started += TouchStarted;
            _touchStartAction.performed += TouchFinished;

            _touchMoveAction.performed += TouchPositionUpdated;
        }

        public void Dispose()
        {
            _touchStartAction.started -= TouchStarted;
            _touchStartAction.performed -= TouchFinished;

            _touchMoveAction.performed -= TouchPositionUpdated;
        }

        private void TouchPositionUpdated(InputAction.CallbackContext context)
        {
            var touchPosition = context.ReadValue<Vector2>();
            OnTouchPositionChange?.Invoke(touchPosition);
        }

        private void TouchStarted(InputAction.CallbackContext context)
        {
            var touchPosition = _touchMoveAction.ReadValue<Vector2>();
            OnTouchStarted?.Invoke(touchPosition);
        }

        private void TouchFinished(InputAction.CallbackContext context)
        {
            OnTouchFinished?.Invoke();
        }
    }
}