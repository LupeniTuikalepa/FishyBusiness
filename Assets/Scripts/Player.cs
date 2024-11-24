using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness
{
    public partial class Player : MonoBehaviour
    {
        public DocumentsHolder DeskDocuments { get; private set; }
        public DocumentsHolder Hand { get; private set; }

        public bool CanSelect => !Hand.IsFull;

        private List<IDocument> temporaryDocuments;

        private void Awake()
        {
            temporaryDocuments = new List<IDocument>();
            DeskDocuments = new DocumentsHolder(-1);
            Hand = new DocumentsHolder(1);
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnNewChoice += GetNewFishId;
            LevelManager.Instance.OnSuccess += OnSuccess;
            LevelManager.Instance.OnFailure += OnFailure;
        }


        private void OnDisable()
        {
            LevelManager.Instance.OnNewChoice -= GetNewFishId;
        }

        private void GetNewFishId(IDayFish dailyFish)
        {
            ClearTemporaryDocuments();

            IdentityDocument identityDocument = new IdentityDocument(dailyFish.Fish);

            DeskDocuments.AddDocument(identityDocument);
            temporaryDocuments.Add(identityDocument);
        }
        private void OnSuccess(IDayFish fish, Day day)
        {
            ClearTemporaryDocuments();
        }

        private void OnFailure(IDayFish fish, Day day)
        {
            ClearTemporaryDocuments();
        }

        private void ClearTemporaryDocuments()
        {
            foreach (var doc in temporaryDocuments)
            {
                DeskDocuments.RemoveDocument(doc);
                Hand.RemoveDocument(doc);
            }
            temporaryDocuments.Clear();

        }
    }
}