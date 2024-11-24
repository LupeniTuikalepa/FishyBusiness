namespace FishyBusiness.DaySystem
{
    public interface IDayChoice
    {
        bool IsTruth { get; }
        int Money { get; }
        int Damage { get; }
    }
}