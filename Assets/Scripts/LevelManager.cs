using System;
using System.Collections.Generic;
using System.Linq;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using FishyBusiness.Fishes;
using FishyBusiness.Helpers;
using LTX.Singletons;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness
{

    [DefaultExecutionOrder(500)]
    public class LevelManager : MonoSingleton<LevelManager>
    {
        public event Action OnGameOver;
        public event Action<Day> OnDayEnded;
        public event Action<Day> OnDayBegun;

        public event Action<IDayFish, Day> OnSuccess;
        public event Action<IDayFish, Day> OnFailure;
        public event Action<IDayFish> OnNewFish;

        private Day currentDay;

        public int CurrentDayIndex { get; private set; }
        public float CurrentDayTime { get; private set; }
        public bool IsLevelRunning { get; private set; }

        private void Start()
        {
            StartNextDay();
            IsLevelRunning = true;
        }


        private void Update()
        {
            if (currentDay != null && IsLevelRunning)
            {
                CurrentDayTime -= Time.deltaTime;
                if (CurrentDayTime <= 0)
                    FinishDay();
            }
        }

        public void StartNextDay()
        {
            CurrentDayIndex += 1;
            float quota = GameMetrics.Global.StartQuota * Mathf.Pow(GameMetrics.Global.QuotaScaling, CurrentDayIndex);

            List<Fish> vips = new List<Fish>();
            List<Fish> mafias = new List<Fish>();

            for (int i = 0; i < GameMetrics.Global.VIPsCount; i++)
                vips.Add(FishGeneration.GenerateFish());


            Mafia[] mafiasData = GameController.GameDatabase.Mafias;
            MafiaRank[] ranksData = GameController.GameDatabase.MafiaRanks;

            for (int i = 0; i < mafiasData.Length; i++)
            {
                Mafia mafia = mafiasData[i];
                for (int j = 0; j < ranksData.Length; j++)
                {
                    MafiaRank rank = ranksData[j];
                    int qtt = Random.Range(1, rank.maxSlot);
                        Debug.Log($"creating {qtt} fishes for {rank.name} rank for  {mafia.name} mafia");
                    for (int k = 0; k < qtt; k++)
                    {
                        Fish fish = FishGeneration.GenerateFish(mafia, rank);
                        mafias.Add(fish);
                    }
                }
            }

            currentDay = new Day(
                    vips.ToArray(),
                    mafias.ToArray(),
                    Mathf.CeilToInt(quota)
                );

            currentDay.OnNewFish += CurrentDayOnOnNewFish;

            OnDayBegun?.Invoke(currentDay);
            currentDay.Begin();

            //Reset timer
            CurrentDayTime = GameMetrics.Global.LevelTime;
        }

        private void CurrentDayOnOnNewFish(IDayFish fish)
        {
            OnNewFish?.Invoke(fish);
        }

        private void FinishDay()
        {
            IsLevelRunning = false;
            if (currentDay.IsQuotaReached)
            {
                OnDayEnded?.Invoke(currentDay);
            }
            else
            {
                OnGameOver?.Invoke();
            }

        }

        public void MakeChoice(FishFood food)
        {
            if(currentDay == null)
                return;

            if (currentDay.MakeChoice(food, out IDayFish choice))
            {
                OnSuccess?.Invoke(choice, currentDay);
            }
            else
            {
                OnFailure?.Invoke(choice, currentDay);
            }

            currentDay.GetNextFish();
        }

        public void TriggerGameOver()
        {
            IsLevelRunning = false;
            OnGameOver?.Invoke();
        }
        public Day GetDay()
        {
            return currentDay;
        }
    }
}