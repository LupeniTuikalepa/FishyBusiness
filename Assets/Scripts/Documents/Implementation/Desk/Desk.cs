using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace FishyBusiness.Documents.Visuals.Holders
{
    public class Desk : DocumentsHolderVisual<IDeskDocument>
    {

        private void OnEnable()
        {
            Bind(Player.Instance.DeskDocuments);
        }

        private void OnDisable()
        {
            Bind(Player.Instance.DeskDocuments);
        }

    }
}