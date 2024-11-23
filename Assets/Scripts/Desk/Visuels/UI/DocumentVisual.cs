using UnityEngine;

namespace FishyBusiness.Documents.UI
{
    public abstract class DocumentVisual<T> : IDocumentVisual where T : IDocument
    {
        public IDocument Document { get; set; }

        public void Bind(T document)
        {
            document.OnSelected += OnSelected;
            document.OnUnselected += OnUnselected;
        }

        public void Unbind(T document)
        {
            document.OnSelected -= OnSelected;
            document.OnUnselected -= OnUnselected;
        }

        protected abstract void OnSelected();
        protected abstract void OnUnselected();
    }
}