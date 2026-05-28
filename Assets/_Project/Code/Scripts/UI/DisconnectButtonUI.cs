using Unity.Netcode;
using UnityEngine.SceneManagement;

namespace MultiplayerShooter.UI
{
    public class DisconnectButtonUI : ButtonUI
    {
        protected override void OnButtonClick()
        {
            NetworkManager.Singleton.Shutdown();

            if (NetworkManager.Singleton != null)
            {
                Destroy(NetworkManager.Singleton.gameObject);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
