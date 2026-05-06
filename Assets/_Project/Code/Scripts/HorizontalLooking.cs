using UnityEngine;

namespace MultiplayerShooter
{
    public class HorizontalLooking
    {
        private readonly Transform _body;
        private readonly float _sensitivity;

        public HorizontalLooking(Transform body, float sensitivity)
        {
            _body = body;
            _sensitivity = sensitivity;
        }

        public void Look(float lookingDelta)
        {
            _body.Rotate(Time.deltaTime * _sensitivity * lookingDelta * Vector3.up);
        }
    }
}
