using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using LTX;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness
{
    public class RankInfos : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI rankName;
        [SerializeField]
        private Image rankImagePrefab;

        private List<Image> images;
        private MafiaRank rank;

        private void Awake()
        {
            images = new();
        }

        public void Setup(MafiaRank rank)
        {
            this.rank = rank;
        }

        public void InitForMafia(Mafia mafia, Day day)
        {
            images ??= new();
            foreach (Image image in images)
                Destroy(image.gameObject);

            images.Clear();
            rankName.text = rank.name;

            for (int i = 0; i < day.MafiaFishes.Length; i++)
            {
                Fish fish = day.MafiaFishes[i];
                ProcessFish(mafia, fish);
            }
            for (int i = 0; i < day.ViPs.Length; i++)
            {
                Fish fish = day.ViPs[i];
                ProcessFish(mafia, fish);
            }
        }

        private void ProcessFish(Mafia mafia, Fish fish)
        {
            if (fish.mafia == mafia && fish.rank == rank)
            {
                Image image = Instantiate(rankImagePrefab, transform);
                image.sprite = fish.photo;

                images.Add(image);
            }
        }
    }
}