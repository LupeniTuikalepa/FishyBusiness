using System;
using System.Collections.Generic;
using FishyBusiness.DayManager;
using UnityEngine;

namespace FishyBusiness
{
    
    public class LevelManager : MonoBehaviour
    {
        private class Trust : IDayChoice
        {
            public bool IsTruth => true;
            public int Money => 10;

            public int Damage => 1;
        }

        private class Lie : IDayChoice
        {
            public bool IsTruth => false;
            public int Money => 10;
            
            public int Damage => 1;
        }
        
        public event Action OnGameOver;
        public event Action<Day> OnFinishedDay;
        public event Action<Day> OnBeginDay;
        
        public event Action<IDayChoice, Day> OnSuccess;
        public event Action<IDayChoice, Day> OnFailure;
        public event Action<IDayChoice> OnNewChoice;
        
        private Day currentDay;
        private int currentDayIndex;
        
        
        private void Start()
        {
            StartNextDay();
        }

        public void StartNextDay()
        {
            currentDayIndex += 1;
            float quota = GameMetrics.Global.StartQuota * Mathf.Pow(GameMetrics.Global.QuotaScaling, currentDayIndex);
            
            List<IDayChoice> choices = new List<IDayChoice>()
            {
                new Trust(),
                new Lie(),
                new Trust(),
                new Lie(),
                new Trust(),
                new Lie(),
            };

            currentDay = new Day(choices, Mathf.CeilToInt(quota));
            currentDay.OnDayFinished += OnDayFinished;
            currentDay.OnNewChoice += CurrentDayOnOnNewChoice;
            currentDay.Begin();
            OnBeginDay?.Invoke(currentDay);
        }

        private void CurrentDayOnOnNewChoice(IDayChoice choice)
        {
            OnNewChoice?.Invoke(choice);
        }

        private void OnDayFinished()
        {
            if (currentDay.IsQuotaReached)
            {
                OnFinishedDay?.Invoke(currentDay);
            }
            else
            {
                OnGameOver?.Invoke();
            }
        }
        
        

        public void Accept()
        {
            if (currentDay.AcceptChoice(out IDayChoice choice))
            {
                OnSuccess?.Invoke(choice, currentDay);
            }
            else
            {
                OnFailure?.Invoke(choice, currentDay);
            }
        }

        public void Decline()
        {
            if (currentDay.DeclineChoice(out IDayChoice choice))
            {
                OnSuccess?.Invoke(choice, currentDay);
            }
            else
            {
                OnFailure?.Invoke(choice, currentDay);
            }
        }
    }
}