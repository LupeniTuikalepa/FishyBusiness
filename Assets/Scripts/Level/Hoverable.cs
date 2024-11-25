using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    public class Hoverable : MonoBehaviour
    {
        private OutlineFx.OutlineFx outline;

        [SerializeField, BoxGroup("Colors")]
        private Color hoverColor = Color.white;
        [SerializeField, BoxGroup("Colors")]
        private Color idleColor = Color.clear;
        [SerializeField, BoxGroup("Colors")]
        private float fade = .25f;

        protected virtual void Awake()
        {
            outline = GetComponent<OutlineFx.OutlineFx>();
        }

        protected virtual void OnMouseOver()
        {
            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, hoverColor, fade).SetTarget(this);
        }

        protected virtual void OnMouseExit()
        {
            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, idleColor, fade).SetTarget(this);
        }
    }
}