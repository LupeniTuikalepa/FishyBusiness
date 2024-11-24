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

        private Vector2 targetPos;
        public bool IsDragged { get; private set; }

        private void Awake()
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
                Vector3 targetWorldPos = new Vector3(targetPos.x, targetPos.y, draggedTarget.position.z);
                draggedTarget.position = Vector3.Lerp(draggedTarget.position, targetWorldPos, dragSmoothness * Time.deltaTime);
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
            IsDragged = true;
            if(draggedTarget != null && draggedTarget != transform)
                draggedTarget.gameObject.SetActive(true);
        }

        public virtual void EndDrag()
        {
            IsDragged = false;
            if(draggedTarget != null && draggedTarget != transform)
                draggedTarget.gameObject.SetActive(false);
        }

        public virtual void Drag(Vector2 worldPos)
        {
            targetPos = worldPos;
        }
    }
}