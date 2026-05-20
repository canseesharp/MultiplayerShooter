using Unity.Cinemachine;
using UnityEngine;

namespace MultiplayerShooter
{
    public class CameraShaker
    {
        private readonly CinemachineBasicMultiChannelPerlin _cinemachinePerlin;

        public CameraShaker(CinemachineBasicMultiChannelPerlin cinemachinePerlin)
        {
            _cinemachinePerlin = cinemachinePerlin;
        }

        public void ShakeCamera(float intencity, float duration)
        {
            ShakeCameraAsync(intencity, duration);
        }

        private async void ShakeCameraAsync(float intencity, float duration)
        {
            _cinemachinePerlin.AmplitudeGain = intencity;
            await Awaitable.WaitForSecondsAsync(duration);
            _cinemachinePerlin.AmplitudeGain = 0f;
        }
    }
}
