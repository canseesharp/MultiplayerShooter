using UnityEngine;

namespace MultiplayerShooter.SO
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public float Damage { get; private set; }
        [field:SerializeField] public float Range { get; private set; }
        [field:SerializeField] public GameObject Prefab { get; private set; }
    }
}
