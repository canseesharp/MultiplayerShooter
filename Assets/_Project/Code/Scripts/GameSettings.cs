using UnityEngine;

namespace MultiplayerShooter
{
    public class GameSettings : MonoBehaviour
    {
        private void Awake()
        {
            QualitySettings.vSyncCount = 1;
        }
    }
}
