using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.Documents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness.DaySystem
{
    public class Day
    {
        public event Action<IDayFish> OnNewFish;

        private IDayFish currentFish;
        public int Quota { get; private set; }
        public int EarnedMoney { get; private set; }

        public bool IsQuotaReached => EarnedMoney >= Quota;

        public Data.Fish[] VIPs { get; private set; }

        //constructor
        public Day(Data.Fish[] vips, int quota)
        {
            this.VIPs = vips;
            this.Quota = quota;

            EarnedMoney = 0;
        }
        //--//

        public void Begin()
        {
            GetNextFish();
        }
        private void GetNextFish()
        {
            bool generateLying = Random.value <= GameMetrics.Global.LyingFishProbability;

            if (generateLying)
            {
                bool generateVIP = Random.value <= GameMetrics.Global.VIPFishProbability;
                if (generateVIP)
                    currentFish = new DayFish(VIPs[Random.Range(0, VIPs.Length)], true, GameMetrics.Global.SellPrice);
                else
                    currentFish = DayFish.GenerateCoherentFish();
            }

            currentFish = DayFish.GenerateLyingFish();
            OnNewFish?.Invoke(currentFish);
        }

        public bool AcceptChoice(out IDayFish fish)
        {

            fish = currentFish;

            bool isRight = currentFish.IsTruth;

            if (isRight)
            {
                EarnedMoney += currentFish.Money;
            }
            CompleteChoice();

            //Debug.Log("Le poisson est accepter, on lui file la cam");

            return isRight;
        }

        public bool DeclineChoice(out IDayFish fish)
        {
            fish = currentFish;

            bool isRight = currentFish.IsTruth == false;

            if (isRight)
            {
                EarnedMoney += currentFish.Money;
            }

            CompleteChoice();

            //Debug.Log("Le poisson est refuser, ça dégage");
            return isRight;
        }

        private void CompleteChoice()
        {
            GetNextFish();
        }

    }
}