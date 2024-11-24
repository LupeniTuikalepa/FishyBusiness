using FishyBusiness.Cards;
using FishyBusiness.Cards.UI;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJackMiniGame
{
    public class BlackJackHandUI : CardCollectionUI<Card>
    {
        [SerializeField] private TMP_Text handValue;
        
        public override void Bind(CardCollection<Card> collection)
        {
            base.Bind(collection);

            collection.OnAdded += RefreshHandValue;
            collection.OnRemoved += RefreshHandValue;
        }
        
        public override void UnBind(CardCollection<Card> collection)
        {
            base.UnBind(collection);

            collection.OnAdded -= RefreshHandValue;
            collection.OnRemoved -= RefreshHandValue;
        }

        private void RefreshHandValue(Card card)
        {
            if (CurrentCollection is BlackJackHand hand)
            {
                handValue.text = hand.GetHandValue().ToString();
            }
        }
    }
}