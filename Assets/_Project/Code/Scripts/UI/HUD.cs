using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class HUD : MonoBehaviour
    {
        [field: SerializeField] public HealthBarUI HealthBarUI { get; private set; }
        [field: SerializeField] public RespawnTimerUI RespawnTimerUI { get; private set; }

        public void SetActive(bool value) => gameObject.SetActive(value);
    }
}
