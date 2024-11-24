using System;
using FishyBusiness.DayManager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishyBusiness.Scenes.Xictoss_Scene.Script
{
    public class DebugPlayer : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] public TextMeshProUGUI moneyAndQuotaTxt;
        [SerializeField] public TextMeshProUGUI lifeTxt;
        [SerializeField] public TextMeshProUGUI fishTypeTxt;

        public event Action OnPlayerDead;
        
        private int money;
        private int life;

        private void Start()
        {
            money = 0;
            life = GameMetrics.Global.PlayerLife;
        }

        private void OnEnable()
        {
            levelManager.OnBeginDay += LevelManagerOnOnBeginDay;
            levelManager.OnSuccess += LevelManagerOnOnSuccess;
            levelManager.OnFailure += LevelManagerOnOnFailure;
            levelManager.OnNewChoice += LevelManagerOnOnNewChoice;
        }


        private void OnDisable()
        {
            levelManager.OnBeginDay -= LevelManagerOnOnBeginDay;
            levelManager.OnSuccess -= LevelManagerOnOnSuccess;
            levelManager.OnFailure -= LevelManagerOnOnFailure;
            levelManager.OnNewChoice -= LevelManagerOnOnNewChoice;
        }
        private void LevelManagerOnOnBeginDay(Day day)
        {
            UpdateEarnedAndQuotaText(day);
        }

        private void LevelManagerOnOnNewChoice(IDayChoice choice)
        {
            fishTypeTxt.text = choice.IsTruth.ToString();
        }

        private void LevelManagerOnOnFailure(IDayChoice choice, Day day)
        {
            money += choice.Money;
            life -= choice.Damage;
            lifeTxt.text = life.ToString();
            
            UpdateEarnedAndQuotaText(day);
            if (life == 0)
            {
                OnPlayerDead?.Invoke();
            }
        }

        private void LevelManagerOnOnSuccess(IDayChoice choice, Day day)
        {
            money += choice.Money;
            UpdateEarnedAndQuotaText(day);
        }

        private void UpdateEarnedAndQuotaText(Day day)
        {
            moneyAndQuotaTxt.text = $"{day.EarnedMoney}/{day.Quota}";
        }
    }
}