using MultiplayerShooter.SO;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    public class PlayerSpawner : NetworkBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform[] _spawnPoints;

        private const float _respawnTime = 5f;
        private PlayerFactory _playerFactory;

        public override void OnNetworkSpawn()
        {
            if (IsServer == false)
            {
                return;
            }

            _playerFactory = new();
            NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
        }

        private void SpawnPlayer(ulong id)
        {
            var position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            var player = _playerFactory.CreatePlayer(_playerData, position, id);
            player.GetComponent<Health>().Dead += OnPlayerDead;
        }

        private async void OnPlayerDead(Health playerHealth)
        {
            playerHealth.Dead -= OnPlayerDead;
            ulong id = playerHealth.GetComponent<NetworkObject>().OwnerClientId;
            await Awaitable.WaitForSecondsAsync(_respawnTime);
            SpawnPlayer(id);
        }
    }
}
