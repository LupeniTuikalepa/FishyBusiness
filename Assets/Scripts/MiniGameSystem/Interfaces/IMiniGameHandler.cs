namespace FishyBusiness.MiniGameSystem.Interfaces
{
    public interface IMiniGameHandler<T> where T : IMiniGameContext
    {
        T GetContext();
        void UpdateContext(T context);
    }
}