using UnityEngine;

namespace FishyBusiness.MenuSystem.MenuData
{
    public class PauseMenu : BaseMenu
    {
        private void OnEnable()
        {
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}