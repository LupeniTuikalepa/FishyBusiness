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
    public class LevelManager : MonoSingleton<LevelManager>, ILogSource
    {
        [Flags]
        public enum DayPhase
        {
            Day = 1,
            Night = 2,
        }

        public event Action OnGameOver;
        public event Action<Day> OnDayEnded;
        public event Action<Day> OnDayBegun;
        public event Action OnNightBegun;
        public event Action OnNightEnded;

        public event Action<IDayFish, Day> OnSuccess;
        public event Action<IDayFish, Day> OnFailure;

        public event Action<IDayFish> OnNewFish;

        private Day currentDay;
        
        public DateTime dayDate { get => dayDate.AddDays(CurrentDayIndex); set => dayDate = new DateTime(2024,1,1); }

        public DayPhase CurrentDayPhase { get; private set; }
        public int CurrentDayIndex { get; private set; }
        public float CurrentDayTime { get; private set; }
        public bool IsLevelRunning { get; private set; }

        private void Start()
        {
            IsLevelRunning = true;
            StartNextDay();
        }


        private void Update()
        {
            if (currentDay == null || !IsLevelRunning || CurrentDayPhase != DayPhase.Day)
                return;

            CurrentDayTime -= Time.deltaTime;
            if (CurrentDayTime <= 0)
            {
                GameController.Logger.Log(this, "Day time as run out");
                FinishDay();
            }
        }

        public void StartNextDay()
        {
            CurrentDayIndex += 1;
            float quota = GameMetrics.Global.StartQuota * Mathf.Pow(GameMetrics.Global.QuotaScaling, CurrentDayIndex);

            List<Fish> vips = new List<Fish>();
            List<Fish> mafias = new List<Fish>();

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

            int vipCount = GameMetrics.Global.VIPsCount;
            for (int i = 0; i < vipCount; i++)
            {
                if(mafias.Count == 0)
                    break;

                int idx = Random.Range(0, mafias.Count);
                var fish = mafias[idx];
                mafias.RemoveAt(idx);
                vips.Add(fish);
            }

            currentDay = new Day(
                    vips.ToArray(),
                    mafias.ToArray(),
                    Mathf.CeilToInt(quota)
                );

            currentDay.OnNewFish += CurrentDayOnOnNewFish;

            CurrentDayPhase = DayPhase.Day;

            OnNightEnded?.Invoke();
            OnDayBegun?.Invoke(currentDay);
            currentDay.Begin();

            //Reset timer
            CurrentDayTime = GameMetrics.Global.LevelTime;
        }

        public void BeginNight()
        {
            IsLevelRunning = true;
            CurrentDayPhase = DayPhase.Night;

            OnNightBegun?.Invoke();
        }

        private void CurrentDayOnOnNewFish(IDayFish fish)
        {
            OnNewFish?.Invoke(fish);
        }

        private void FinishDay()
        {
            if (currentDay.IsQuotaReached)
            {
                OnDayEnded?.Invoke(currentDay);
                IsLevelRunning = false;
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

        public string Name => "Level Manager";
    }
}