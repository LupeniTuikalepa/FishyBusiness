using System;
using System.Collections.Generic;
using System.Linq;
using FishyBusiness.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace FishyBusiness.GameSystem.Sample.Tablet
{
    [Serializable]
    struct Rank
    {
        public string name;
        public Image image;
    }
    
    public class MafiaDocs : MonoBehaviour
    {
        [Header("VIP")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI ageText;
        [SerializeField] private TextMeshProUGUI countryText;
        [SerializeField] private TextMeshProUGUI vipCountText;
        
        [Header("Ranking")]
        [SerializeField] private List<Rank> ranks = new List<Rank>();

        [Header("Signature")] 
        [SerializeField] private Image mafiaLogo;
        [SerializeField] private Image mafiaSignature;
        [SerializeField] private List<Sprite> logo;
        [SerializeField] private List<Sprite> signature;
        
        private List<Fish> vip;
        //private FishGenerator fishGenerator = new FishGenerator();
        private int index = 0;

        public void InitMafia(string mafiaName)
        {
            vip = LevelManager.Instance.GetDay().ViPs.ToList();

            GetFishInfo();
            
            foreach (var rank in GameDatabase.Global.MafiaRanks)
            {
                List<Rank> rankList = ranks.Where(x => x.name == rank.name).ToList();
                int index = 0;
                foreach (var r in rankList)
                {
                    r.image.sprite = rank.sprites[mafiaName][index];
                    index++;
                }
            }
            
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
