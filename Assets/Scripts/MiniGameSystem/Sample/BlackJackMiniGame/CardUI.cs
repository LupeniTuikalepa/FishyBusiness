using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards.UI;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack
{
    public class CardUI : CardUI<Card>
    {
        [SerializeField] private TMP_Text cardValue;
        
        public override void SetCard(Card card)
        {
            cardValue.text = card.CardValue.ToString();
        }
    }
}