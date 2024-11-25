using System;
using DG.Tweening;
using FishyBusiness.Data;
using TMPro;
using UnityEngine;

namespace FishyBusiness
{
    public class MarketUI : MonoBehaviour
    {
        [Header("Text")]
        [SerializeField]private TextMeshProUGUI fishPriceText;
        [SerializeField]private TextMeshProUGUI coralPriceText;
        [SerializeField]private TextMeshProUGUI pufferPriceText;
        [SerializeField]private TextMeshProUGUI dayPriceText;
        [SerializeField]private TextMeshProUGUI moneyText;
        [Header("Buttons")]
        [SerializeField] private GameObject fishButton;
        [SerializeField] private GameObject coralButton;
        [SerializeField] private GameObject pufferButton;
        [SerializeField] private GameObject dayButton;
        [Header("Value")]
        [SerializeField] private int fishValue;
        [SerializeField] private int coralValue;
        [SerializeField] private int pufferValue;
        [SerializeField] private int dayValue;

        private void Start()
        {
            moneyText.text = $"Money: {Player.Instance.Money}";
        }

        private GameMetrics gameMetrics => GameMetrics.Global;

        public void UpgradeFish(int price)
        {
            if (price * gameMetrics.upgradeFishPrice <= Player.Instance.Money)
            {
                Player.Instance.RemoveMoney(price * gameMetrics.upgradeFishPrice);
                moneyText.text = $"Money: {Player.Instance.Money}";
                gameMetrics.upgradeFishPrice++;
                gameMetrics.bonusFishPrice += fishValue;
                fishPriceText.text = $"{price * gameMetrics.upgradeFishPrice}$";
            }
            else
            {
                fishButton.transform.DOShakePosition(0.5f, 8f);
            }
        }
        
        public void UpgradeCoral(int price)
        {
            if (price * gameMetrics.upgradeCoralPrice <= Player.Instance.Money)
            {
                Player.Instance.RemoveMoney(price * gameMetrics.upgradeCoralPrice);
                moneyText.text = $"Money: {Player.Instance.Money}";
                gameMetrics.upgradeCoralPrice++;
                gameMetrics.bonusCoralPrice += coralValue;
                coralPriceText.text = $"{price * gameMetrics.upgradeCoralPrice}$";
            }
            else
            {
                coralButton.transform.DOShakePosition(0.5f, 8f);
            }
        }
        
        
        public void UpgradePuffer(int price)
        {
            if (price * gameMetrics.upgradePufferPrice <= Player.Instance.Money)
            {
                Player.Instance.RemoveMoney(price * gameMetrics.upgradePufferPrice);
                moneyText.text = $"Money: {Player.Instance.Money}";
                gameMetrics.upgradePufferPrice++;
                gameMetrics.bonusPufferPrice += pufferValue;
                pufferPriceText.text = $"{price * gameMetrics.upgradePufferPrice}$";
            }
            else
            {
                pufferButton.transform.DOShakePosition(0.5f, 8f);
            }
        }
        
        public void UpgradeDay(int price)
        {
            if (price * gameMetrics.upgradeDayTime <= Player.Instance.Money)
            {
                Player.Instance.RemoveMoney(price * gameMetrics.upgradeDayTime);
                moneyText.text = $"Money: {Player.Instance.Money}";
                gameMetrics.upgradeDayTime++;
                gameMetrics.bonusDayTime += dayValue;
                dayPriceText.text = $"{price * gameMetrics.upgradeDayTime}$";
            }
            else
            {
                dayButton.transform.DOShakePosition(0.5f, 8f);
            }
        }
    }
}
