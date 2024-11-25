using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using FishyBusiness.Data;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


namespace FishyBusiness.Fishes
{
    public class FishRenderer : MonoBehaviour
    {
        private static readonly int Angry = Animator.StringToHash("Angry");
        private static readonly int Happy = Animator.StringToHash("Happy");

        private SpriteRenderer spriteRenderer;
        private ShadowCaster2D shadowCaster2D;

        [SerializeField]
        private float moveDuration = .2f;

        [SerializeField]
        private float waveAmplitude = .2f;
        [SerializeField]
        private float waveFrequency = 1;

        [Space]
        [SerializeField]
        private float angryShakeStrength;
        [SerializeField]
        private int angryShakeVibrato;

        [SerializeField]
        private float jumpHeight;
        [SerializeField]
        private float jumpDuration;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            shadowCaster2D = GetComponent<ShadowCaster2D>();
        }

        public void Bind(Fish fish)
        {
            spriteRenderer.sprite = fish.image;

            shadowCaster2D.trimEdge = 0;
            shadowCaster2D.trimEdge = .1f;

            gameObject.name = fish.name;
        }

        [Button]
        public void ReactPositively()
        {
            transform.DOLocalJump(transform.position, jumpDuration, 3, jumpDuration);
        }

        [Button]
        public void ReactNegatively()
        {
            Camera.main.DOShakePosition(.25f, angryShakeStrength * .5f, (int)(angryShakeVibrato * .5f));
            transform.DOShakePosition(.5f, angryShakeStrength, angryShakeVibrato);
        }

        public Tween MoveTo(Transform destination, float delay = 0)
        {
            // Get the target position
            Vector3 targetPosition = destination.position;

            // move towards X linearly
            var t= transform.DOMoveX(targetPosition.x, moveDuration)
                .SetEase(Ease.Linear)
                .SetDelay(delay);

            // Move along y axis following the sine wave
            DOVirtual.Float(0, moveDuration, moveDuration, (t) =>
            {
                // Calculate the new y position using the sine function and apply the shift to our og y
                float newY = waveAmplitude * Mathf.Sin(t * waveFrequency * Mathf.PI * 2);
                transform.position = new Vector3(transform.position.x, destination.position.y + newY,
                    destination.position.z);
            })
                .SetEase(Ease.Linear)
                .SetDelay(delay);

            return t;
        }
    }
}