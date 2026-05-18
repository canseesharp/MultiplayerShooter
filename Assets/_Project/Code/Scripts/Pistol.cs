using UnityEngine;

namespace MultiplayerShooter
{
    public class Pistol : WeaponBase
    {
        public override void Use()
        {
            if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out var hitInfo, Data.Range) == false)
            {
                return;
            }

            if (hitInfo.transform.TryGetComponent<IDamageable>(out var health))
            {
                health.TakeDamageRpc(Data.Damage);
            }
        }
    }
}
