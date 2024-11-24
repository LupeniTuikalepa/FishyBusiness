using System;
using DG.Tweening;
using UnityEngine;

namespace FishyBusiness
{
    [RequireComponent(typeof(OutlineFx.OutlineFx))]
    public class Draggable : MonoBehaviour
    {
        private OutlineFx.OutlineFx outline;

        [SerializeField]
        private Color hoverColor = Color.white;
        [SerializeField]
        private Color idleColor = Color.clear;

        [SerializeField]
        private float fade = 0.5f;


        private void Awake()
        {
            outline = GetComponent<OutlineFx.OutlineFx>();
            OnMouseExit();
        }

        private void OnMouseOver()
        {
            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, hoverColor, fade).SetTarget(this);
        }

        private void OnMouseExit()
        {
            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, idleColor, fade).SetTarget(this);
        }

    }
}