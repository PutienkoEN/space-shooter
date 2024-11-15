// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: GameKernel.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    internal sealed class GameKernel : MonoKernel,
        IGameStartListener,
        IGamePauseListener,
        IGameResumeListener,
        IGameFinishListener
    {
        [Inject] private IGameManager _gameManager;
        
        [Inject(Optional = true, Source = InjectSources.Local)] private readonly List<IGameListener> _gameListeners = new();
        [Inject(Optional = true, Source = InjectSources.Local)] private readonly List<IGameLateTickable> _lateTickables = new();
        [Inject(Optional = true, Source = InjectSources.Local)] private readonly List<IGameTickable> _tickables = new();
        [Inject(Optional = true, Source = InjectSources.Local)] private readonly List<IGameFixedTickable> _fixedTickables = new();

        public override void Start()
        {
            base.Start();
            _gameManager.AddListener(this);
            _gameManager.StartGame(); //TODO : Remove it once we add proper Start/Stop.
        }

        public void OnGameStart()
        {
            foreach (var it in _gameListeners)
            {
                if (it is IGameStartListener listener)
                {
                    listener.OnGameStart();
                }
            }
        }

        public void OnGamePause()
        {
            foreach (var it in _gameListeners)
            {
                if (it is IGamePauseListener listener)
                {
                    listener.OnGamePause();
                }
            }
        }

        public void OnGameResume()
        {
            foreach (var it in _gameListeners)
            {
                if (it is IGameResumeListener listener)
                {
                    listener.OnGameResume();
                }
            }
        }

        public void OnGameFinish()
        {
            foreach (var it in _gameListeners)
            {
                if (it is IGameFinishListener listener)
                {
                    listener.OnGameFinish();
                }
            }
        }
        
        public override void LateUpdate()
        {
            base.LateUpdate();

            if (_gameManager.State != GameState.PLAY)
                return;
            
            var deltaTime = Time.deltaTime;
            foreach (var tickable in _lateTickables)
            {
                tickable.LateTick(deltaTime);
            }
        }

        public override void Update()
        {
            base.Update();
            
            if (_gameManager.State != GameState.PLAY)
                return;
            
            var deltaTime = Time.deltaTime;
            foreach (var tickable in _tickables)
            {
                tickable.Tick(deltaTime);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (_gameManager.State != GameState.PLAY)
                return;
            
            var deltaTime = Time.fixedDeltaTime;
            foreach (var tickable in _fixedTickables)
            {
                tickable.FixedTick(deltaTime);
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _gameManager.RemoveListener(this);
        }
    }
}