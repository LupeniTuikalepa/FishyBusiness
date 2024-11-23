using FishyBusiness.Core;

namespace FishyBusiness.MenuSystem.MenuData
{
    public class MainMenu : BaseMenu
    {
        public void QuitGame()
        {
            GameController.QuitGame();
        }
    }
}