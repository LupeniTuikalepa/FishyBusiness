using System;
using System.Globalization;
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
            DateTime date = new DateTime(2024,1,1).AddDays(LevelManager.Instance.CurrentDayIndex);
            text.text = $"{date.Day}\n{date.ToString("MMM", CultureInfo.InvariantCulture).ToUpper()}\n{date.Year}";
        }
    }
}
