using System;
using FishyBusiness.Scenes.Xictoss_Scene.Script;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishyBusiness.DaySystem.Ui
{
    public class GameOverUiController : MonoBehaviour

    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private DebugPlayer debugPlayer;
        [SerializeField] private GameObject gameOverCanvas;
        [SerializeField] private HudManager hud;

        private void OnEnable()
        {
            levelManager.OnGameOver += LevelManagerOnOnGameOver;
            debugPlayer.OnPlayerDead += LevelManagerOnOnGameOver;
        }


        private void OnDisable()
        {
            levelManager.OnGameOver -= LevelManagerOnOnGameOver;
            debugPlayer.OnPlayerDead -= LevelManagerOnOnGameOver;
        }

        private void LevelManagerOnOnGameOver()
        {
            gameOverCanvas.SetActive(true);
        }

        public void LoadMainMenu()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.MainMenuScene);
        }

        public void RestartRunButton()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.LevelScene);
        }
    }
}