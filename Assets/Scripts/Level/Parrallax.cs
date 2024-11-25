using UnityEngine;
using UnityEngine.InputSystem;

namespace FishyBusiness
{
    public class Parrallax : MonoBehaviour
    {
        [SerializeField]
        private float smoothness = 10f;

        [SerializeField]
        private float strength;

        private Vector3 startPos;

        private void Awake()
        {
            startPos = transform.position;
        }

        private void Update()
        {
            Vector2 pointerPos = Pointer.current.position.ReadValue();

            float normalizedX = Mathf.Clamp01(pointerPos.x / Screen.width) - .5f;
            float normalizedY = Mathf.Clamp01(pointerPos.y / Screen.height) - .5f;

            float moveRange = strength / (transform.position.z < 1 ? 1 : transform.position.z);
            Vector3 newPos = new Vector3(startPos.x - normalizedX * moveRange, startPos.y - normalizedY * moveRange, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * smoothness);
        }
    }
}