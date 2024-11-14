using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceShooter.Input
{
    public sealed class TouchInputHandler : ITouchInputHandler, IInitializable, IDisposable
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

        private readonly WorldUtility _worldUtility;


        [Inject]
        public TouchInputHandler(PlayerInput playerInput, WorldUtility worldUtility)
        {
            _touchStartAction = playerInput.actions.FindAction("TouchStartPosition");
            _touchMoveAction = playerInput.actions.FindAction("TouchHoldPosition");

            _worldUtility = worldUtility;
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
            var touchPositionScreen = context.ReadValue<Vector2>();
            var touchPositionWorld = _worldUtility.ToWorldPosition(touchPositionScreen);
            OnTouchPositionChange?.Invoke(touchPositionWorld);
        }

        private void TouchStarted(InputAction.CallbackContext context)
        {
            var touchPositionScreen = _touchMoveAction.ReadValue<Vector2>();
            var touchPositionWorld = _worldUtility.ToWorldPosition(touchPositionScreen);
            OnTouchStarted?.Invoke(touchPositionWorld);
        }

        private void TouchFinished(InputAction.CallbackContext context)
        {
            OnTouchFinished?.Invoke();
        }
    }
}