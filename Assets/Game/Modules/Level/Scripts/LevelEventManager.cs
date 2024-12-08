using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Game.Modules.LevelInterfaces.Scripts;
using ModestTree;
using SpaceShooter.Game.Level.Events;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelEventManager : IGameFinishListener, IDisposable
    {
        public event Action<bool> OnLevelEventChange;

        private readonly LevelEventHandlerResolver _levelEventResolver;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        
        [Inject]
        public LevelEventManager(LevelEventHandlerResolver levelEventResolver)
        {
            _levelEventResolver = levelEventResolver;
        }

        public async void StartLevel(ILevelData levelData)
        {
            var gameEventHandlers = GetHandlers(levelData.GameLevelEvents);

            var hasEvents = !gameEventHandlers.IsEmpty();
            OnLevelEventChange?.Invoke(hasEvents);

            for (var eventNumber = 0; eventNumber < gameEventHandlers.Count; eventNumber++)
            {
                // When we use cancellation token to stop UniTask, it will go and pick next one and start execution.
                // Even if we exit play mode, task still starts execution and creates object on Game Scene
                // That's why when we dispose object, we need to cancel current task and prevent next one to start.
                // We use isStopped for this.
                if (_cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }

                var gameEventHandler = gameEventHandlers[eventNumber];
                try
                {
                    await gameEventHandler.Start(_cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    Debug.Log("Enemy spawning cancelled");
                }

                // Remove from memory
                gameEventHandlers[eventNumber] = null;
            }

            OnLevelEventChange?.Invoke(false);
        }

        private List<IGameEventHandler> GetHandlers(List<ILevelEventData> gameLevelEvents)
        {
            return gameLevelEvents
                .ConvertAll(_levelEventResolver.Resolve)
                .ToList();
        }

        public void OnGameFinish()
        {
            Dispose();
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}