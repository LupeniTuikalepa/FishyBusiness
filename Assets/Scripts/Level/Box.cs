using System;
using DG.Tweening;
using FishyBusiness.Fishes;
using UnityEngine;

namespace FishyBusiness
{
    public class Box : Draggable
    {
        [SerializeField]
        private LayerMask dropMask;

        [SerializeField]
        private FishFood fishFood;

        [SerializeField]
        private Transform fish;
        [SerializeField]
        private Transform startPos;

        protected override void Start()
        {
            base.Start();
            fish.gameObject.SetActive(false);
        }

        public override void BeginDrag()
        {
            base.BeginDrag();
            draggedTarget.transform.position = startPos.position;
            fish.transform.position = startPos.position;
            fish.gameObject.SetActive(true);
        }

        public override void EndDrag()
        {
            base.EndDrag();

            draggedTarget.transform.position = startPos.position;
            fish.transform.position = startPos.position;
            fish.gameObject.SetActive(false);

            Collider2D hit = Physics2D.OverlapPoint(TargetPos, dropMask);
            if (hit != null)
            {
                LevelManager.Instance.MakeChoice(fishFood);
            }
        }



    }
}