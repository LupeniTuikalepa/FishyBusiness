using TMPro;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    private ComputerManager computerManager;
    private int ID;
    
    [Header("References")]
    [SerializeField] private TextMeshProUGUI titleText;

    public void Initialize(string title, int id, ComputerManager computerManager)
    {
        titleText.text = title;
        ID = id;
        this.computerManager = computerManager;
    }
    
    public void Close()
    {
        computerManager.RemoveIconFromBar(ID);
        Destroy(gameObject);
    }

    public void Reduce()
    {
        gameObject.SetActive(false);
    }

    public void ToggleVisibility()
    {
        if(gameObject.transform.GetSiblingIndex() == gameObject.transform.parent.childCount-1)
            gameObject.SetActive(!gameObject.activeSelf);
        else
            gameObject.SetActive(true);

        if (!gameObject.activeSelf)
            gameObject.transform.SetAsFirstSibling();
        else
            gameObject.transform.SetAsLastSibling();
    }
}
