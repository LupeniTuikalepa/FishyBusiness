using System;
using FishyBusiness.DaySystem;
using UnityEngine;

namespace FishyBusiness
{
    [RequireComponent(typeof(CanvasGroup))]
    public class InteractableAtDayPhase : MonoBehaviour
    {
        [SerializeField]
        private LevelManager.DayPhase dayPhase;

        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += InstanceOnOnDayBegun;
            LevelManager.Instance.OnNightBegun += InstanceOnOnNightBegun;
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnDayBegun -= InstanceOnOnDayBegun;
            LevelManager.Instance.OnNightBegun -= InstanceOnOnNightBegun;
        }

        private void InstanceOnOnDayBegun(Day obj)
        {
            canvasGroup.interactable = (dayPhase & LevelManager.DayPhase.Day) != 0;
        }

        private void InstanceOnOnNightBegun()
        {
            canvasGroup.interactable = (dayPhase & LevelManager.DayPhase.Night) != 0;
        }
    }
}