using FishyBusiness.GameSystem.Interfaces;
using TMPro;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample
{
    public class SlotHandler : MonoBehaviour, IGameHandler<SlotContext>, ILogSource
    {
        public string Name { get; }
        
        [SerializeField] private SlotContent content;
        [SerializeField] private Player player;
        [SerializeField] private TMP_InputField moneyBet;
        private int betAmount;
        
        private Slot slot;

        public void StartGame()
        {
            if (betAmount > player.Money || betAmount <= 0)
            {
                GameController.Logger.LogError(this, "This is not a valid Bet !");
                return;
            }
            
            slot = new Slot();
            GameManager.Instance.StartGame(slot, this);
        }

        public SlotContext GetContext()
        {
            return new SlotContext
            {
                Player = player,
                Content = content,
                BetAmount = betAmount
            };
        }

        public void GetBetAmount(string value)
        {
            betAmount = int.Parse(value);
        }
    }
}