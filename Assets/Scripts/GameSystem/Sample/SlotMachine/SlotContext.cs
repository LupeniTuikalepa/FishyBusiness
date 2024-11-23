using FishyBusiness.GameSystem.Interfaces;

namespace FishyBusiness.GameSystem.Sample
{
    public struct SlotContext : IGameContext
    {
        public Player Player;
        public SlotContent Content;
        public int BetAmount;
    }
}