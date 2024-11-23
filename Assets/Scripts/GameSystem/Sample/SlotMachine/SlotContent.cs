using System.Collections;
using TMPro;
using UnityEngine;

namespace FishyBusiness.GameSystem.Sample
{
    public class SlotContent : MonoBehaviour
    {
        [SerializeField] private TMP_Text result;
        private bool isTimerActive;

        internal SlotHandler handler;

        public bool GetResult(out bool slotResult)
        {
            slotResult = Random.Range(0, 2) == 0;
            if (isTimerActive)
            {
                return false;
            }
            
            result.text = "";
            return true;
        }
        
        public void ShowResult(bool slotResult, Player player, int betAmount)
        {
            StartCoroutine(WaitSeconds(2f, slotResult, player, betAmount));
        }

        private IEnumerator WaitSeconds(float time, bool slotResult, Player player, int betAmount)
        {
            isTimerActive = true;
            yield return new WaitForSeconds(time);
            
            if (slotResult)
            {
                player.AddMoney(betAmount);
                result.text = "Won !!!";
            }
            else
            {
                player.RemoveMoney(betAmount);
                result.text = "Loser...";
            }
            
            isTimerActive = false;
        }
    }
}