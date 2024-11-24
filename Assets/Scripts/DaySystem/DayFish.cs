using FishyBusiness.Data;
using FishyBusiness.Helpers;

namespace FishyBusiness.DaySystem
{
    public struct DayFish : IDayFish
    {
        Data.Fish IDayFish.Fish => fish;

        public bool IsTruth { get; }

        public int Money { get; }

        public int Damage => 1;


        public readonly Data.Fish fish;

        public DayFish(Data.Fish fish, bool isTruth, int money)
        {
            this.fish = fish;
            IsTruth = isTruth;
            Money = money;
        }

        public static DayFish GenerateCoherentFish() =>
            new DayFish(
                FishGeneration.GenerateFish(),
                true,
                GameMetrics.Global.SellPrice
                );

        public static DayFish GenerateLyingFish() =>
            new DayFish(
                FishGeneration.GenerateFish().Alter(),
                false,
                GameMetrics.Global.SellPrice
            );
    }
}