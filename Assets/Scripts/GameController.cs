using UnityEngine;

namespace FishyBusiness.Core
{
    public static class GameController
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.wantsToQuit += UnLoad;
            Application.targetFrameRate = 60;
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