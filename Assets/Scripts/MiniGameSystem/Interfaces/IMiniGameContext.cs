namespace FishyBusiness.MiniGameSystem.Interfaces
{
    public enum GameStatus
    {
        None,
        Pending,
        Success,
        Failure,
        Tie,
    }
    public interface IMiniGameContext
    {
        GameStatus Status { get; }
    }
}