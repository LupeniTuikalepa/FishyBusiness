using FishyBusiness.MiniGameSystem.Interfaces;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample
{
    public class Slot : MiniGame<SlotContext>
    {
        private int rouletteResult = -1;
        
        public override void Begin(ref SlotContext context)
        {
            context.status = GameStatus.Pending;
            
            rouletteResult = Random.Range(0, 3);
        }

        public override bool Refresh(ref SlotContext context)
        {
            if (context.IsComplete)
            {
                context.status = rouletteResult == 0 ? GameStatus.Success : GameStatus.Failure;
            }
            
            return context.status != GameStatus.Pending;
        }

        public override void End(ref SlotContext context)
        {
            if (context.status == GameStatus.Success)
            {
                context.Player.AddMoney(context.BetAmount * 3);
            }
            
            context.SlotResult.text = context.status == GameStatus.Success ? "Win !!!" : "Lose...";
            context.status = GameStatus.None;
        }
    }
}