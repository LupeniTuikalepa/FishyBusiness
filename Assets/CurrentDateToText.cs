using System;
using FishyBusiness.DaySystem;
using TMPro;
using UnityEngine;

namespace FishyBusiness
{
    public class CurrentDateToText : MonoBehaviour
    {
        private TextMeshProUGUI text;
        
        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            UpdateDate(null);
            LevelManager.Instance.OnDayBegun += UpdateDate;
        }

        private void UpdateDate(Day day)
        {
            DateTime date = LevelManager.Instance.dayDate;
            text.text = $"{date.Day}\n{date.Month.ToString()}\n{date.Year}";
        }
    }
}
