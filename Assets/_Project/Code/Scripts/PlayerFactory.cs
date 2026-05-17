using MultiplayerShooter.SO;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    public class PlayerFactory
    {
        public GameObject CreatePlayer(PlayerData data, Vector3 position, ulong id)
        {
            GameObject instance = Object.Instantiate(data.Prefab, position, Quaternion.identity);
            instance.GetComponent<NetworkObject>().SpawnAsPlayerObject(id);
            instance.GetComponent<Health>().Init(data.Health);
            return instance;
        }
    }
}
