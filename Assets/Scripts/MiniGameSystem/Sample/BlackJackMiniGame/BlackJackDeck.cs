using System.Collections.Generic;
using System.Linq;
using FishyBusiness.GameSystem.Sample.BlackJack.Enums;
using Random = System.Random;

namespace FishyBusiness.GameSystem.Sample.BlackJack.Cards
{
    public class BlackJackDeck : CardCollection<Card>
    {
        private List<Card> cards;

        public BlackJackDeck()
        {
            cards = new List<Card>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            foreach (CardFamily family in System.Enum.GetValues(typeof(CardFamily)))
            {
                foreach (CardRank rank in System.Enum.GetValues(typeof(CardRank)))
                {
                    Dictionary<CardRank, int> values = new Dictionary<CardRank, int>();
                    
                    if (rank is >= CardRank.Two and < CardRank.Jack)
                    {
                        values[rank] = (int)rank;
                    }
                    else
                    {
                        values[rank] = 10;
                    }

                    cards.Add(new Card(rank, family, values));
                }
            }

            ShuffleDeck();
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            cards = cards.OrderBy(card => rng.Next()).ToList();
        }

        public bool DrawNext(out Card cardTaken)
        {
            int index = UnityEngine.Random.Range(0, cards.Count);
            cardTaken = cards[index];
            return TryRemove(cardTaken);
        }
        
        protected override bool INTERNALTryAddCard(Card card)
        {
            cards.Add(card);
            return true;
        }

        protected override bool INTERNALTryRemoveCard(Card card)
        {
            return cards.Remove(card);
        }

        public override IEnumerable<Card> GetCards()
        {
            return cards;
        }
    }
}