using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using FishyBusiness.Documents;
using LTX.Singletons;
using UnityEngine.InputSystem;

namespace FishyBusiness
{
    public partial class Player : MonoSingleton<Player, PlayerFactory>
    {

        public DocumentsHolder DeskDocuments { get; private set; }
        public DocumentsHolder Hand { get; private set; }

        public bool CanSelect => !Hand.IsFull;

        private List<IDocument> temporaryDocuments;


        protected override void Awake()
        {
            base.Awake();
            temporaryDocuments = new List<IDocument>();
            DeskDocuments = new DocumentsHolder(-1);
            Hand = new DocumentsHolder(1);
            PlayerInputs = new PlayerInputs();

        }

        private void Start()
        {
            SetupInputs();
        }

        private void Update()
        {
            UpdateDrag();
        }

        private void OnEnable()
        {
            LevelManager.Instance.OnNewFish += GetNewFishId;
            LevelManager.Instance.OnSuccess += OnSuccess;
            LevelManager.Instance.OnFailure += OnFailure;
            PlayerInputs.Enable();
        }


        private void OnDisable()
        {
            LevelManager.Instance.OnNewFish -= GetNewFishId;
            PlayerInputs.Disable();
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