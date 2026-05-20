using MultiplayerShooter.SO;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace MultiplayerShooter.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarUI : NetworkBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private PlayerData _playerData;

        private Slider _healthSlider;

        public override void OnNetworkSpawn()
        {
            gameObject.SetActive(IsOwner);
        }

        public void OnHealthChanged(int previous, int current)
        {
            float newValue = (float)current / _playerData.Health;
            _healthSlider.value = newValue;
        }

        private void Awake()
        {
            _healthSlider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.ValueChanged += OnHealthChanged;
        }
    }
}
