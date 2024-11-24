using System;
using UnityEngine;

namespace FishyBusiness.Scenes.Xictoss_Scene.Script
{
    public class DebugButton : MonoBehaviour
    {
        [SerializeField] private LevelManager levelManager;

        public void Accept()
        {
            levelManager.Accept();
        }

        public void Decline()
        {
            levelManager.Decline();
        }        

    }
}