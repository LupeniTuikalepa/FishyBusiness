using System;
using DG.Tweening;
using FishyBusiness.DaySystem;
using UnityEngine;

namespace FishyBusiness.UI.Panels
{
    public class DayHUD : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            Show(null);
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnDayBegun += Show;
            LevelManager.Instance.OnNightBegun += Hide;
        }


        private void Show(Day obj)
        {
            canvasGroup.DOFade(1, .5f);
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        }
        private void Hide()
        {
            canvasGroup.DOFade(0, .5f);
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}