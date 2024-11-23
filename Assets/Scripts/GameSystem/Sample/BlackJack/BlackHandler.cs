using FishyBusiness.GameSystem.Interfaces;
using TMPro;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample.BlackJack
{
    public class BlackHandler : MonoBehaviour, IGameHandler<BlackContext>, ILogSource
    {
        public string Name => nameof(BlackHandler);
        
        [SerializeField] private Player player;
        [SerializeField] private TMP_InputField moneyBet;
        private int betAmount;
        
        private Black black;
        
        public void StartGame()
        {
            if (betAmount > player.Money || betAmount <= 0)
            {
                GameController.Logger.LogError(this, $"This is not a valid Bet ! {nameof(betAmount)} = {betAmount} - {nameof(player.Money)} = {player.Money}");
                return;
            }
            
            black = new Black();
            GameManager.Instance.StartGame(black, this);
        }
        
        public BlackContext GetContext()
        {
            return new BlackContext
            {
                Player = player,
                BetAmount = betAmount,
            };
        }

        private BlackContext context;
        public void UpdateContext(BlackContext context)
        {
            this.context = context;
        }

        public void GetBetAmount(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                betAmount = 0;
                return;
            }
            betAmount = int.Parse(value);
        }
    }
}