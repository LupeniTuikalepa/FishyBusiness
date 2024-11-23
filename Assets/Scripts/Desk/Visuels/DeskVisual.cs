using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.Documents.UI;
using UnityEngine;
using Object = System.Object;

namespace FishyBusiness.Documents.Visuals
{
    public abstract class DeskVisual : MonoBehaviour
    {
        private DeskAnchor[] anchors;

        private List<IDocumentVisual> documentsUI;

        private void Awake()
        {
            anchors = GetComponentsInChildren<DeskAnchor>();
        }

        public virtual void Bind(Desk desk)
        {
            desk.OnDocumentAdded += AddDocumentVisual;
            desk.OnDocumentRemoved += RemoveDocumentVisual;
        }


        public virtual void Unbind(Desk desk)
        {
            desk.OnDocumentAdded -= AddDocumentVisual;
            desk.OnDocumentRemoved -= RemoveDocumentVisual;
        }

        protected virtual void AddDocumentVisual(IDocument document)
        {
            for (int i = 0; i < anchors.Length; i++)
            {
                DocumentData data = document.Data;
                if (anchors[i].DocumentData == data)
                {
                    var go = GameObject.Instantiate(data.UIPrefab);
                    if (go.TryGetComponent(out IDocumentVisual visual))
                    {
                        var visual = ;
                    }
                    else
                    {
                    }
                }
            }
        }

        protected virtual void RemoveDocumentVisual(IDocument document)
        {

        }

    }
}