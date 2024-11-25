using System;
using UnityEngine;

namespace FishyBusiness
{
    public class CursorParticle : MonoBehaviour
    {
        [SerializeField] private Vector2 offset = new Vector2(0, 0);

        [SerializeField]
        private ParticleSystem sub;


        private void Update()
        {
            Vector3 pos = GameCamera.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);

            pos.z = -2;

            pos += new Vector3(offset.x, offset.y, 0);

            transform.position = pos;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                sub.Play();
            }


        }
    }
}