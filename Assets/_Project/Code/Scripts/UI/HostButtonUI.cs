using Unity.Netcode;

namespace MultiplayerShooter.UI
{
    public class HostButtonUI : ButtonUI
    {
        protected override void OnButtonClick() => NetworkManager.Singleton.StartHost();
    }
}
