using System;
using System.Collections.Generic;
using UnityEngine;

namespace FishyBusiness.DayManager
{
    
    public class DayManager : MonoBehaviour
    {
        private class Trust : IDayChoice
        {
            public bool IsTruth => true;
        }

        private class Lie : IDayChoice
        {
            public bool IsTruth => false;
        }
        
        private Day day;


        public void Start()
        {
            List<IDayChoice> choices = new List<IDayChoice>()
            {
                new Trust(),
                new Lie(),
                new Trust(),
                new Lie(),
                new Trust(),
                new Lie(),
            };

            day = new Day(choices);
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && day.IsFinished == false)
            {
                bool wasRight = day.AcceptChoice();

                if (wasRight)
                {
                    Debug.Log("il dit la vérité");
                }
                else
                {
                    Debug.Log("MEUTEURRRR");
                }
                
            }
            
            if (Input.GetKeyDown(KeyCode.Z) && day.IsFinished == false)
            {
                bool wasRight = day.DeclineChoice();

                if (!wasRight)
                {
                    Debug.Log("il dit la vérité");
                }
                else
                {
                    Debug.Log("MEUTEURRRR");
                }
                
            }
        }
    }
}