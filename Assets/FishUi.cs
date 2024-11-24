using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace FishyBusiness
{
    public class FishUi : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            
            transform.DORotate(new Vector3(0, -30, -95), 0.4f, RotateMode.Fast).OnComplete(() =>
                transform.DORotate(new Vector3(0, -30, -85), 0.8f, RotateMode.Fast).OnComplete(() =>
                    transform.DORotate(new Vector3(0, -30, -90), 0.8f, RotateMode.Fast)
                )
            );
        }
    }
}
