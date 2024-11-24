using System;
using System.Collections.Generic;
using FishyBusiness.Cards.Enums;
using FishyBusiness.Cards.Interfaces;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards
{
    public readonly struct Card : ICard, IEquatable<Card>
    {
        public CardRank CardRank { get; }
        public CardFamily CardType { get; }
        private readonly Dictionary<CardRank, int> cardValues;
        public int CardValue => cardValues[CardRank];

        public Card(CardRank cardRank, CardFamily cardType, Dictionary<CardRank, int> cardValues)
        {
            CardRank = cardRank;
            CardType = cardType;
            this.cardValues = cardValues;
        }

        public bool Equals(Card other)
        {
            return CardRank == other.CardRank && CardType == other.CardType && Equals(cardValues, other.cardValues);
        }

        public override bool Equals(object obj)
        {
            return obj is Card other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)CardRank, (int)CardType, cardValues);
        }
    }
}