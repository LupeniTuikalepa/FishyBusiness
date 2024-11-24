namespace FishyBusiness.GameSystem.Interfaces
{
    public interface IMiniGameRunner
    {
        IMiniGame MiniGame { get; }
        void Begin();
        bool Refresh();
        void End();
    }
}