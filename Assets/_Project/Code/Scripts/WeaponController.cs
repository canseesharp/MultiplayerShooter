using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform _mountPoint;
        [SerializeField] private Transform _cameraTransfrom;

        private GameObject _currentWeapon;
        private IWeapon _weapon;
        private readonly WeaponFactory _weaponFactory = new();

        public void Use()
        {
            _weapon.Use();
        }

        public void EquipWeapon(WeaponData data)
        {
            if (_currentWeapon != null)
            {
                Destroy(_currentWeapon);
            }

            _currentWeapon = _weaponFactory.CreateWeapon(data, _cameraTransfrom);
            _weapon = _currentWeapon.GetComponent<IWeapon>();
            _currentWeapon.transform.SetParent(_mountPoint, false);
        }
    }
}
