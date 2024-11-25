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

            List<Data.Fish> vips = new List<Data.Fish>();

            for (int i = 0; i < GameMetrics.Global.VIPsCount; i++)
                vips.Add(FishGeneration.GenerateFish());
            
            SetRank();

            currentDay = new Day(vips.ToArray(), Mathf.CeilToInt(quota));
            currentDay.OnNewFish += CurrentDayOnOnNewFish;

            OnDayBegun?.Invoke(currentDay);
            currentDay.Begin();

            //Reset timer
            CurrentDayTime = GameMetrics.Global.LevelTime;
        }

        private void SetRank()
        {
            foreach (var mafia in GameDatabase.Global.Mafias)
            {
                List<Sprite> sprites = new List<Sprite>(GameDatabase.Global.FishKeyArts);
            
                foreach (var rank in GameDatabase.Global.MafiaRanks)
                {
                    rank.sprites.Add(mafia.name, new List<Sprite>());
                    for (int i = 0; i < rank.maxSlot; i++)
                    {
                        int index = Random.Range(0, sprites.Count);
                        rank.sprites[mafia.name].Add(sprites[index]);
                        sprites.RemoveAt(index);
                    }
                }
            }
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

        public Day GetDay()
        {
            return currentDay;
        }
    }
}