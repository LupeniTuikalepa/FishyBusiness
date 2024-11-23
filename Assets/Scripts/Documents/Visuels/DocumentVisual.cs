using UnityEngine;

namespace FishyBusiness.Documents.UI
{
    public abstract class DocumentVisual<T> : MonoBehaviour, IDocumentVisual where T : IDocument
    {
        public IDocument Document { get; private set; }

        protected virtual void Bind(T document)
        {

        }

        protected virtual void Unbind(T document)
        {

        }

        void IDocumentVisual.Bind(IDocument document)
        {
            if (document is T t)
            {
                Bind(t);
                Document = document;
            }
        }

        void IDocumentVisual.UnBind(IDocument document)
        {
            if (document is T t)
            {
                Document = document;
                Unbind(t);
            }
        }

        protected abstract void OnSelected();
        protected abstract void OnUnselected();
    }
}