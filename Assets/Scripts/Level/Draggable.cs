using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    [RequireComponent(typeof(OutlineFx.OutlineFx))]
    public class Draggable : MonoBehaviour
    {
        private OutlineFx.OutlineFx outline;

        [SerializeField, BoxGroup("Colors")]
        private Color hoverColor = Color.white;
        [SerializeField, BoxGroup("Colors")]
        private Color idleColor = Color.clear;
        [SerializeField, BoxGroup("Colors")]
        private float fade = 0.5f;


        [SerializeField, BoxGroup("Drag")]
        protected Transform draggedTarget;
        [SerializeField, BoxGroup("Drag")]
        private float dragSmoothness = 5f;

        protected Vector2 TargetPos { get; private set; }
        public bool IsDragged { get; private set; }

        protected virtual void Awake()
        {
            outline = GetComponent<OutlineFx.OutlineFx>();
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

        private void OnMouseOver()
        {
            if(IsDragged)
                return;

            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, hoverColor, fade).SetTarget(this);
        }

        private void OnMouseExit()
        {
            if(IsDragged)
                return;

            this.DOKill();
            DOTween.To(() => outline._color, x => outline._color = x, idleColor, fade).SetTarget(this);
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