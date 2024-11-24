namespace FishyBusiness.DaySystem
{
    public interface IDayFish
    {
        bool IsTruth { get; }
        int Money { get; }
        int Damage { get; }
    }
}