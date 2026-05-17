using MultiplayerShooter.SO;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    public class PlayerSpawner : NetworkBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Transform[] _spawnPoints;

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
            _playerFactory.CreatePlayer(_playerData, position, id);
        }
    }
}
