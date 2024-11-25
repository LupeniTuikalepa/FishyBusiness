using System;
using DG.Tweening;
using UnityEngine;

namespace FishyBusiness.UI.Menus
{
    public class GameOverUI : MonoBehaviour
    {
        private CanvasGroup canvasGroup;


        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnGameOver += Show;
        }
        private void OnDisable()
        {
            LevelManager.Instance.OnGameOver -= Show;
        }

        private void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, .5f);
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