using FishyBusiness.MiniGameSystem.Interfaces;

namespace FishyBusiness.MiniGameSystem.Sample.RouletteMiniGame
{
    public struct RouletteContext : IMiniGameContext
    {
        public Player Player;
        public int BetAmount;
        public int playerChoice;
        
        public GameStatus Status => status;
        public GameStatus status;
    }
}