using FishyBusiness.MiniGameSystem.Interfaces;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.RouletteMiniGame
{
    public class Roulette : MiniGame<RouletteContext>
    {
        private int rouletteResult = -1;
        
        public override void Begin(ref RouletteContext context)
        {
            context.status = GameStatus.Pending;
            
            rouletteResult = Random.Range(0, 2);
        }

        public override bool Refresh(ref RouletteContext context)
        {
            if (context.IsComplete)
            {
                if (rouletteResult == context.playerChoice)
                {
                    context.status = GameStatus.Success;
                }
                else
                {
                    context.status = GameStatus.Failure;
                }
            }

            return context.status != GameStatus.Pending;
        }

        public override void End(ref RouletteContext context)
        {
            //Debug.Log($"End Roulette : {context.status}");
            if (context.status == GameStatus.Success)
            {
                context.Player.AddMoney(context.BetAmount * 2);
            }

            context.RouletteResult.text = context.status == GameStatus.Success ? "Win !!!" : "Lose...";
            context.status = GameStatus.None;
        }
    }
}