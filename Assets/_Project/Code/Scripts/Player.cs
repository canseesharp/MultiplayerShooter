using MultiplayerShooter.SO;
using MultiplayerShooter.UI;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Netcode;
using VContainer;

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
        [Inject] private GameMenuUI _gameMenuUI;

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
            VContainerReference.Container.Inject(this);
        }

        private void OnEnable()
        {
            if (_gameMenuUI.gameObject.activeSelf == false)
            {
                _input.Enable();
            }
            _input.Jumped += OnJump;
            _input.Shot += _weaponController.Use;
            _input.GameMenuOpened += OnGameMenuOpened;
            _gameMenuUI.ActivityChanged += OnActivityChanged;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Jumped -= OnJump;
            _input.Shot -= _weaponController.Use;
            _input.GameMenuOpened -= OnGameMenuOpened;
            _gameMenuUI.ActivityChanged += OnActivityChanged;
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

        private void OnActivityChanged(bool isActive)
        {
            if (isActive)
            {
                _input.Disable();
            }
            else
            {
                _input.Enable();
            }
        }

        private void OnGameMenuOpened()
        {
            _gameMenuUI.gameObject.SetActive(true);
        }
    }
}
