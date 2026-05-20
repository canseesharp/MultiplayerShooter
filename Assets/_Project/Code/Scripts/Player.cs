using MultiplayerShooter.SO;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Netcode;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(CharacterControllerAdapter), typeof(WeaponController))]
    public class Player : NetworkBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private Animator _animator;
        [SerializeField] private CinemachineCamera _camera;
        [SerializeField] private WeaponData _startWeapon;

        private PlayerInput _input;
        private CharacterControllerAdapter _controller;
        private PlayerAnimator _playerAnimator;
        private Looking _looking;
        private Movement _movement;
        private Jump _jump;
        private WeaponController _weaponController;

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
            _camera.gameObject.SetActive(IsOwner);
            _controller.enabled = IsOwner;
            _controller.EnableOnlyController();
        }

        private void Awake()
        {
            _controller = GetComponent<CharacterControllerAdapter>();
            _input = new();
            _looking = new(transform, _camera.transform, _data);
            _movement = new(_controller, transform, _data);
            _jump = new(_controller, _data);
            _playerAnimator = new(_animator);
            _weaponController = GetComponent<WeaponController>();
            _weaponController.EquipWeapon(_startWeapon);
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.Jumped += OnJump;
            _input.Shot += _weaponController.Use;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Jumped -= OnJump;
            _input.Shot -= _weaponController.Use;
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
