using System;
using System.Collections.Generic;
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
        [SerializeField] private TextMeshProUGUI descText;
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

        private List<string> mafias = new List<string>()
        {
            "Orcato",
            "Sharko",
            "Narvalo",
            "Delpho",
        };
        


        public void InitMafia(string mafiaName)
        {
            vip = new List<Fish>()
            {
                
            };

            GetFishInfo();

            List<Sprite> fishSprites = new List<Sprite>(RandomFish.instance.fishes);
            
            foreach (var rank in ranks)
            {
                Sprite f = fishSprites[Random.Range(0, fishSprites.Count)];
                rank.image.sprite = f;
                fishSprites.Remove(f);
            }

            
            mafiaLogo.sprite = logo[mafias.IndexOf(mafiaName)];
            mafiaSignature.sprite = signature[mafias.IndexOf(mafiaName)];
               
        }

        private void GetFishInfo()
        {
            nameText.text = vip[index].Name;
            ageText.text = vip[index].IDCard.Age.ToString();
            countryText.text = vip[index].IDCard.Country;
            descText.text = "Test";
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
