using System;
using FishyBusiness.Scenes.Xictoss_Scene.Script;
using UnityEngine;

namespace FishyBusiness.DaySystem.Ui
{


    public class HudManager : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private DayFinishUiController DayFinishUiController;
        [SerializeField] private DebugPlayer debugPlayer;
        
        [SerializeField] private GameObject mainGameCanvas;

        private void OnEnable()
        {
            DayFinishUiController.OnStartNextDay += DayFinishUiControllerOnStartNextDay;
            levelManager.OnGameOver += LevelManagerDesactiveeHud;
            levelManager.OnDayEnded += LevelManagerDesactiveHud;
            debugPlayer.OnPlayerDead += LevelManagerDesactiveeHud;
        }


        private void OnDisable()
        {
            DayFinishUiController.OnStartNextDay -= DayFinishUiControllerOnStartNextDay;
            levelManager.OnGameOver -= LevelManagerDesactiveeHud;
            levelManager.OnDayEnded -= LevelManagerDesactiveHud;
            debugPlayer.OnPlayerDead -= LevelManagerDesactiveeHud;
        }

        private void LevelManagerDesactiveHud(Day day)
        {
            mainGameCanvas.SetActive(false);
        }

        private void LevelManagerDesactiveeHud()
        {
            mainGameCanvas.SetActive(false);
        }
        private void DayFinishUiControllerOnStartNextDay()
        {
            mainGameCanvas.SetActive(true);
        }
    }
}
