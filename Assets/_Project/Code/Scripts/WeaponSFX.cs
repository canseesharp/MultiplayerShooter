using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class WeaponSFX : MonoBehaviour
    {
        [SerializeField] private AudioClip _shotSound;

        private AudioSource _audioSource;
        private readonly float _shotVolume = 0.5f;

        public void PlayShot()
        {
            _audioSource.PlayOneShot(_shotSound, _shotVolume);
        }

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
    }
}
