using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiplayerShooter
{
    [DefaultExecutionOrder(0)]
    public class NetworkSetuper : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManagerPrefab;

        private void Awake()
        {
            if (NetworkManager.Singleton == null)
            {
                Instantiate(_networkManagerPrefab);
            }

            NetworkManager.Singleton.OnClientStopped += OnClientStopped;
        }

        private void OnClientStopped(bool isHost)
        {
            NetworkManager.Singleton.OnClientStopped -= OnClientStopped;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
