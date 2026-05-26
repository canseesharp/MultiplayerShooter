using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSFX : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _footSteps;

        private AudioSource _audioSource;
        private readonly float _footstepVolume = 1f;

        public void PlayFootstep()
        {
            if (_audioSource.isPlaying)
            {
                return;
            }
            var sound = _footSteps[Random.Range(0, _footSteps.Length)];
            _audioSource.PlayOneShot(sound, _footstepVolume);
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
