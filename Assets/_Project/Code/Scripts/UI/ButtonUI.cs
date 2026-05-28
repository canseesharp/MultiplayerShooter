using UnityEngine;
using UnityEngine.UI;

namespace MultiplayerShooter.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonUI : MonoBehaviour
    {
        protected Button Button;

        private void Awake() => Button = GetComponent<Button>();

        protected virtual void OnEnable() => Button.onClick.AddListener(OnButtonClick);

        protected virtual void OnDisable() => Button.onClick.RemoveListener(OnButtonClick);

        protected abstract void OnButtonClick();
    }
}
