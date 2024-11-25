using FishyBusiness.MiniGameSystem.Interfaces;
using TMPro;

namespace FishyBusiness.MiniGameSystem.Sample
{
    public struct SlotContext : IMiniGameContext
    {
        public Player Player;
        public int BetAmount;

        public GameStatus Status => status;
        public GameStatus status;
        
        public TMP_Text SlotResult;
        public bool IsComplete;
    }
}