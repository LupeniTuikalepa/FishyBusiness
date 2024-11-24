using System.Collections;
using FishyBusiness.MiniGameSystem.Interfaces;
using FishyBusiness.MiniGameSystem.Sample.BlackJack.Cards;
using FishyBusiness.MiniGameSystem.Sample.BlackJackMiniGame;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample.BlackJack
{
    public class BlackJackHandler : MonoBehaviour, IMiniGameHandler<BlackJackContext>, ILogSource
    {
        public string Name => nameof(BlackJackHandler);
        
        [SerializeField] private Player player;
        [SerializeField] private ButtonManagerBasic startButton;
        [SerializeField] private ButtonManagerBasic[] gameButtons;
        [SerializeField] private TMP_InputField moneyBet;
        [SerializeField] private TMP_Text playerMoney;
        [SerializeField] private BlackJackHandUI playerHandUI, dealerHandUI;
        private int betAmount;

        private bool isStaying, waitingForClear;
        
        private BlackJack blackJack;
        
        private void OnEnable()
        {
            MiniGameManager.Instance.OnGameStopped += GameStopped;
        }
        
        private void OnDisable()
        {
            MiniGameManager.Instance.OnGameStopped -= GameStopped;
        }

        private void GameStopped(IMiniGameRunner obj)
        {
            playerMoney.text = player.Money.ToString();
            StartCoroutine(ClearBlackJack());
        }

        private void RefreshMoney()
        {
            playerMoney.text = player.Money.ToString();
        }

        private void Start()
        {
            RefreshMoney();
            playerHand = new BlackJackHand();
            dealerHand = new BlackJackHand();
            gameDeck = new BlackJackDeck();
        }
        
        public void StartGame()
        {
            if (waitingForClear)
            {
                dealerHand.ClearHand();
                playerHand.ClearHand();
                dealerHandUI.UnBind(context.DealerHand);
                playerHandUI.UnBind(context.PlayerHand);
                
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
            MiniGameManager.Instance.StartGame(blackJack, this);
        }

        private void SetupGame()
        {
            startButton.buttonVar.interactable = false;
            moneyBet.interactable = false;

            foreach (ButtonManagerBasic button in gameButtons)
            {
                button.buttonVar.interactable = true;
            }
            
            player.RemoveMoney(betAmount);
            RefreshMoney();
            
            isStaying = false;
            context.status = GameStatus.Pending;
            gameDeck = new BlackJackDeck();
            blackJack = new BlackJack();
        }

        private BlackJackHand playerHand;
        private BlackJackHand dealerHand;
        private BlackJackDeck gameDeck;
        public BlackJackContext GetContext()
        {
            return new BlackJackContext
            {
                Player = player,
                BetAmount = betAmount,
                status = context.status,
                PlayerHand = playerHand,
                DealerHand = dealerHand,
                GameDeck = gameDeck,
                PlayerHandUI = playerHandUI,
                DealerHandUI = dealerHandUI,
                IsStaying = isStaying
            };
        }

        private BlackJackContext context;
        public void UpdateContext(BlackJackContext blackJackContext)
        {
            context = blackJackContext;
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

        public void PlayerStay()
        {
            if (waitingForClear) return;
            
            while (dealerHand.GetHandValue() <= 16)
            {
                if (gameDeck.DrawNext(out Card newCard))
                {
                    dealerHand.TryAdd(newCard);
                }
                else
                {
                    break;
                }
            }
            
            isStaying = true;
        }

        public void PlayerHit()
        {
            if (waitingForClear) return;
            
            if (gameDeck.DrawNext(out Card newCard))
            {
                playerHand.TryAdd(newCard);
            }

            if (playerHand.GetHandValue() > 21)
            {
                PlayerStay();
            }
        }

        public void PlayerDoubleDown()
        {
            if (waitingForClear) return;
            
            player.RemoveMoney(betAmount);
            RefreshMoney();
            
            betAmount *= 2;
            
            if (gameDeck.DrawNext(out Card newCard))
            {
                playerHand.TryAdd(newCard);
            }
            
            PlayerStay();
        }

        public IEnumerator ClearBlackJack()
        {
            foreach (ButtonManagerBasic button in gameButtons)
            {
                button.buttonVar.interactable = false;
            }
            
            yield return new WaitForSeconds(2f);
            
            moneyBet.interactable = true;
            startButton.buttonVar.interactable = true;
            waitingForClear = true;
        }
    }
}