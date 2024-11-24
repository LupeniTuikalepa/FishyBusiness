using System;
using LTX;
using UnityEngine;

namespace FishyBusiness
{
    public class LifeBarUI : MonoBehaviour
    {
        [SerializeField]
        private LifeUI lifeUIPrefab;


        private void Start()
        {
            transform.ClearChildren();
            for (int i = 0; i < Player.Instance.Health; i++)
                Instantiate(lifeUIPrefab, transform);
        }
    }
}