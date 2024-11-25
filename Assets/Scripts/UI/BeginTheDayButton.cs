using System;
using FishyBusiness.MiniGameSystem;
using FishyBusiness.MiniGameSystem.Interfaces;
using UnityEngine;

namespace FishyBusiness
{
    public class BeginTheDayButton : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            MiniGameManager.Instance.OnGameStarted += Activate;
            MiniGameManager.Instance.OnGameStopped += Deactivate;
        }


        private void OnDisable()
        {
            MiniGameManager.Instance.OnGameStarted -= Activate;
            MiniGameManager.Instance.OnGameStopped -= Deactivate;
        }

        private void Activate(IMiniGameRunner obj)
        {
            canvasGroup.interactable = true;
        }
        private void Deactivate(IMiniGameRunner obj)
        {
            canvasGroup.interactable = false;
        }
    }
}