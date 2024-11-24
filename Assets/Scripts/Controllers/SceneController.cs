using UnityEngine.SceneManagement;

namespace FishyBusiness
{
    public class SceneController
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}