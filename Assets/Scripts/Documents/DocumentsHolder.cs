using System;
using System.Collections.Generic;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public class DocumentsHolder
    {
        public event Action<IDocument> OnDocumentAdded;
        public event Action<IDocument> OnDocumentRemoved;

        public bool IsFull => documents.Count >= maxSize;

        public bool IsEmpty => documents.Count == 0;

        private readonly List<IDocument> documents;

        private readonly int maxSize;

        public DocumentsHolder(int maxSize, params IDocument[] documents)
        {
            this.maxSize = maxSize;
            this.documents = new List<IDocument>(documents);
        }

        public void AddDocument(IDocument document)
        {
            if (maxSize > 0 && documents.Count < maxSize)
            {
                documents.Add(document);
                OnDocumentAdded?.Invoke(document);
            }
        }

        public void RemoveDocument(IDocument document)
        {
            if (documents.Remove(document))
                OnDocumentRemoved?.Invoke(document);
        }
    }
}