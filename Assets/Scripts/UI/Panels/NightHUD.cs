using System;
using DG.Tweening;
using FishyBusiness.DaySystem;
using UnityEngine;

namespace FishyBusiness.UI.Panels
{
    public class NightHUD : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        private void Start()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += Hide;
            LevelManager.Instance.OnNightBegun += Show;
        }


        private void Show()
        {
            canvasGroup.DOFade(1, .5f);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        }
        private void Hide(Day obj)
        {
            canvasGroup.DOFade(0, .5f);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}