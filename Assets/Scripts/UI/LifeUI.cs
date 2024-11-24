using System;
using DG.Tweening;
using UnityEngine;

namespace FishyBusiness
{
    public class LifeUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject on;
        [SerializeField]
        private GameObject off;

        private void OnEnable()
        {
            Player.Instance.OnHealthChanged += UpdateHealthUI;
        }

        private void OnDisable()
        {
            Player.Instance.OnHealthChanged -= UpdateHealthUI;
        }

        private void UpdateHealthUI(int current, int delta)
        {
            int siblingIndex = transform.GetSiblingIndex();

            on.SetActive(siblingIndex < current);
            off.SetActive(siblingIndex >= current);
        }
    }
}