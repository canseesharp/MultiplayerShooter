using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MultiplayerShooter.UI
{
    public class RespawnTimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Image _timerImage;

        private const string _format = "0.0";
        private float _elapsedSeconds = 0f;
        private float _fullDuration = 0f;

        public void StartTimer(float duration)
        {
            _elapsedSeconds = 0f;
            _fullDuration = duration;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            _elapsedSeconds += Time.deltaTime;
            SetValues(_elapsedSeconds, _fullDuration);

            if (_elapsedSeconds >= _fullDuration)
            {
                gameObject.SetActive(false);
            }
        }

        private void SetValues(float elapsedSeconds, float fullDuration)
        {
            _timerImage.fillAmount = 1 - elapsedSeconds / fullDuration;
            _timerText.text = (fullDuration - elapsedSeconds).ToString(_format);
        }
    }
}
