using FishyBusiness.Data;
using FishyBusiness.Fishes;
using FishyBusiness.Helpers;
using UnityEngine;

namespace FishyBusiness.DaySystem
{
    public class DayFish : IDayFish
    {
        Fish IDayFish.Fish => fish;

        FishType IDayFish.FishType => fishType;


        public readonly Fish fish;
        private readonly FishType fishType;

        public DayFish(Fish fish, FishType fishType)
        {
            this.fish = fish;
            this.fishType = fishType;
        }


        public void OnFail(FishFood fishFood, Player player, Day day)
        {
            if (TryGetLifeInfluence(fishFood, out int lifeLoss) && lifeLoss > 0)
            {
                player.Hit(lifeLoss);
            }

            if (TryGetQuotaInfluence(fishFood, out int quotaLoss) && quotaLoss > 0)
            {
                day.IncreaseQuota(quotaLoss);
            }
        }

        public void OnSuccess(FishFood fishFood,Player player, Day day)
        {
            if (TryGetMoneyInfluence(fishFood, out int moneyInfluence) && moneyInfluence > 0)
            {
                int bonus = 0;
                switch (fishFood)
                {
                    case FishFood.Basic:
                        bonus = GameMetrics.Global.bonusCoralPrice;
                        break;
                    case FishFood.Deluxe:
                        bonus = GameMetrics.Global.bonusPufferPrice;
                        break;
                    case FishFood.Fish:
                        bonus = GameMetrics.Global.bonusFishPrice;
                        break;
                }
                day.EarnMoney(moneyInfluence + bonus);
                player.AddMoney(moneyInfluence + bonus);
            }
        }

        private bool TryGetLifeInfluence(FishFood fishFood,out int lifeLoss)
        {
            if (TryGetPair(fishFood, out var pair))
            {
                lifeLoss = pair.LifeInfluence;
                return true;
            }

            lifeLoss = 0;
            return false;
        }
        private bool TryGetQuotaInfluence(FishFood fishFood, out int quotaInfluence)
        {
            if (TryGetPair(fishFood, out var pair))
            {
                quotaInfluence = pair.QuotaInfluence;
                return true;
            }

            quotaInfluence = 0;
            return false;
        }
        private bool TryGetMoneyInfluence(FishFood fishFood, out int moneyInfluence)
        {
            if (TryGetPair(fishFood, out var pair))
            {
                moneyInfluence = pair.MoneyInfluence;
                return true;
            }

            moneyInfluence = 0;
            return false;
        }

        private bool TryGetPair(FishFood fishFood, out FishAssociationInfos infos)
        {
            var pairs = GameMetrics.Global.FishAssociations;
            for (int i = 0; i < pairs.Length; i++)
            {
                if (pairs[i].FishType == fishType && pairs[i].FishFood == fishFood)
                {
                    infos = pairs[i];
                    return true;
                }
            }

            infos = default(FishAssociationInfos);
            return false;
        }
    }
}