using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject taskBar;
    public GameObject screenObject;
    [SerializeField] private GameObject pfbTaskBarIcon;
    
    private Dictionary<int, GameObject> taskBarIcons = new Dictionary<int, GameObject>();

    public void AddIconToBar(Sprite icon, GameObject screen, int screenID)
    {
        GameObject taskBarIcon = Instantiate(pfbTaskBarIcon, taskBar.transform);
        taskBarIcon.GetComponent<TaskBarButton>().Initialize(icon, screen, screenID);
        taskBarIcons.Add(screenID, taskBarIcon);
    }

    public void RemoveIconFromBar(int ID)
    {
        GameObject taskBarIcon = taskBarIcons[ID];
        taskBarIcons.Remove(ID);
        Destroy(taskBarIcon);
    }
}
