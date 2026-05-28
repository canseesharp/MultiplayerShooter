using Unity.Netcode;

namespace MultiplayerShooter.UI
{
    public class ResumeButtonUI : ButtonUI
    {
        private GameMenuUI _gameMenu;

        public void Init(GameMenuUI gameMenu)
        {
            _gameMenu = gameMenu;
        }

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
