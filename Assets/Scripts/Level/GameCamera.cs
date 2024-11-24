using System;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FishyBusiness
{
    [RequireComponent(typeof(Camera))]
    public class GameCamera : MonoSingleton<GameCamera>
    {
        public Camera MainCamera { get; private set; }

        [SerializeField]
        private Vector2 moveRange;

        [SerializeField]
        private float smoothness = 10f;

        private Vector3 startPos;

        protected override void Awake()
        {
            base.Awake();
            startPos = transform.position;
            MainCamera = GetComponent<Camera>();
        }

        private void Update()
        {
            Vector2 pointerPos = Pointer.current.position.ReadValue();

            float normalizedX = Mathf.Clamp01(pointerPos.x / Screen.width) - .5f;
            float normalizedY = Mathf.Clamp01(pointerPos.y / Screen.height) - .5f;

            Vector3 newPos = new Vector3(startPos.x + normalizedX * moveRange.x, startPos.y + normalizedY * moveRange.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * smoothness);
        }
    }
}