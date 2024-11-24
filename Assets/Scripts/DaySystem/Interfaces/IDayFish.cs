using FishyBusiness.Data;
using FishyBusiness.Fishes;

namespace FishyBusiness.DaySystem
{
    public interface IDayFish
    {
        Fish Fish { get; }
        FishType FishType { get; }

        void OnSuccess(FishFood fishFood, Player player, Day day);
        void OnFail(FishFood fishFood, Player player, Day day);

    }
}