using UnityEngine;

namespace MultiplayerShooter
{
    public class WeaponVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _muzzleEffect;

        public void PlayMuzzleFlash()
        {
            _muzzleEffect.Play();
        }
    }
}
