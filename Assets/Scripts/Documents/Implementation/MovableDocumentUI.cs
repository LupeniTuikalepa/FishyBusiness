using System;
using FishyBusiness.Documents.UI;
using FishyBusiness.Documents.Visuals.Holders;
using Michsky.UI.ModernUIPack;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public class MovableDocumentUI<T> : DocumentVisual<T>, IHandDocument where T : IDocument
    {
        private WindowDragger dragger;
        private void Awake()
        {
            dragger = GetComponent<WindowDragger>();
        }

        private void Start()
        {
            if (dragger != null)
            {
                dragger.dragArea = transform.parent as RectTransform;
                dragger.dragObject = transform as RectTransform;
            }
        }
        public void Deselect()
        {
            Player.Instance.Deselect(this);
        }
    }
}