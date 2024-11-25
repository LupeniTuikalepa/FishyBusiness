using TMPro;
using UnityEngine;

namespace FishyBusiness
{
    public class UpdateMoney : MonoBehaviour
    {
        public TextMeshProUGUI money;
        void Update()
        {
            money.text = $"Money: {Player.Instance.Money.ToString()}";
        }
    }
}
