using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.UI.Menus
{
    public class EndDay : MonoBehaviour
    {
        [SerializeField]
        private Image background;
        [SerializeField]
        private Image border;

        [SerializeField]
        private Sprite successBackground, gameOverBackground;
        [SerializeField]
        private Color successColor, gameOverColor;
        [SerializeField]
        private GameObject successButtons, gameOverButtons;

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
            LevelManager.Instance.OnGameOver += GameOver;
        }
        private void OnDisable()
        {
            LevelManager.Instance.OnGameOver -= GameOver;
        }

        private void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, .5f);
        }


        public void GameOver()
        {
            Show();
            background.sprite = gameOverBackground;
            border.color = gameOverColor;
            gameOverButtons.SetActive(true);
            successButtons.SetActive(false);
        }

        public void Success()
        {
            Show();

            background.sprite = successBackground;
            border.color = successColor;
            successButtons.SetActive(true);
            gameOverButtons.SetActive(false);
        }
        public void LoadMainMenu()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.MainMenuScene);
        }

        public void RestartRunButton()
        {
            GameController.SceneController.LoadScene(GameMetrics.Global.LevelScene);
        }

        public void ContinueRunButton()
        {

        }

    }
}