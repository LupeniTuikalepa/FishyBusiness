using FishyBusiness.Cards.Interfaces;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards.UI
{
    public abstract class CardUI<T> : MonoBehaviour where T : ICard
    {
        public abstract void SetCard(T card);
    }
}