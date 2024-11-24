using FishyBusiness.Data;
using FishyBusiness.Fishes;
using FishyBusiness.Helpers;

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
            if (TryGetLifeInfluence(fishFood, out int lifeLoss))
                player.Hit(lifeLoss);

            if (TryGetQuotaInfluence(fishFood, out int quotaLoss))
                day.IncreaseQuota(quotaLoss);
        }

        public void OnSuccess(FishFood fishFood,Player player, Day day)
        {
            if (TryGetQuotaInfluence(fishFood, out int quotaLoss))
            {
                day.EarnMoneyForQuota(quotaLoss);
                player.AddMoney(quotaLoss);
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