using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public class Movement
    {
        private readonly CharacterControllerAdapter _controller;
        private readonly Transform _body;
        private readonly float _speed;

        public Movement(CharacterControllerAdapter controller, Transform body, PlayerData data)
        {
            _controller = controller;
            _body = body;
            _speed = data.Speed;
        }

        public void Move(Vector3 inputDirection)
        {
            Vector3 direction = _body.right * inputDirection.x + _body.forward * inputDirection.y;
            _controller.Move(Time.deltaTime * _speed * direction);
        }
    }
}
