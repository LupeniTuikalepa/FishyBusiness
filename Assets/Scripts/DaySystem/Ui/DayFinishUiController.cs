using System;
using UnityEngine;

namespace FishyBusiness.DaySystem.Ui
{
    public class DayFinishUiController : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] private GameObject DayFinishCanvas;
        
        public event Action OnStartNextDay;
        
        private void OnEnable()
        {
            levelManager.OnDayEnded += OnDayEnded;
        }

        private void OnDayEnded(Day obj)
        {
            DayFinishCanvas.SetActive(true);
        }

        private void OnDisable()
        {
            levelManager.OnDayEnded -= OnDayEnded;
        }

        public void StartNextDay()
        {
            levelManager.StartNextDay();
            OnStartNextDay?.Invoke();
            DayFinishCanvas.SetActive(false);
        }
    }
}