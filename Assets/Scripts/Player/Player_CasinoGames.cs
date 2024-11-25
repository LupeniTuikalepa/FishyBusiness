using UnityEngine;

namespace FishyBusiness
{
    public partial class Player
    {
        [field: SerializeField] public int Money { get; private set; } = 500;

        public void AddMoney(int amount) => Money += amount;
        public void RemoveMoney(int amount) => Money -= amount;

        public void ResetMoney()
        {
            Money = 500;
        }
    }
}