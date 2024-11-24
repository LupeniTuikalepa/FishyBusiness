using UnityEngine;

namespace FishyBusiness
{
    public class Box : Draggable
    {
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
        }
    }
}