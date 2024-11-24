using FishyBusiness.GameSystem.Interfaces;
using FishyBusiness.GameSystem.Sample.BlackJack.Cards;
using FishyBusiness.MiniGameSystem.Sample.BlackJackMiniGame;

namespace FishyBusiness.GameSystem.Sample.BlackJack
{
    public struct BlackJackContext : IMiniGameContext
    {
        public Player Player;
        public int BetAmount;
        
        public GameStatus Status => status;
        public GameStatus status;

        public BlackJackHand PlayerHand;
        public BlackJackHand DealerHand;
        public BlackJackDeck GameDeck;

        public BlackJackHandUI PlayerHandUI;
        public BlackJackHandUI DealerHandUI;

        public bool IsStaying;
    }
}