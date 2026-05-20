using Unity.Cinemachine;
using UnityEngine;

namespace MultiplayerShooter
{
    public class PlayerDamageFeedback : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private CinemachineBasicMultiChannelPerlin _cinemachinePerlin;
        [SerializeField] private float _shakeIntensity;
        [SerializeField] private float _feedbackDuration;

        private CameraShaker _cameraShaker;

        private void Awake()
        {
            _cameraShaker = new(_cinemachinePerlin);
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
            _cameraShaker.ShakeCamera(_shakeIntensity, _feedbackDuration);
        }
    }
}
