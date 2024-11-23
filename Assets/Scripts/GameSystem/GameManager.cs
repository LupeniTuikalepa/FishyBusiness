using System;
using System.Collections.Generic;
using FishyBusiness.GameSystem.Interfaces;
using LTX.Singletons;
using LTX.Tools;

namespace FishyBusiness.GameSystem
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public event Action<IGameRunner> OnGameStarted;
        public event Action<IGameRunner> OnGameStopped;

        private List<IGameRunner> gameRunners;
        private DynamicBuffer<IGameRunner> gameRunnersBuffer;

        protected override void Awake()
        {
            base.Awake();

            gameRunners = new List<IGameRunner>();
            gameRunnersBuffer = new DynamicBuffer<IGameRunner>(64);
        }

        private void Update()
        {
            gameRunnersBuffer.CopyFrom(gameRunners);
            for (int i = 0; i < gameRunnersBuffer.Length; i++)
            {
                if (gameRunnersBuffer[i].Refresh())
                {
                    StopGame(gameRunnersBuffer[i].Game, true);
                }
            }
        }
        
        public void StartGame<T>(Game<T> game, IGameHandler<T> gameHandler)
            where T : IGameContext
        {
            if (TryGetGameRunner(game, out IGameRunner runner)) return;

            GameRunner<T> gameRunner = new GameRunner<T>(game, gameHandler);
            
            gameRunners.Add(gameRunner);
            gameRunner.Begin();
            
            OnGameStarted?.Invoke(gameRunner);
        }
        
        public void StopGame(IGame Game, bool isSuccess)
        {
            if (TryGetGameRunner(Game, out IGameRunner runner))
            {
                runner.End(isSuccess);
                gameRunners.Remove(runner);
                
                OnGameStopped?.Invoke(runner);
            }
        }

        private bool TryGetGameRunner(IGame game, out IGameRunner gameRunner)
        {
            foreach (IGameRunner runner in gameRunners)
            {
                if (runner.Game == game)
                {
                    gameRunner = runner;
                    return true;
                }
            }

            gameRunner = null;
            return false;
        }
    }
}