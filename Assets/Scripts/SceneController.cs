using UnityEngine.SceneManagement;

namespace FishyBusiness
{
    public class SceneController
    {
        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}