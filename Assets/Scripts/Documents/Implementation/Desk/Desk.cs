using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace FishyBusiness.Documents.Visuals.Holders
{
    public class Desk : DocumentsHolderVisual<IDeskDocument>
    {
        [SerializeField]
        private Player player;

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            GetInputModule().leftClick.action.performed += TrySelect;
        }

        private void OnDisable()
        {
            GetInputModule().leftClick.action.performed -= TrySelect;
        }

        private static InputSystemUIInputModule GetInputModule()
        {
            return (EventSystem.current.currentInputModule as InputSystemUIInputModule);
        }


        private void TrySelect(InputAction.CallbackContext ctx)
        {
            if(player.Hand.IsFull)
                return;

            Vector2 screenPos = GetInputModule().point.action.ReadValue<Vector2>();

            Ray ray = mainCamera.ScreenPointToRay(screenPos);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IDeskDocument document))
                    player.Hand.AddDocument(document.Document);
            }
        }
    }
}