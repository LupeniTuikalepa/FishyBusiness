using System.Collections.Generic;
using FishyBusiness.DaySystem;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness.Fishes
{
    public class FishDialogue : MonoBehaviour
    {
        [SerializeField] private Transform dialogueSpawn;
        [SerializeField] private GameObject dialoguePrefab;
        private List<string> successDialogues;
        private List<string> failureDialogues;
        
        private GameObject currentDialogue;

        private void Awake()
        {
            successDialogues = new List<string>
            {
                "Thanks my guy !",
                "It's alright for now.",
                "See you next time.",
                "Ok.",
                "We've never met my friend.",
                "Don't tell anyone about it.",
                "Thanks !",
                "I will recommend you.",
                "I'm fine with that."
            };
            
            failureDialogues = new List<string>
            {
                "You little brat !",
                "We will see each other soon again !",
                "There will be no third chance !",
                "You had one job !",
                "Hmmm not cool, really not cool..",
                "Last time I trust you.",
                "I'll remember..",
                "How dare you !?"
            };
        }

        public void OnFishFailure(IDayFish iDayFish, Day day)
        {
            Debug.Log("FAILLLLLLLLLLLLL");
            string dialogue = failureDialogues[Random.Range(0, failureDialogues.Count)];
            SpawnDialogue(iDayFish, dialogue);
        }
        
        public void OnFishSuccess(IDayFish iDayFish, Day day)
        {
            Debug.Log("SUCCESSSSSSSSSS");
            string dialogue = successDialogues[Random.Range(0, successDialogues.Count)];
            SpawnDialogue(iDayFish, dialogue);
        }

        private void SpawnDialogue(IDayFish iDayFish, string dialogue)
        {
            currentDialogue = Instantiate(dialoguePrefab, dialogueSpawn);
            TMP_Text dialogueText = currentDialogue.GetComponent<GetTextInDialogueWindow>().Dialogue;
            TMP_Text WindowTitle = currentDialogue.GetComponent<GetTextInDialogueWindow>().WindowTitle;
            
            WindowTitle.text = $"<b>{iDayFish.Fish.name}</b>";
            dialogueText.text = $"{dialogue}";
            Destroy(currentDialogue, 2f);
        }
    }
}