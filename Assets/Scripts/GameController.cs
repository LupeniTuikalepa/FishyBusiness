using UnityEngine;

namespace FishyBusiness
{
    public static class GameController
    {
        private static GameMetrics gameMetrics;
        public static SceneController SceneController { get; private set; }
        public static Logger Logger { get; private set; }
        public static GameDatabase GameDatabase { get; private set; }

        public static GameMetrics Metrics
        {
            get
            {
                if (gameMetrics == null)
                    gameMetrics = Resources.Load<GameMetrics>("GameMetrics");

                return gameMetrics;
            }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.wantsToQuit += UnLoad;
            Application.targetFrameRate = 60;

            SceneController = new SceneController();
            Logger = new Logger();
            GameDatabase = new GameDatabase();
        }

        private static bool UnLoad()
        {
            return true;
        }

        public static void QuitGame()
        {
            Application.Quit();
        }
    }
}