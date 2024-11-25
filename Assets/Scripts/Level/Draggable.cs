using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    [RequireComponent(typeof(OutlineFx.OutlineFx))]
    public class Draggable : Hoverable
    {


        [SerializeField, BoxGroup("Drag")]
        protected Transform draggedTarget;
        [SerializeField, BoxGroup("Drag")]
        private float dragSmoothness = 5f;

        protected Vector2 TargetPos { get; private set; }
        public bool IsDragged { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            OnMouseExit();
        }

        protected virtual void Start()
        {
            if(draggedTarget != null && draggedTarget != transform)
                draggedTarget.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (IsDragged)
            {
                Transform target = draggedTarget == null ? transform : draggedTarget;

                Vector3 targetWorldPos = new Vector3(TargetPos.x, TargetPos.y, target.position.z);
                target.position = Vector3.Lerp(target.position, targetWorldPos, dragSmoothness * Time.deltaTime);
            }
        }

        protected override void OnMouseOver()
        {
            if(IsDragged)
                return;

            base.OnMouseOver();
        }

        protected override void OnMouseExit()
        {
            if(IsDragged)
                return;

            base.OnMouseExit();
        }

        public virtual void BeginDrag()
        {
            OnMouseExit();
            IsDragged = true;
            if(draggedTarget != null && draggedTarget != transform)
                draggedTarget.gameObject.SetActive(true);
        }

        public virtual void EndDrag()
        {
            OnMouseExit();
            IsDragged = false;
            if(draggedTarget != null && draggedTarget != transform)
                draggedTarget.gameObject.SetActive(false);
        }

        public virtual void Drag(Vector2 worldPos)
        {
            TargetPos = worldPos;
        }
    }
}