using System.Collections;
using TMPro;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample
{
    public class SlotContent : MonoBehaviour
    {
        [SerializeField] private TMP_Text resultText;
        private bool isTimerActive;

        internal SlotHandler handler;

        private bool result;

        public void StartSlotMachine(SlotContext context)
        {
            result = Random.Range(0, 2) == 0;
            resultText.text = "";
            StartCoroutine(WaitSeconds(2f, context));
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
                context.Player.AddMoney(context.BetAmount);
                resultText.text = "Won !!!";
            }
            else
            {
                context.Player.RemoveMoney(context.BetAmount);
                resultText.text = "Loser...";
            }
        }
        
        private IEnumerator WaitSeconds(float time, SlotContext context)
        {
            isTimerActive = true;
            yield return new WaitForSeconds(time);
            isTimerActive = false;
        }
    }
}