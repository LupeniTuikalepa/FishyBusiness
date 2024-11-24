namespace FishyBusiness.MiniGameSystem.Interfaces
{
    public interface IMiniGameRunner
    {
        IMiniGame MiniGame { get; }
        void Begin();
        bool Refresh();
        void End();
    }
}