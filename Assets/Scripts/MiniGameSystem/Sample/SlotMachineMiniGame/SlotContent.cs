﻿using System.Collections;
using FishyBusiness.MiniGameSystem.Interfaces;
using TMPro;
using UnityEngine;

namespace FishyBusiness.MiniGameSystem.Sample
{
    public class SlotContent : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultText;
        private bool isTimerActive;
        private bool result;

        public void StartSlotMachine(SlotContext context)
        {
            if (context.status != GameStatus.None) return;
            
            result = Random.Range(0, 3) == 0;
            resultText.text = "";
            StartCoroutine(WaitSeconds(2f));
        }

        public bool GetResult(out bool slotResult)
        {
            slotResult = result;
            if (isTimerActive)
            {
                return false;
            }
            
            return true;
        }

        public void ShowResult(SlotContext context)
        {
            if (result)
            {
                context.Player.AddMoney(context.BetAmount * 3);
                resultText.text = "Won !!!";
            }
            else
            {
                resultText.text = "Loser...";
            }
        }
        
        private IEnumerator WaitSeconds(float time)
        {
            isTimerActive = true;
            yield return new WaitForSeconds(time);
            isTimerActive = false;
        }
    }
}