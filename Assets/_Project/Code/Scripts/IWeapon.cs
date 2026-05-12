using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public interface IWeapon
    {
        void Initialize(WeaponData data, Transform camera);
        void Use();
    }
}
