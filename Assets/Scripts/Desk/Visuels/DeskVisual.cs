using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.Documents.UI;
using LTX.Tools;
using UnityEngine;

namespace FishyBusiness.Documents.Visuals
{
    public abstract class DeskVisual : MonoBehaviour, ILogSource
    {
        string ILogSource.Name => "DeskVisual";

        private DeskAnchor[] anchors;

        private List<IDocumentVisual> documentsUI;

        private DynamicBuffer<IDocumentVisual> dynamicBuffer;


        [SerializeField]
        private Player player;

        private void Awake()
        {
            dynamicBuffer = new DynamicBuffer<IDocumentVisual>(32);
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
                    GameObject go = Instantiate(data.UIPrefab);
                    if (go.TryGetComponent(out IDocumentVisual visual))
                        visual.Bind(document);
                    else
                        GameController.Logger.LogError(this, $"Couldn't find {nameof(IDocumentVisual)} on prefab {data.UIPrefab.name}");
                }
            }
        }

        protected virtual void RemoveDocumentVisual(IDocument document)
        {
            dynamicBuffer.CopyFrom(documentsUI);

            for (int i = 0; i < dynamicBuffer.Length; i++)
            {
                IDocumentVisual visual = dynamicBuffer[i];
                if (visual.Document == document)
                {
                    visual.UnBind(document);
                    documentsUI.Remove(visual);

                    Destroy(visual.gameObject);
                }
            }
        }

    }
}