using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class ExitButtonUI : ButtonUI
    {
        protected override void OnButtonClick()
        {
            Application.Quit();
        }
    }
}
