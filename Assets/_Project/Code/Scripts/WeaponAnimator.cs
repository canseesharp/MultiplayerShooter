using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAnimator : NetworkBehaviour
    {
        [SerializeField] private ParticleSystem _muzzleEffect;
        private Animator _animator;
        private readonly int _shotAnimation = Animator.StringToHash("Shot");

        [Rpc(SendTo.Everyone)]
        public void PlayShotRpc()
        {
            _animator.Play(_shotAnimation);
            _muzzleEffect.Play();
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
