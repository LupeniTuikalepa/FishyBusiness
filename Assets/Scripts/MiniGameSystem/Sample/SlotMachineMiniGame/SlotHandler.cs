using System.Collections;
using FishyBusiness.MiniGameSystem.Interfaces;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample
{
    public class SlotHandler : MonoBehaviour, IMiniGameHandler<SlotContext>, ILogSource
    {
        public string Name => nameof(SlotHandler);
        
        [SerializeField] private SlotContent content;
        [SerializeField] private Player player;
        [SerializeField] private ButtonManagerBasic startButton, backButton;
        [SerializeField] private TMP_InputField moneyBet;
        [SerializeField] private TMP_Text playerMoney;
        private int betAmount;
        
        private Slot slot;

        private void OnEnable()
        {
            MiniGameManager.Instance.OnGameStopped += GameStopped;
            RefreshMoney();
        }
        
        private void OnDisable()
        {
            MiniGameManager.Instance.OnGameStopped -= GameStopped;
        }

        private void GameStopped(IMiniGameRunner obj)
        {
            playerMoney.text = player.Money.ToString();
            StartCoroutine(ClearSlot());
        }

        private void RefreshMoney()
        {
            playerMoney.text = player.Money.ToString();
        }

        public void StartGame()
        {
            if (betAmount > player.Money || betAmount <= 0)
            {
                GameController.Logger.LogError(this, $"This is not a valid Bet ! {nameof(betAmount)} = {betAmount} - {nameof(player.Money)} = {player.Money}");
                return;
            }

            if (context.status != GameStatus.None)
            {
                GameController.Logger.LogError(this, $"Can't start a new game ! {nameof(context.status)} = {context.status}");
                return;
            }
            
            player.RemoveMoney(betAmount);
            RefreshMoney();
            
            startButton.buttonVar.interactable = false;
            backButton.buttonVar.interactable = false;
            moneyBet.interactable = false;
            
            slot = new Slot();
            MiniGameManager.Instance.StartGame(slot, this);
        }

        public SlotContext GetContext()
        {
            return new SlotContext
            {
                Player = player,
                Content = content,
                BetAmount = betAmount,
                status = context.status
            };
        }

        private SlotContext context;
        public void UpdateContext(SlotContext context)
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
        
        public IEnumerator ClearSlot()
        {
            yield return new WaitForSeconds(0f);
            
            moneyBet.interactable = true;
            startButton.buttonVar.interactable = true;
            backButton.buttonVar.interactable = true;
        }
    }
}