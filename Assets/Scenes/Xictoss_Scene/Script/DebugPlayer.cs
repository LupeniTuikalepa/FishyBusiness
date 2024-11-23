using System;
using FishyBusiness.DayManager;
using TMPro;
using UnityEngine;

namespace FishyBusiness.Scenes.Xictoss_Scene.Script
{
    public class DebugPlayer : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;
        [SerializeField] public TextMeshProUGUI moneyTxt;
        [SerializeField] public TextMeshProUGUI lifeTxt;
        [SerializeField] public TextMeshProUGUI fishTypeTxt;
        private int money;
        private int life;

        private void Start()
        {
            money = 0;
            moneyTxt.text = money.ToString();
            life = GameMetrics.Global.PlayerLife;
        }

        private void OnEnable()
        {
            levelManager.OnSuccess += LevelManagerOnOnSuccess;
            levelManager.OnFailure += LevelManagerOnOnFailure;
            levelManager.OnNewChoice += LevelManagerOnOnNewChoice;
        }
        private void OnDisable()
        {
            levelManager.OnSuccess -= LevelManagerOnOnSuccess;
            levelManager.OnFailure -= LevelManagerOnOnFailure;
            levelManager.OnNewChoice -= LevelManagerOnOnNewChoice;
        }

        private void LevelManagerOnOnNewChoice(IDayChoice choice)
        {
            fishTypeTxt.text = choice.IsTruth.ToString();
        }

        private void LevelManagerOnOnFailure(IDayChoice choice)
        {
            life -= choice.Damage;
            lifeTxt.text = life.ToString();
        }

        private void LevelManagerOnOnSuccess(IDayChoice choice)
        {
            money += choice.Money;
            moneyTxt.text = money.ToString();
        }

    }
}