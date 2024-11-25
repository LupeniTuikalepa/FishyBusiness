using System;
using DG.Tweening;
using FishyBusiness.DaySystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.UI.Panels
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
            LevelManager.Instance.OnDayEnded += Success;
        }
        private void OnDisable()
        {
            LevelManager.Instance.OnGameOver -= GameOver;
            LevelManager.Instance.OnDayEnded -= Success;
        }

        private void Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.DOFade(1, .5f);
        }

        private void Hide()
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.DOFade(0, .5f);
        }
        public void GameOver()
        {
            Show();
            background.sprite = gameOverBackground;
            border.color = gameOverColor;
            gameOverButtons.SetActive(true);
            successButtons.SetActive(false);
        }

        public void Success(Day day)
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
            Hide();
            LevelManager.Instance.BeginNight();
        }
    }
}