using System.Collections.Generic;
using FishyBusiness.Cards;
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
            
            foreach (Card card in Cards)
            {
                handValue += card.CardValue;
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