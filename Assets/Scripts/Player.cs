using System;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness
{
    public partial class Player : MonoBehaviour
    {
        public DocumentsHolder DeskDocuments { get; private set; }

        public DocumentsHolder Hand { get; private set; }


        public bool CanSelect => !Hand.IsFull;

        private void Awake()
        {
            DeskDocuments = new DocumentsHolder(-1);
            Hand = new DocumentsHolder(1);
        }
    }
}