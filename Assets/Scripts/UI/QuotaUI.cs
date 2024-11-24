using System;
using System.Globalization;
using FishyBusiness.DaySystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishyBusiness
{
    public class Quota : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI quotaText;
        [SerializeField]
        private TextMeshProUGUI earnedText;

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += OnDayBegun;
            LevelManager.Instance.OnDayEnded += OnDayEnded;
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnDayBegun -= OnDayBegun;
            LevelManager.Instance.OnDayEnded -= OnDayEnded;
        }


        private void OnDayBegun(Day day)
        {
            day.OnQuotaChanged += OnQuotaChanged;
        }

        private void OnDayEnded(Day day)
        {
            day.OnQuotaChanged -= OnQuotaChanged;
        }

        private void OnQuotaChanged(int current, int quota)
        {
            earnedText.text = current.ToString();
            quotaText.text = quota.ToString();
        }
    }
}