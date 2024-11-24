using System;
using FishyBusiness.DaySystem;
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
            levelManager.OnDayBegun += LevelManagerOnOnDayBegun;
            levelManager.OnSuccess += LevelManagerOnOnSuccess;
            levelManager.OnFailure += LevelManagerOnOnFailure;
            levelManager.OnNewFish += LevelManagerOnOnNewFish;
        }


        private void OnDisable()
        {
            levelManager.OnDayBegun -= LevelManagerOnOnDayBegun;
            levelManager.OnSuccess -= LevelManagerOnOnSuccess;
            levelManager.OnFailure -= LevelManagerOnOnFailure;
            levelManager.OnNewFish -= LevelManagerOnOnNewFish;
        }
        private void LevelManagerOnOnDayBegun(Day day)
        {
            UpdateEarnedAndQuotaText(day);
        }

        private void LevelManagerOnOnNewFish(IDayFish fish)
        {
            // fishTypeTxt.text = fish.IsTruth.ToString();
        }

        private void LevelManagerOnOnFailure(IDayFish fish, Day day)
        {
            // money += fish.Money;
            // life -= fish.Damage;
            lifeTxt.text = life.ToString();

            UpdateEarnedAndQuotaText(day);
            if (life == 0)
            {
                OnPlayerDead?.Invoke();
            }
        }

        private void LevelManagerOnOnSuccess(IDayFish fish, Day day)
        {
            // money += fish.Money;
            UpdateEarnedAndQuotaText(day);
        }

        private void UpdateEarnedAndQuotaText(Day day)
        {
            moneyAndQuotaTxt.text = $"{day.EarnedMoney}/{day.Quota}";
        }
    }
}