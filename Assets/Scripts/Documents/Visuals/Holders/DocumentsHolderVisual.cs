using System;
using System.Collections.Generic;
using System.Reflection;
using FishyBusiness.Documents.UI;
using UnityEngine;

namespace FishyBusiness.Documents.Visuals.Holders
{
    public abstract class DocumentsHolderVisual<T> : MonoBehaviour where T : IDocumentVisual
    {
        [SerializeField]
        private DocumentPrefabPair[] prefabs;

        private Dictionary<IDocument, T> documents;
        private Dictionary<DocumentType, DocumentVisualAnchor> anchors;

        private void Start()
        {
            documents = new Dictionary<IDocument, T>();
            anchors = new Dictionary<DocumentType, DocumentVisualAnchor>();

            DocumentVisualAnchor[] documentVisualAnchors = GetComponentsInChildren<DocumentVisualAnchor>();
            for (int i = 0; i < documentVisualAnchors.Length; i++)
                anchors.Add(documentVisualAnchors[i].documentType, documentVisualAnchors[i]);
        }

        protected virtual void Bind(DocumentsHolder holder)
        {
            holder.OnDocumentAdded += AddDocumentVisual;
            holder.OnDocumentRemoved += RemoveDocumentVisual;
        }


        protected virtual void Unbind(DocumentsHolder holder)
        {
            holder.OnDocumentAdded -= AddDocumentVisual;
            holder.OnDocumentRemoved -= RemoveDocumentVisual;
        }

        protected virtual void RemoveDocumentVisual(IDocument document)
        {
            if (documents.Remove(document, out T documentVisual))
            {
                UnbindDocument(documentVisual, document);
                Destroy(documentVisual.gameObject);
            }
        }

        protected virtual void AddDocumentVisual(IDocument document)
        {
            if (TryGetPrefabForType(document.DocumentType, out GameObject prefab))
            {
                Transform root = transform;

                if (anchors.TryGetValue(document.DocumentType, out DocumentVisualAnchor anchor))
                    root = anchor.transform;

                GameObject instance = Instantiate(prefab, root);

                if (instance.TryGetComponent(out T documentVisual))
                {
                    if (documents.TryAdd(document, documentVisual))
                    {
                        documentVisual.Bind(document);
                        BindDocument(documentVisual, document);
                        return;
                    }
                }

                Destroy(instance);
            }
        }


        private bool TryGetPrefabForType(DocumentType documentType, out GameObject prefab)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                if (prefabs[i].DocumentType == documentType)
                {
                    prefab = prefabs[i].Prefab;
                    return true;
                }
            }

            prefab = null;
            return false;
        }

        protected virtual void BindDocument(T documentVisual, IDocument document)
        {

        }

        protected virtual void UnbindDocument(T documentVisual, IDocument document)
        {

        }
    }
}