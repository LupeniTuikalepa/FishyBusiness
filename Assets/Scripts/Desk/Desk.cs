using System;
using System.Collections.Generic;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public class Desk
    {
        public event Action<IDocument> OnDocumentAdded;
        public event Action<IDocument> OnDocumentRemoved;

        private List<IDocument> documents;

        public void AddDocument(IDocument document)
        {
            OnDocumentAdded?.Invoke(document);
        }

        public void RemoveDocument(IDocument document)
        {
            OnDocumentRemoved?.Invoke(document);
        }

    }
}