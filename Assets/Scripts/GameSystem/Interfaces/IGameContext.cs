namespace FishyBusiness.GameSystem.Interfaces
{
    public enum GameStatus
    {
        Pending,
        Success,
        Failure,
    }
    public interface IGameContext
    {
        GameStatus Status { get; }
    }
}