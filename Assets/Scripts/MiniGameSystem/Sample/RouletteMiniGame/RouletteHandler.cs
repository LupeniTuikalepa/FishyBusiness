using System.Collections;
using FishyBusiness.MiniGameSystem.Interfaces;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.RouletteMiniGame
{
    public class RouletteHandler : MonoBehaviour, IMiniGameHandler<RouletteContext>, ILogSource
    {
        public string Name => nameof(RouletteHandler);
        
        [SerializeField] private Player player;
        [SerializeField] private RotateSprite rotateSprite;
        
        [SerializeField] private ButtonManagerBasic[] gameButtons;
        [SerializeField] private TMP_InputField moneyBet;
        [SerializeField] private TMP_Text playerMoney, rouletteResult;
        private int betAmount, playerChoice;
        private bool waitingForClear;
        private Roulette roulette;
        
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
            StartCoroutine(ClearRoulette());
        }

        private void RefreshMoney()
        {
            playerMoney.text = player.Money.ToString();
        }

        public void SelectBet(bool choice)
        {
            playerChoice = choice ? 0 : 1;
            StartGame();
        }
        
        public void StartGame()
        {
            if (waitingForClear)
            {
                context.status = GameStatus.None;
                GetBetAmount(moneyBet.text);

                waitingForClear = false;
            }
            
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
            MiniGameManager.Instance.StartGame(roulette, this);
            rotateSprite.LaunchBall();
        }
        
        private void SetupGame()
        {
            moneyBet.interactable = false;

            foreach (ButtonManagerBasic button in gameButtons)
            {
                button.buttonVar.interactable = false;
            }
            
            player.RemoveMoney(betAmount);
            RefreshMoney();

            rouletteResult.text = "";

            context.IsComplete = false;
            context.status = GameStatus.Pending;
            roulette = new Roulette();
        }
        
        public RouletteContext GetContext()
        {
            return new RouletteContext
            {
                Player = player,
                BetAmount = betAmount,
                playerChoice = playerChoice,
                status = context.status,
                IsComplete = context.IsComplete,
                RouletteResult = rouletteResult,
            };
        }
        
        private RouletteContext context;
        public void UpdateContext(RouletteContext rouletteContext)
        {
            context = rouletteContext;
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
        
        public IEnumerator ClearRoulette()
        {
            yield return new WaitForSeconds(0);
            
            moneyBet.interactable = true;
            waitingForClear = true;
            
            foreach (ButtonManagerBasic button in gameButtons)
            {
                button.buttonVar.interactable = true;
            }
        }

        public void OnSpinEnd()
        {
            context.IsComplete = true;
        }
    }
}