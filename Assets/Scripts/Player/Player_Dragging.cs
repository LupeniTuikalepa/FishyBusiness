using System;
using System.Collections.Generic;
using FishyBusiness.Documents.Visuals.Holders;
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
            PlayerInputs.Player.Click.performed += OnClickInput;
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

                if(resultsBuffer.Count > 0)
                    return;

                Collider2D[] results = new Collider2D[32];
                int count = Physics2D.OverlapPoint(worldPos, new ContactFilter2D()
                {
                    layerMask = draggableMask,
                },
                    results);

                for (int i = 0; i < count; i++)
                {
                    var hit = results[i];
                    if (hit != null && hit.TryGetComponent(out Draggable draggable))
                    {
                        CurrentDraggable = draggable;
                        draggable.BeginDrag();
                    }
                }
                eventData.Use();
            }
            if(!isGrab && CurrentDraggable != null)
            {
                CurrentDraggable.EndDrag();
                CurrentDraggable = null;
            }
        }

        public void Deselect(IHandDocument handDocument)
        {
            DeskDocuments.AddDocument(handDocument.Document);
            Hand.RemoveDocument(handDocument.Document);
        }

        private void OnClickInput(InputAction.CallbackContext obj)
        {
            if(CanSelect)
            {
                Vector2 screenPos = Pointer.current.position.ReadValue();
                Vector2 worldPos = GameCamera.Instance.MainCamera.ScreenToWorldPoint(screenPos);

                PointerEventData eventData = new PointerEventData(EventSystem.current)
                {
                    position = screenPos
                };

                EventSystem.current.RaycastAll(eventData, resultsBuffer);
                if(resultsBuffer.Count > 0)
                    return;

                Collider2D[] results = new Collider2D[32];
                int count = Physics2D.OverlapPoint(worldPos, new ContactFilter2D(), results);

                for (int i = 0; i < count; i++)
                {
                    var hit = results[i];
                    if (hit != null && hit.TryGetComponent(out IDeskDocument deskDocument))
                    {
                        Hand.AddDocument(deskDocument.Document);
                        DeskDocuments.RemoveDocument(deskDocument.Document);
                    }
                }
                eventData.Use();
            }
        }
    }
}