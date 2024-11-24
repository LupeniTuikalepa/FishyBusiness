using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem.Sample
{
    public struct SlotContext : IMiniGameContext
    {
        public Player Player;
        public SlotContent Content;
        public int BetAmount;

        public GameStatus Status => status;
        public GameStatus status;
    }
}