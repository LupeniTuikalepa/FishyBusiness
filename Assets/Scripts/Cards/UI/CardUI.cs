using FishyBusiness.GameSystem.Sample.BlackJack.Interfaces;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample.BlackJack.Cards.UI
{
    public abstract class CardUI<T> : MonoBehaviour where T : ICard
    {
        public abstract void SetCard(T card);
    }
}