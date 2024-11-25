using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FishyBusiness
{
    public class MouniaLamp : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GetComponent<Light2D>().enabled = !GetComponent<Light2D>().isActiveAndEnabled;
        }
    }
}