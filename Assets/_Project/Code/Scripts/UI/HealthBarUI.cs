using UnityEngine;
using UnityEngine.UI;

namespace MultiplayerShooter.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarUI : MonoBehaviour
    {
        private Slider _healthSlider;

        private void Awake()
        {
            _healthSlider = GetComponent<Slider>();
        }

        public void SetHealth(int maxHealth, int current)
        {
            float newValue = (float)current / maxHealth;
            _healthSlider.value = newValue;
        }
    }
}
