using UnityEngine;

namespace FishyBusiness
{
    public class MainMenuUI : MonoBehaviour
    {
        public void LoadLevel()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.LevelScene);
        }
    }
}