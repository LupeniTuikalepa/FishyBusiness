using System;
using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents.Visuals
{
    public class DeskAnchor : MonoBehaviour
    {
        [SerializeField]
        private DocumentData documentData;

        public DocumentData DocumentData => documentData;

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}