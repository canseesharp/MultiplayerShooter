using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public abstract class WeaponBase : MonoBehaviour, IWeapon
    {
        protected Transform CameraTransform;
        protected WeaponData Data;

        public void Initialize(WeaponData data, Transform camera)
        {
            Data = data;
            CameraTransform = camera;
        }

        public abstract void Use();
    }
}
