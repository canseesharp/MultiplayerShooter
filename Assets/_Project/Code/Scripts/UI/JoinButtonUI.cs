using Unity.Netcode;

namespace MultiplayerShooter.UI
{
    public class JoinButtonUI : ButtonUI
    {
        protected override void OnButtonClick() => NetworkManager.Singleton.StartClient();
    }
}
