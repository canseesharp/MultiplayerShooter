using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public class Jump
    {
        private readonly CharacterControllerAdapter _controller;
        private readonly AnimationCurve _jumpCurve;
        private readonly float _jumpHeight;
        private readonly float _jumpDuration;
        private readonly Transform _transform;

        public bool IsJumping { get; private set; }

        public Jump(CharacterControllerAdapter controller, PlayerData data)
        {
            _controller = controller;
            _jumpCurve = data.JumpCurve;
            _jumpHeight = data.JumpHeight;
            _jumpDuration = data.JumpDuration;
            _transform = controller.transform;
        }

        public async void Do()
        {
            IsJumping = true;
            float elapsedSeconds = 0f;
            float startHeight = _transform.position.y;
            while (elapsedSeconds < _jumpDuration)
            {
                elapsedSeconds += Time.deltaTime;
                float progress = elapsedSeconds / _jumpDuration;
                float height = startHeight + _jumpCurve.Evaluate(progress) * _jumpHeight;
                _controller.Move(Vector3.up * (height - _transform.position.y));
                await Awaitable.NextFrameAsync();
            }
            IsJumping = false;
        }
    }
}
