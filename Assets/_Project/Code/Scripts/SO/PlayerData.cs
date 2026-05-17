using UnityEngine;

namespace MultiplayerShooter.SO
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float MouseSensativity { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        [field: SerializeField] public float JumpDuration { get; private set; }
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}
