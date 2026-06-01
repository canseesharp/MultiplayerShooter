using Unity.Netcode;

namespace MultiplayerShooter.UI
{
    public class DisconnectButtonUI : ButtonUI
    {
        protected override void OnButtonClick()
        {
            NetworkManager.Singleton.Shutdown();
        }
    }
}
