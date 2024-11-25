using System;
using FishyBusiness.Fishes;
using UnityEngine;

namespace FishyBusiness
{
    public class DeluxeFish : Draggable
    {
        [SerializeField]
        private LayerMask dropMask;

        [SerializeField]
        private Rigidbody2D anchor;

        private LineRenderer rope;
        private Rigidbody2D rb2D;
        private Joint2D joint2D;

        protected override void Awake()
        {
            base.Awake();

            joint2D = GetComponent<Joint2D>();
            rb2D = GetComponent<Rigidbody2D>();

            rope = anchor.GetComponent<LineRenderer>();
            rope.positionCount = 2;
        }


        private void FixedUpdate()
        {
            rope.SetPosition(0, joint2D.attachedRigidbody.position);
            rope.SetPosition(1, joint2D.connectedBody.position);
        }

        public override void BeginDrag()
        {
            base.BeginDrag();

            rope.enabled = false;
            rb2D.simulated = false;
        }

        public override void EndDrag()
        {
            base.EndDrag();

            rope.enabled = true;
            rb2D.simulated = true;

            transform.position = joint2D.connectedBody.position;


            Collider2D[] results = new Collider2D[32];
            int count = Physics2D.OverlapPoint(TargetPos, new ContactFilter2D()
            {
                layerMask = dropMask,
            }, results);
            
            

            if(count > 0)
                LevelManager.Instance.MakeChoice(FishFood.Deluxe);
        }
    }
}