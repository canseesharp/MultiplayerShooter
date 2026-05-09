using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(CharacterControllerAdapter))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private Animator _animator;

        private PlayerInput _input;
        private CharacterControllerAdapter _controller;
        private PlayerAnimator _playerAnimator;
        private Looking _looking;
        private Movement _movement;
        private Jump _jump;

        private void Awake()
        {
            _controller = GetComponent<CharacterControllerAdapter>();
            _input = new();
            _looking = new(transform, Camera.main.transform, _data);
            _movement = new(_controller, transform, _data);
            _jump = new(_controller, _data);
            _playerAnimator = new(_animator);
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.Jumped += OnJump;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Jumped -= OnJump;
        }

        private void Update()
        {
            Vector2 movementDirection = _input.MovementDirection;
            _movement.Move(movementDirection);
            _looking.Look(_input.LookingDelta);

            _playerAnimator.SetMoveDirection(movementDirection);
            _playerAnimator.SetGrounded(_controller.IsGrounded);

            HandleGravity();
        }

        private void HandleGravity()
        {
            if (_jump.IsJumping)
            {
                return;
            }

            if (_controller.IsGrounded)
            {
                _controller.Move(Time.deltaTime * 2f * Vector3.down);
            }
            else
            {
                _controller.Move(Physics.gravity * Time.deltaTime);
            }
        }

        private void OnJump()
        {
            if (_controller.IsGrounded)
            {
                _playerAnimator.TriggerJump();
                _jump.Do();
            }
        }
    }
}
