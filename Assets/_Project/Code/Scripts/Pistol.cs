using UnityEngine;

namespace MultiplayerShooter
{
    public class Pistol : WeaponBase
    {
        public override void Use()
        {
            if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out var hitInfo, Data.Range))
            {
                Debug.Log(hitInfo.transform.name);
            }
        }
    }
}
