namespace FishyBusiness.GameSystem.Interfaces
{
    public enum GameStatus
    {
        None,
        Pending,
        Success,
        Failure,
    }
    public interface IGameContext
    {
        GameStatus Status { get; }
    }
}