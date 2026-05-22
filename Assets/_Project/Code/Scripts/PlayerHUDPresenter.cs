using MultiplayerShooter.SO;
using MultiplayerShooter.UI;
using Unity.Netcode;
using UnityEngine;
using VContainer;

namespace MultiplayerShooter
{
    public class PlayerHUDPresenter : NetworkBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private Health _health;

        [Inject] private HealthBarUI _healthBar;

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
        }

        private void Awake()
        {
            VContainerReference.Container.Inject(this);
        }

        private void OnEnable()
        {
            _health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int previous, int current)
        {
            _healthBar.SetHealth(_playerData.Health, current);
        }
    }
}
