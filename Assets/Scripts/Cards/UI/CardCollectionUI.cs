using System.Collections.Generic;
using FishyBusiness.Cards.Interfaces;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards.UI;
using UnityEngine;

namespace FishyBusiness.Cards.UI
{
    public abstract class CardCollectionUI<T> : MonoBehaviour where T : ICard
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Transform spawnRoot;
        private Dictionary<T, CardUI<T>> cardUIs;
        protected CardCollection<T> CurrentCollection { get; private set; }

        protected virtual void Awake()
        {
            cardUIs = new Dictionary<T, CardUI<T>>();
        }
        
        public virtual void Bind(CardCollection<T> collection)
        {
            CurrentCollection = collection;
            
            collection.OnAdded += CreateCardUI;
            collection.OnRemoved += RemoveCardUI;

            foreach (T card in collection.GetCards())
            {
                CreateCardUI(card);
            }
        }
        
        public virtual void UnBind(CardCollection<T> collection)
        {
            if (collection == CurrentCollection)
            {
                collection.OnAdded -= CreateCardUI;
                collection.OnRemoved -= RemoveCardUI;

                CurrentCollection = null;

                foreach ((T key, var value) in cardUIs)
                {
                    Destroy(value.gameObject);
                }
                cardUIs.Clear();
            }
        }

        protected virtual void CreateCardUI(T card)
        {
            GameObject go = Instantiate(cardPrefab, spawnRoot);

            if (go.TryGetComponent(out CardUI<T> cardUI))
            {
                cardUI.SetCard(card);
                cardUIs.Add(card, cardUI);
            }
        }

        protected virtual void RemoveCardUI(T card)
        {
            if (cardUIs.Remove(card, out CardUI<T> cardUI))
            {
                Destroy(cardUI.gameObject);
            }
        }
    }
}