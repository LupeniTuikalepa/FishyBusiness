using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using FishyBusiness.Documents;
using FishyBusiness.Documents.Flags;
using FishyBusiness.Documents.Tuto;
using LTX.Singletons;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FishyBusiness
{
    public partial class Player : MonoSingleton<Player, PlayerFactory>
    {
        public event Action<int, int> OnHealthChanged;
        public DocumentsHolder DeskDocuments { get; private set; }
        public DocumentsHolder Hand { get; private set; }

        public bool CanSelect => !Hand.IsFull;

        private List<IDocument> temporaryDocuments;

        public int Health { get; private set; }

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

            DeskDocuments.AddDocument(new TutoDocument());
            DeskDocuments.AddDocument(new FlagDocument(GameDatabase.Global.Countries));

            Health = GameMetrics.Global.PlayerLife;
            OnHealthChanged?.Invoke(Health, 0);
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
            LevelManager.Instance.OnNightBegun += ClearTemporaryDocuments;
            PlayerInputs.Enable();
        }


        private void OnDisable()
        {
            LevelManager.Instance.OnNewFish -= GetNewFishId;
            LevelManager.Instance.OnSuccess -= OnSuccess;
            LevelManager.Instance.OnFailure -= OnFailure;
            LevelManager.Instance.OnNightBegun -= ClearTemporaryDocuments;

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

        [Button]
        private void HitOnce() => Hit(1);

        [Button]
        private void Die() => Hit(Health);

        public void Hit(int lifeLoss)
        {
            Health -= lifeLoss;
            OnHealthChanged?.Invoke(Health, -lifeLoss);
            if (Health <= 0)
            {
                LevelManager.Instance.TriggerGameOver();
                PlayerInputs.Disable();
            }
        }

    }
}