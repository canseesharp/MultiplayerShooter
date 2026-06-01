using Unity.Netcode;
using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class ResumeButtonUI : ButtonUI
    {
        [SerializeField] private GameMenuUI _gameMenu;

        protected override void OnEnable()
        {
            base.OnEnable();
            NetworkManager.Singleton.OnClientStopped += OnClientStopped;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            if (NetworkManager.Singleton != null)
            {
                NetworkManager.Singleton.OnClientStopped -= OnClientStopped;
            }
        }

        protected override void OnButtonClick()
        {
            _gameMenu.gameObject.SetActive(false);
        }

        private void OnClientStopped(bool value)
        {
            Button.interactable = value;
        }
    }
}
