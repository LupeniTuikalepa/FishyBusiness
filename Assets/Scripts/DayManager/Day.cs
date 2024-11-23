using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FishyBusiness.DayManager
{
    public class Day 
    {
        private List<IDayChoice> _fishList;
        private IDayChoice currentFish;
        public bool IsFinished => _fishList.Count == 0;

        public Day(List<IDayChoice> choices)
        {
            _fishList = choices;
            ChooseRandomFish();
        }
        
        private void ChooseRandomFish()
        {
            if (_fishList.Count <= 0)
            {
                Debug.Log("jeu finito");
                return;
            }
            
            Debug.Log("On choisit un poisson :");
            int indexAleatoire = Random.Range(0, _fishList.Count);
            currentFish = _fishList[indexAleatoire];
            Debug.Log(currentFish);
        }
        
        public bool AcceptChoice()
        {
            bool isRight = currentFish.IsTruth == true;
                
            CompleteChoice();
            
            Debug.Log("Le poisson est accepter, on lui file la cam");
            return isRight;
        }

        public bool DeclineChoice()
        {
            bool isRight = currentFish.IsTruth == false;

            CompleteChoice();
            
            Debug.Log("Le poisson est refuser, ça dégage");
            return isRight;
        }

        private void CompleteChoice()
        {
            
            _fishList.Remove(currentFish);
            ChooseRandomFish();
        }
        
    }
}
