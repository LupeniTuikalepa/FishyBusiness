using FishyBusiness.GameSystem.Sample.BlackJack.Cards;
using FishyBusiness.GameSystem.Sample.BlackJack.Cards.UI;
using TMPro;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample.BlackJack
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