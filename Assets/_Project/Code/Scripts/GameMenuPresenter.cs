using System;
using MultiplayerShooter.UI;
using UnityEngine;
using VContainer;

namespace MultiplayerShooter
{
    public class GameMenuPresenter : MonoBehaviour
    {
        [Inject] private GameMenuUI _gameMenuUI;

        public bool IsVisible => _gameMenuUI.gameObject.activeSelf;

        public event Action<bool> ActivityChanged
        {
            add => _gameMenuUI.ActivityChanged += value;
            remove => _gameMenuUI.ActivityChanged -= value;
        }

        public void ShowMenu()
        {
            _gameMenuUI.gameObject.SetActive(true);
        }

        private void Awake()
        {
            VContainerReference.Container.Inject(this);
        }
    }
}
