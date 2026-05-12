using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public class WeaponFactory
    {
        public GameObject CreateWeapon(WeaponData data, Transform camera)
        {
            GameObject instance = Object.Instantiate(data.Prefab, Vector3.zero, Quaternion.identity);
            IWeapon weapon = instance.GetComponent<IWeapon>();
            weapon.Initialize(data, camera);
            return instance;
        }
    }
}
