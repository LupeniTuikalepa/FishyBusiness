using TMPro;
using UnityEngine;

namespace FishyBusiness.Fishes
{
    public class GetTextInDialogueWindow : MonoBehaviour
    {
        [field : SerializeField] public TMP_Text WindowTitle { get; private set; } 
        [field : SerializeField] public TMP_Text Dialogue { get; private set; } 
    }
}