namespace FishyBusiness.GameSystem.Interfaces
{
    public interface IGameRunner
    {
        IGame Game { get; }
        void Begin();
        bool Refresh();
        void End(bool isSuccess);
    }
}