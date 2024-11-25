using System.Collections.Generic;
using System.Linq;
using FishyBusiness.Cards;
using FishyBusiness.Cards.Enums;
using LTX.Tools;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards
{
    public class BlackJackHand : CardCollection<Card>
    {
        public List<Card> Cards { get; private set; }
        public DynamicBuffer<Card> CardsBuffer { get; private set; }

        public BlackJackHand()
        {
            Cards = new List<Card>();
            CardsBuffer = new DynamicBuffer<Card>(64);
        }
        
        public int GetHandValue()
        {
            int handValue = default;
            
            handValue = Cards.Aggregate(0, (sum, card) => sum + card.CardValue);

            if (handValue > 21 && Cards.Any(ctx => ctx.CardRank == CardRank.Ace))
            {
                handValue = Cards.Aggregate(handValue, (sum, card) =>
                {
                    if (card.CardRank == CardRank.Ace && sum > 21)
                    {
                        return sum - 10;
                    }
                    return sum;
                });
            }

            return handValue;
        }

        public void ClearHand()
        {
            CardsBuffer.CopyFrom(Cards);
            for (var index = 0; index < CardsBuffer.Length; index++)
            {
                Card card = CardsBuffer[index];
                TryRemove(card);
            }
        }

        protected override bool INTERNALTryAddCard(Card card)
        {
            Cards.Add(card);
            return true;
        }

        protected override bool INTERNALTryRemoveCard(Card card)
        {
            return Cards.Remove(card);
        }

        public override IEnumerable<Card> GetCards()
        {
            return Cards;
        }
    }
}