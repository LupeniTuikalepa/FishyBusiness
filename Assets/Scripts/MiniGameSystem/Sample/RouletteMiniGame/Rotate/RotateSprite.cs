using DG.Tweening;
using FishyBusiness.MiniGameSystem.Sample.RouletteMiniGame;
using NaughtyAttributes;
using UnityEngine;

namespace FishyBusiness
{
    public class RotateSprite : MonoBehaviour
    {
        [SerializeField] private RectTransform[] sprites;
        [SerializeField] private RectTransform ballPivot;
        [SerializeField] private float rouletteForce;
        [SerializeField] private float ballForce;

        [SerializeField] private RouletteHandler handler;

        [Button]
        public void LaunchBall()
        {
            this.DOKill();
            
            float tempForce = Random.Range(1f, 2f) * ballForce;
            ballPivot.DORotate(Vector3.back * tempForce, 5f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic)
                .SetTarget(this)
                .OnComplete(handler.OnSpinEnd);
            
            foreach (RectTransform sprite in sprites)
            {
                tempForce = Random.Range(1f, 2f) * rouletteForce;
                sprite.DORotate(Vector3.forward * tempForce, 5f, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutCubic)
                    .SetTarget(this);
            }
        }
    }
}
