using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using FishyBusiness.Helpers;
using UnityEngine;

namespace FishyBusiness
{

    public class LevelManager : MonoBehaviour
    {
        private class Trust : IDayFish
        {
            public bool IsTruth => true;
            public int Money => 10;

            public int Damage => 1;
        }

        private class Lie : IDayFish
        {
            public bool IsTruth => false;
            public int Money => 10;

            public int Damage => 1;
        }

        public event Action OnGameOver;
        public event Action<Day> OnFinishedDay;
        public event Action<Day> OnBeginDay;

        public event Action<IDayFish, Day> OnSuccess;
        public event Action<IDayFish, Day> OnFailure;
        public event Action<IDayFish> OnNewChoice;

        private Day currentDay;
        private int currentDayIndex;

        private float currentDayTime;
        public bool IsLevelRunning { get; private set; }

        private void Start()
        {
            StartNextDay();
        }

        private void Update()
        {
            if (currentDay != null && IsLevelRunning)
            {
                currentDayTime -= Time.deltaTime;
                if (currentDayTime <= 0)
                    FinishDay();
            }
        }

        public void StartNextDay()
        {
            currentDayIndex += 1;
            float quota = GameMetrics.Global.StartQuota * Mathf.Pow(GameMetrics.Global.QuotaScaling, currentDayIndex);

            List<Fish> vips = new List<Fish>();

            for (int i = 0; i < GameMetrics.Global.VIPsCount; i++)
                vips.Add(FishGeneration.GenerateFish());

            currentDay = new Day(vips.ToArray(), Mathf.CeilToInt(quota));

            currentDay.OnNewFish += CurrentDayOnOnNewFish;
            currentDay.Begin();

            //Reset timer
            currentDayTime = GameMetrics.Global.LevelTime;

            OnBeginDay?.Invoke(currentDay);
        }

        private void CurrentDayOnOnNewFish(IDayFish fish)
        {
            OnNewChoice?.Invoke(fish);
        }

        private void FinishDay()
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
            if (currentDay.AcceptChoice(out IDayFish choice))
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
            if (currentDay.DeclineChoice(out IDayFish choice))
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