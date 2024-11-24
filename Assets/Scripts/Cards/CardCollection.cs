using System;
using System.Collections.Generic;
using FishyBusiness.GameSystem.Sample.BlackJack.Interfaces;

namespace FishyBusiness.GameSystem.Sample.BlackJack.Cards
{
    public abstract class CardCollection<T> where T : ICard
    {
        public event Action<T> OnAdded;
        public event Action<T> OnRemoved;

        public bool TryAdd(T card)
        {
            if (INTERNALTryAddCard(card))
            {
                OnAdded?.Invoke(card);
                return true;
            }
            return false;
        }

        public bool TryRemove(T card)
        {
            if (INTERNALTryRemoveCard(card))
            {
                OnRemoved?.Invoke(card);
                return true;
            }
            return false;
        }

        protected abstract bool INTERNALTryAddCard(T card);
        protected abstract bool INTERNALTryRemoveCard(T card);

        public abstract IEnumerable<T> GetCards();
    }
}