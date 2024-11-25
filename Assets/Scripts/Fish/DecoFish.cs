using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace FishyBusiness
{
    public class DecoFish : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            DOTween.Kill(this, true);
            DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, -30, -95), 0.4f, RotateMode.Fast))
                .Append(transform.DORotate(new Vector3(0, -30, -85), 0.8f, RotateMode.Fast))
                .Append(transform.DORotate(new Vector3(0, -30, -95), 0.8f, RotateMode.Fast));
        }

        private void OnMouseEnter()
        {
            DOTween.Kill(this, true);
            DOTween.Sequence()
                .Append(transform.DORotate(new Vector3(0, -30, -95), 0.4f, RotateMode.Fast))
                .Append(transform.DORotate(new Vector3(0, -30, -85), 0.8f, RotateMode.Fast))
                .Append(transform.DORotate(new Vector3(0, -30, -95), 0.8f, RotateMode.Fast))
                .SetTarget(this);

        }
    }
}