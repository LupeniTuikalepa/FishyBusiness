using UnityEngine;
using UnityEngine.UI;

public class MenuAction : MonoBehaviour
{
    [SerializeField]private Image image;

    public void ChangeBackground(Sprite newSprite)
    {
        if (newSprite != null && image != null)
        {
            image.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("Sprite ou Image est manquant !");
        }
    }
}

