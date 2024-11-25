using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.Documents.Flags
{
    public class FlagUI : MonoBehaviour
    {

        [SerializeField]
        private RawImage rawImage;

        [SerializeField]
        private TextMeshProUGUI text;

        public void SetInfos(string name, Texture flag)
        {
            text.text = name;
            rawImage.texture = flag;
        }
    }
}