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

        [Inject] private HUD _hud;

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
            _hud.SetActive(true);
            _health.ValueChanged += OnHealthChanged;
            _health.Dead += OnDead;
        }

        private void OnDisable()
        {
            _hud.SetActive(!IsOwner);
            _health.ValueChanged -= OnHealthChanged;
            _health.Dead -= OnDead;
        }

        private void OnHealthChanged(int previous, int current)
        {
            _hud.HealthBarUI.SetHealth(_playerData.Health, current);
        }

        private void OnDead(Health heatlh)
        {
            _hud.RespawnTimerUI.StartTimer(_playerData.RespawnTime);
        }
    }
}
