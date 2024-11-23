namespace FishyBusiness.GameSystem.Interfaces
{
    public interface IGameHandler<T> where T : IGameContext
    {
        T GetContext();
        void UpdateContext(T context);
    }
}