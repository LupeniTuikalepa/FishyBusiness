using System;
using FishyBusiness.Cards.Enums;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack
{
    public class CardUI : CardUI<Card>
    {
        [SerializeField] private Image cardImage;
        [SerializeField] private CardData[] cardDatas; // DO NOT CHANGE (par pitie)
        
        public override void SetCard(Card card)
        {
            if (TryGetData(out CardData cardToSet, card))
            {
                //Debug.Log($"Card Data : type : {cardToSet.cardType} - rank : {cardToSet.cardRank} |" +
                          //$"Card UI : type : {card.CardType} - rank : {card.CardRank}");
                cardImage.sprite = cardToSet.cardSprite;
            }
            else
            {
                Debug.Log($"Card Data : type : {card.CardType} - rank : {card.CardRank}");
            }
        }

        private bool TryGetData(out CardData cardToSet, Card card)
        {
            cardToSet = cardDatas[0];
            foreach (CardData cardData in cardDatas)
            {
                if (cardData.cardRank == card.CardRank && cardData.cardType == card.CardType)
                {
                    cardToSet = cardData;
                    return true;
                }
            }

            return false;
        }
    }

    [Serializable]
    public struct CardData
    {
        public Sprite cardSprite;
        public CardRank cardRank;
        public CardFamily cardType;
    }
}