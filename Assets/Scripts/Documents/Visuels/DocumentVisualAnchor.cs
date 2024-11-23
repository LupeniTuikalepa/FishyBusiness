using System;
using FishyBusiness.Documents.Data;
using UnityEngine;

namespace FishyBusiness.Documents.Visuals
{
    public class DocumentVisualAnchor : MonoBehaviour
    {
        [SerializeField]
        private DocumentData documentData;

        public DocumentData DocumentData => documentData;
    }
}