using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(WeaponAnimator))]
    public abstract class WeaponBase : MonoBehaviour, IWeapon
    {
        protected Transform CameraTransform;
        protected WeaponData Data;

        protected WeaponAnimator WeaponAnimator { get; private set; }

        public void Initialize(WeaponData data, Transform camera)
        {
            Data = data;
            CameraTransform = camera;
            WeaponAnimator = GetComponent<WeaponAnimator>();
        }

        public abstract void Use();
    }
}
