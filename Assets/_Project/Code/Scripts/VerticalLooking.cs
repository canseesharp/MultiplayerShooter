using UnityEngine;

namespace MultiplayerShooter
{
    public class VerticalLooking
    {
        private readonly Transform _camera;
        private readonly float _sensitivity;
        private float _xRotation;

        public VerticalLooking(Transform camera, float sensitivity)
        {
            _camera = camera;
            _sensitivity = sensitivity;
        }

        public void Look(float lookingDelta)
        {
            _xRotation -= Time.deltaTime * _sensitivity * lookingDelta;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            _camera.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        }
    }
}
