using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness.DayManager
{
    public class Day
    {
        public event Action OnDayFinished;
        public event Action<IDayChoice> OnNewChoice; 
        
        private List<IDayChoice> _fishList;
        private IDayChoice currentFish;
        private int quota;
        private int earnedMoney;

        public bool IsFinished => _fishList.Count == 0;
        public bool IsQuotaReached => earnedMoney >= quota;

        //constructor
        public Day(List<IDayChoice> choices, int quota)
        {
            earnedMoney = 0;
            this.quota = quota;
            _fishList = choices;
        }
        //--//

        public void Begin()
        {
            ChooseRandomFish();
        }
        private void ChooseRandomFish()
        {
            if (_fishList.Count <= 0)
            {
                //Debug.Log("jeu finito");
                return;
            }
            
            //Debug.Log("On choisit un poisson :");
            int indexAleatoire = Random.Range(0, _fishList.Count);
            currentFish = _fishList[indexAleatoire];
            Debug.Log(currentFish);
            OnNewChoice?.Invoke(currentFish);
        }
        
        public bool AcceptChoice(out IDayChoice choice)
        {

            choice = currentFish;
            
            bool isRight = currentFish.IsTruth == true;

            if (isRight)
            {
                earnedMoney += currentFish.Money;
            }    
            CompleteChoice();
            
            //Debug.Log("Le poisson est accepter, on lui file la cam");
            
            return isRight;
        }

        public bool DeclineChoice(out IDayChoice choice)
        {
            choice = currentFish;
            
            bool isRight = currentFish.IsTruth == false;

            CompleteChoice();
            
            //Debug.Log("Le poisson est refuser, ça dégage");
            return isRight;
        }

        private void CompleteChoice()
        {
            _fishList.Remove(currentFish);
            if (IsFinished)
            {
                OnDayFinished?.Invoke();
            }
            else
            {
                ChooseRandomFish();
            }
        }
        
    }
}
