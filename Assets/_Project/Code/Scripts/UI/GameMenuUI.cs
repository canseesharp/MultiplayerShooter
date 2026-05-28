using System;
using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class GameMenuUI : MonoBehaviour
    {
        [SerializeField] private ResumeButtonUI _resumeButtonUI;

        public event Action<bool> ActivityChanged;

        private void Awake()
        {
            _resumeButtonUI.Init(this);
        }

        private void OnEnable()
        {
            ActivityChanged?.Invoke(true);
        }

        private void OnDisable()
        {
            ActivityChanged?.Invoke(false);
        }

        private void OnDestroy()
        {
            ActivityChanged?.Invoke(true);
        }
    }
}
