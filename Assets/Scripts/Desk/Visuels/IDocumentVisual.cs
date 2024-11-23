using UnityEngine;

namespace FishyBusiness.Documents.UI
{
    public interface IDocumentVisual
    {
        // ReSharper disable once InconsistentNaming
        GameObject gameObject { get; }
        IDocument Document { get; }
        public void Bind(IDocument document);
        public void UnBind(IDocument document);
    }
}