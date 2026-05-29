using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class SwitchMenuButtonUI : ButtonUI
    {
        [SerializeField] private GameObject _current;
        [SerializeField] private GameObject _next;

        protected override void OnButtonClick()
        {
            _current.SetActive(false);
            _next.SetActive(true);
        }
    }
}
