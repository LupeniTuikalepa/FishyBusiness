using System;
using System.Globalization;
using FishyBusiness.DaySystem;
using TMPro;
using UnityEngine;

namespace FishyBusiness
{
    public class TimeUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI timeText;
        [SerializeField]
        private TextMeshProUGUI dateText;

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += SyncDate;
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnDayBegun -= SyncDate;
        }


        private void Update()
        {
            if(LevelManager.HasInstance)
                timeText.text = Mathf.Ceil(LevelManager.Instance.CurrentDayTime).ToString(CultureInfo.InvariantCulture) + " sec";
        }

        private void SyncDate(Day day)
        {
            dateText.text = $"Day {LevelManager.Instance.CurrentDayIndex}";
        }
    }
}