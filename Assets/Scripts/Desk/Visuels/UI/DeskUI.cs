using System;
using UnityEngine;

namespace FishyBusiness.Documents.UI
{
    public class DeskUI : MonoBehaviour
    {
        [SerializeField]
        private Desk desk;

        private void OnEnable()
        {
            Bind(desk);
        }

        private void OnDisable()
        {
            Unbind(desk);
        }

        public void Bind(Desk desk)
        {
            desk.OnDocumentAdded += OnDocumentAdded;
            desk.OnDocumentRemoved += OnDocumentRemoved;
        }

        public void Unbind(Desk desk)
        {
            desk.OnDocumentAdded -= OnDocumentAdded;
            desk.OnDocumentRemoved -= OnDocumentRemoved;
        }

        public void ShowDocument(IDocument document)
        {

        }

        public void HideDocument(IDocument document)
        {

        }

        private void OnDocumentAdded(IDocument obj)
        {
            throw new System.NotImplementedException();
        }

        private void OnDocumentRemoved(IDocument obj)
        {
            throw new System.NotImplementedException();
        }

    }
}