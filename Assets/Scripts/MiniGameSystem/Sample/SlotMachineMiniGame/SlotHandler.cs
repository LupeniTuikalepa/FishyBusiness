using System.Collections;
using FishyBusiness.MiniGameSystem.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.MiniGameSystem.Sample
{
    public class SlotHandler : MonoBehaviour, IMiniGameHandler<SlotContext>, ILogSource
    {
        private static Player Player => Player.Instance;
        
        public string Name => nameof(SlotHandler);
        
        [SerializeField] private Button startButton, backButton;
        [SerializeField] private TMP_InputField moneyBet;
        [SerializeField] private TMP_Text playerMoney, resultText;
        private int betAmount;
        private bool waitingForClear, isComplete;
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
            RefreshMoney();
            StartCoroutine(ClearSlot());
        }

        private void RefreshMoney()
        {
            playerMoney.text = "Money : " + Player.Instance.Money;
        }

        public void StartGame()
        {
            if (waitingForClear)
            {
                context.status = GameStatus.None;
                GetBetAmount(moneyBet.text);

                waitingForClear = false;
            }
            
            Player player = Player.Instance;
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

            SetupGame();
            MiniGameManager.Instance.StartGame(slot, this);
            StartCoroutine(SetGameEnd());
        }

        private void SetupGame()
        {
            startButton.interactable = false;
            backButton.interactable = false;
            moneyBet.interactable = false;
            
            Player.RemoveMoney(betAmount);
            RefreshMoney();
            
            resultText.text = "";
            isComplete = false;
            
            context.status = GameStatus.Pending;
            slot = new Slot();
        }

        public SlotContext GetContext()
        {
            return new SlotContext
            {
                Player = Player,
                BetAmount = betAmount,
                status = context.status,
                SlotResult = resultText,
                IsComplete = isComplete,
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

        private IEnumerator ClearSlot()
        {
            yield return new WaitForSeconds(0);

            moneyBet.interactable = true;
            startButton.interactable = true;
            backButton.interactable = true;
        }

        private IEnumerator SetGameEnd()
        {
            yield return new WaitForSeconds(2f);

            isComplete = true;
        }
    }
}