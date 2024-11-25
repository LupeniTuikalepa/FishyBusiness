using System;
using UnityEngine;

namespace FishyBusiness
{
    public class CursorParticle : MonoBehaviour
    {
        [SerializeField] private Vector2 offset = new Vector2(0, 0);
        
        private void Update()
        {
            Vector3 pos = GameCamera.Instance.MainCamera.ScreenToWorldPoint(Input.mousePosition);

            pos.z = -10;
            
            pos += new Vector3(offset.x, offset.y, 0);

            transform.position = pos;

            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
            {
                GetComponent<ParticleSystem>().Play();
            }
            
            
        }
    }
}
