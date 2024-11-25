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

        private AudioSource audioSource;

        protected override void Start()
        {
            audioSource = GetComponent<AudioSource>();
            
            base.Start();
            fish.gameObject.SetActive(false);
        }

        public override void BeginDrag()
        {
            audioSource.Play();
            
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

            Collider2D[] results = new Collider2D[32];
            int count = Physics2D.OverlapPoint(TargetPos, new ContactFilter2D()
            {
                layerMask = dropMask,
            }, results);

            if(count > 0)
                LevelManager.Instance.MakeChoice(fishFood);
        }
    }
}