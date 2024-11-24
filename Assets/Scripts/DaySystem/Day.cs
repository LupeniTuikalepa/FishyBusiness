using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.Documents;
using FishyBusiness.Fishes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness.DaySystem
{
    public class Day
    {
        public event Action<IDayFish> OnNewFish;

        public int Quota { get; private set; }
        public int EarnedMoney { get; private set; }
        public IDayFish CurrentFish { get; private set; }

        public bool IsQuotaReached => EarnedMoney >= Quota;

        public Fish[] ViPs { get; private set; }

        //constructor
        public Day(Fish[] vips, int quota)
        {
            ViPs = vips;
            Quota = quota;

            EarnedMoney = 0;
        }
        //--//

        public void Begin()
        {
            GetNextFish();
        }
        private void GetNextFish()
        {
            float rand = Random.value;
            GameMetrics metrics = GameMetrics.Global;

            if (rand <= metrics.VIPFishProbability)
            {
                Fish viP = ViPs[Random.Range(0, ViPs.Length)];
                CurrentFish = new DayFish(viP, FishType.VIP);
            }
            else if(rand <= metrics.VIPFishProbability + metrics.PoliceFishProbability)
            {
                Fish police = Fish.GenerateLyingFish();
                CurrentFish = new DayFish(police, FishType.Policeman);
            }
            else
            {
                Fish mafiaFish = Fish.GenerateCoherentFish();
                CurrentFish = new DayFish(mafiaFish, FishType.MafiaMan);
            }

            OnNewFish?.Invoke(CurrentFish);
        }

        public void EarnMoneyForQuota(int money)
        {
            EarnedMoney += money;
        }

        public void IncreaseQuota(int quotaInfluence)
        {
            Quota += quotaInfluence;
        }
        public bool MakeChoice(FishFood fishFood, out IDayFish dayFish)
        {
            dayFish = CurrentFish;
            FishPair[] validPairs = GameMetrics.Global.FishPairs;

            for (int i = 0; i < validPairs.Length; i++)
            {
                if (validPairs[i].FishFood == fishFood && validPairs[i].FishType == CurrentFish.FishType)
                {
                    CurrentFish.OnSuccess(fishFood, Player.Instance, this);
                    GetNextFish();
                    return true;
                }
            }
            CurrentFish.OnFail(fishFood, Player.Instance, this);
            GetNextFish();

            return false;
        }
    }
}