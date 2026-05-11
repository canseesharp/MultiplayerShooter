using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    public class RotationMimic : NetworkBehaviour
    {
        [SerializeField] private Transform _mimicTarget;

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
        }

        private void Update()
        {
            transform.rotation = _mimicTarget.rotation;
        }
    }
}
