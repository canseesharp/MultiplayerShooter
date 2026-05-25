using System;
using Unity.Netcode;

namespace MultiplayerShooter
{
    public class Health : NetworkBehaviour, IDamageable
    {
        private readonly NetworkVariable<int> _value = new();

        public event NetworkVariable<int>.OnValueChangedDelegate ValueChanged
        {
            add => _value.OnValueChanged += value;
            remove => _value.OnValueChanged -= value;
        }

        public event Action<Health> Dead;

        public void Init(int health)
        {
            _value.Value = health;
        }

        [Rpc(SendTo.Server)]
        public void TakeDamageRpc(int damage)
        {
            _value.Value -= damage;

            if (_value.Value <= 0)
            {
                InvokeDeadRpc();
                Destroy(gameObject);
            }
        }

        [Rpc(SendTo.Everyone)]
        private void InvokeDeadRpc()
        {
            Dead?.Invoke(this);
        }
    }
}
