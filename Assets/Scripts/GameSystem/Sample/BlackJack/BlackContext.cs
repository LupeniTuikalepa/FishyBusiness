using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem.Sample.BlackJack
{
    public struct BlackContext : IGameContext
    {
        public Player Player;
        public int BetAmount;
        
        public GameStatus Status => status;
        public GameStatus status;
    }
}