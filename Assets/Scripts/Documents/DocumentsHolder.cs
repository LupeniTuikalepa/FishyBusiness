using System;
using System.Collections.Generic;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public class DocumentsHolder
    {
        public event Action<IDocument> OnDocumentSelected;
        public event Action<IDocument> OnDocumentUnselected;

        public event Action<IDocument> OnDocumentAdded;
        public event Action<IDocument> OnDocumentRemoved;

        private List<IDocument> documents;

        public IDocument SelectedDocument { get; private set; }

        public DocumentsHolder(params IDocument[] documents)
        {
            this.documents = new List<IDocument>(documents);
        }

        public void SelectDocument(IDocument document)
        {
            if (SelectedDocument == null)
                return;

            if(SelectedDocument == document)
                return;

            UnselectCurrentDocument();
            SelectedDocument = document;
            OnDocumentSelected?.Invoke(document);
        }

        private void UnselectCurrentDocument()
        {
            if (SelectedDocument != null)
            {
                SelectedDocument = null;
                OnDocumentUnselected?.Invoke(SelectedDocument);
            }
        }


        public void AddDocument(IDocument document)
        {
            documents.Add(document);
            OnDocumentAdded?.Invoke(document);
        }

        public void RemoveDocument(IDocument document)
        {
            if(documents.Remove(document))
                OnDocumentRemoved?.Invoke(document);
        }

    }
}