using System;
using System.Collections.Generic;
using FishyBusiness.MiniGameSystem.Interfaces;
using LTX.Singletons;
using LTX.Tools;

namespace FishyBusiness.MiniGameSystem
{
    public class MiniGameManager : MonoSingleton<MiniGameManager>
    {
        public event Action<IMiniGameRunner> OnGameStarted;
        public event Action<IMiniGameRunner> OnGameStopped;

        private List<IMiniGameRunner> gameRunners;
        private DynamicBuffer<IMiniGameRunner> gameRunnersBuffer;

        protected override void Awake()
        {
            base.Awake();

            gameRunners = new List<IMiniGameRunner>();
            gameRunnersBuffer = new DynamicBuffer<IMiniGameRunner>(64);
        }

        private void Update()
        {
            gameRunnersBuffer.CopyFrom(gameRunners);
            for (int i = 0; i < gameRunnersBuffer.Length; i++)
            {
                if (gameRunnersBuffer[i].Refresh())
                {
                    StopGame(gameRunnersBuffer[i].MiniGame);
                }
            }
        }
        
        public void StartGame<T>(MiniGame<T> miniGame, IMiniGameHandler<T> miniGameHandler)
            where T : IMiniGameContext
        {
            if (TryGetGameRunner(miniGame, out IMiniGameRunner runner)) return;

            MiniGameRunner<T> miniGameRunner = new MiniGameRunner<T>(miniGame, miniGameHandler);
            
            gameRunners.Add(miniGameRunner);
            miniGameRunner.Begin();
            
            OnGameStarted?.Invoke(miniGameRunner);
        }
        
        public void StopGame(IMiniGame miniGame)
        {
            if (TryGetGameRunner(miniGame, out IMiniGameRunner runner))
            {
                runner.End();
                gameRunners.Remove(runner);
                
                OnGameStopped?.Invoke(runner);
            }
        }

        private bool TryGetGameRunner(IMiniGame miniGame, out IMiniGameRunner miniGameRunner)
        {
            foreach (IMiniGameRunner runner in gameRunners)
            {
                if (runner.MiniGame == miniGame)
                {
                    miniGameRunner = runner;
                    return true;
                }
            }

            miniGameRunner = null;
            return false;
        }
    }
}