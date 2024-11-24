using FishyBusiness.MiniGameSystem.Interfaces;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using FishyBusiness.MiniGameSystem.Sample.BlackJackMiniGame;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack
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