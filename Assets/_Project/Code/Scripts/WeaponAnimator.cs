using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(Animator))]
    public class WeaponAnimator : MonoBehaviour
    {
        private Animator _animator;
        private readonly int _shotAnimation = Animator.StringToHash("Shot");

        public void PlayShot()
        {
            _animator.Play(_shotAnimation);
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
