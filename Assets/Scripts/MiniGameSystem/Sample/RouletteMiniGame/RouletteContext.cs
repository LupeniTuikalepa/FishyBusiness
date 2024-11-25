using FishyBusiness.MiniGameSystem.Interfaces;
using TMPro;

namespace FishyBusiness.MiniGameSystem.Sample.RouletteMiniGame
{
    public struct RouletteContext : IMiniGameContext
    {
        public Player Player;
        public int BetAmount;
        public int playerChoice;
        
        public GameStatus Status => status;
        public GameStatus status;

        public bool IsComplete;
        public TMP_Text RouletteResult;
    }
}