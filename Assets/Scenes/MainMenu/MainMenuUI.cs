using System;
using UnityEngine;

namespace FishyBusiness
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject settings;
        
        
        
        public void LoadLevel()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.LevelScene);
        }

        public void ShowSettings()
        {
            settings.SetActive(true);
        }

        public void GoBack()
        {
            settings.SetActive(false);
        }

        public void Quit()
        {
          Application.Quit();   
        }
    }
}