using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace FishyBusiness
{
    public partial class Player
    {
        public PlayerInputs PlayerInputs { get; private set; }

        public Draggable CurrentDraggable { get; private set; }

        [SerializeField]
        private LayerMask draggableMask;

        List<RaycastResult> resultsBuffer = new List<RaycastResult>();
        private void SetupInputs()
        {
            resultsBuffer ??= new List<RaycastResult>();

            PlayerInputs.Player.DragItem.performed += OnDragInput;
        }

        private void UpdateDrag()
        {
            if (CurrentDraggable != null)
            {
                Vector2 screenPos = Pointer.current.position.ReadValue();

                Vector2 worldPos = GameCamera.Instance.MainCamera.ScreenToWorldPoint(screenPos);
                CurrentDraggable.Drag(worldPos);
            }
        }
        private void OnDragInput(InputAction.CallbackContext ctx)
        {
            Vector2 screenPos = Pointer.current.position.ReadValue();

            Vector2 worldPos = GameCamera.Instance.MainCamera.ScreenToWorldPoint(screenPos);

            bool isGrab = ctx.ReadValueAsButton();

            if(isGrab && CurrentDraggable == null)
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current)
                {
                    position = screenPos
                };

                EventSystem.current.RaycastAll(eventData, resultsBuffer);
                foreach (RaycastResult result in resultsBuffer)
                    Debug.Log(result.gameObject.name);
                if(resultsBuffer.Count > 0)
                    return;

                Collider2D hit = Physics2D.OverlapPoint(worldPos, draggableMask);
                if (hit != null && hit.TryGetComponent(out Draggable draggable))
                {
                    CurrentDraggable = draggable;
                    draggable.BeginDrag();
                }
            }
            if(!isGrab && CurrentDraggable != null)
            {
                CurrentDraggable.EndDrag();
                CurrentDraggable = null;
            }
        }
    }
}