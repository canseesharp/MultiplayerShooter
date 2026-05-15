using MultiplayerShooter.SO;
using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    public class Health : NetworkBehaviour, IDamageable
    {
        [SerializeField] private PlayerData _data;

        private readonly NetworkVariable<int> _value = new(writePerm: NetworkVariableWritePermission.Owner);

        public int Value => _value.Value;

        [Rpc(SendTo.Owner)]
        public void TakeDamageRpc(int damage)
        {
            _value.Value -= damage;

            if (Value <= 0)
            {
                DespawnRpc();
            }
        }

        [Rpc(SendTo.Server)]
        private void DespawnRpc()
        {
            Destroy(gameObject);
        }

        public override void OnNetworkSpawn()
        {
            if (IsOwner == true)
            {
                _value.Value = _data.Health;
            }
        }
    }
}
