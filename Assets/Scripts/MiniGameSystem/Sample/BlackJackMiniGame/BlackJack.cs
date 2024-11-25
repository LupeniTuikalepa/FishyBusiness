using FishyBusiness.MiniGameSystem.Interfaces;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack
{
    public class BlackJack : MiniGame<BlackJackContext>
    {
        private bool isBlackJack = false;
        
        public override void Begin(ref BlackJackContext context)
        {
            context.status = GameStatus.Pending;
            
            context.DealerHandUI.Bind(context.DealerHand);
            context.PlayerHandUI.Bind(context.PlayerHand);
            
            SetupHands(context);
        }

        public override bool Refresh(ref BlackJackContext context)
        {
            int playerValue = context.PlayerHand.GetHandValue();
            int dealerValue = context.DealerHand.GetHandValue();
            
            if (playerValue == 21 && dealerValue != 21)
            {
                context.status = GameStatus.Success;
                while (context.DealerHand.GetHandValue() <= 16)
                {
                    if (context.GameDeck.DrawNext(out Card newCard))
                    {
                        context.DealerHand.TryAdd(newCard);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (dealerValue == 21 && playerValue != 21)
            {
                context.status = GameStatus.Failure;
            }
            if (dealerValue == 21 && playerValue == 21)
            {
                context.status = GameStatus.Tie;
            }
            
            if (context.IsStaying)
            {
                if (playerValue > 21)
                {
                    context.status = GameStatus.Failure;
                }
                else if (dealerValue > 21)
                {
                    context.status = GameStatus.Success;
                }
                else if (playerValue == dealerValue)
                {
                    context.status = GameStatus.Tie;
                }
                else if (playerValue < dealerValue)
                {
                    context.status = GameStatus.Failure;
                }
                else if (dealerValue < playerValue)
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

        public override void End(ref BlackJackContext context)
        {
            if (context.status == GameStatus.Success)
            {
                if (isBlackJack)
                {
                    context.Player.AddMoney(context.BetAmount * 3);
                    return;
                }
                
                context.Player.AddMoney(context.BetAmount * 2);
            }
            else if (context.status == GameStatus.Tie)
            {
                context.Player.AddMoney(context.BetAmount);
            }
            
            Debug.Log(context.status);
        }

        private void SetupHands(BlackJackContext context)
        {
            for (int i = 0; i < 2; i++)
            {
                if (context.GameDeck.DrawNext(out Card playerCard))
                {
                    context.PlayerHand.TryAdd(playerCard);
                }
            }

            if (context.PlayerHand.GetHandValue() == 21)
            {
                isBlackJack = true;
                context.status = GameStatus.Success;
            }
            
            if (context.GameDeck.DrawNext(out Card dealerCard))
            {
                context.DealerHand.TryAdd(dealerCard);
            }
        }
    }
}