using System;
using System.Collections.Generic;
using System.Linq;
using FishyBusiness.Data;
using FishyBusiness.DaySystem;
using LTX;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace FishyBusiness.GameSystem.Sample.Tablet
{
    public class MafiaDocs : MonoBehaviour
    {
        [Header("VIP")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI ageText;
        [SerializeField] private TextMeshProUGUI countryText;
        [SerializeField] private TextMeshProUGUI vipCountText;

        [Header("Ranking")]
        [SerializeField]
        private Transform ranksParent;
        [SerializeField]
        private RankInfos rankInfosPrefab;

        [SerializeField]
        private Image rankImagePrefab;

        [Header("Signature")]
        [SerializeField] private Image mafiaLogo;
        [SerializeField] private Image mafiaSignature;
        [SerializeField] private List<Sprite> logo;
        [SerializeField] private List<Sprite> signature;

        private List<Fish> vip;

        private RankInfos[] ranksInfos;
        //private FishGenerator fishGenerator = new FishGenerator();
        private int index = 0;


        private void Awake()
        {
            MafiaRank[] ranks = GameController.GameDatabase.MafiaRanks;
            ranksInfos = new RankInfos[ranks.Length];

            for (int i = 0; i < ranks.Length; i++)
            {
                RankInfos rankInfos = Instantiate(rankInfosPrefab, ranksParent);
                rankInfos.Setup(ranks[i]);

                ranksInfos[i] = rankInfos;
            }
        }

        public void InitMafia(Mafia mafia)
        {
            Day day = LevelManager.Instance.GetDay();

            vip = day.ViPs.ToList();

            GetFishInfo();

            for (int i = 0; i < ranksInfos.Length; i++)
                ranksInfos[i].InitForMafia(mafia, day);

            mafiaLogo.sprite = logo[0];
            mafiaSignature.sprite = signature[0];
        }

        private void GetFishInfo()
        {
            nameText.text = vip[index].name;
            ageText.text = vip[index].birthYear.ToString();
            countryText.text = vip[index].birthCountry.Nationality;
            vipCountText.text = $"{index+1}/{vip.Count}";
        }

        public void NextVIP()
        {
            index++;
            if (index >= vip.Count)
                index = 0;

            GetFishInfo();
        }

        public void PreviousVIP()
        {
            index--;
            if (index < 0)
                index = vip.Count - 1;
            GetFishInfo();
        }
    }
}