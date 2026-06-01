using System;
using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class GameMenuUI : MonoBehaviour
    {
        public event Action<bool> ActivityChanged;

        private void OnEnable()
        {
            ActivityChanged?.Invoke(true);
        }

        private void OnDisable()
        {
            ActivityChanged?.Invoke(false);
        }
    }
}
