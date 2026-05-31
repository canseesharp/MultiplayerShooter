using MultiplayerShooter.SO;
using UnityEngine;
using Unity.Cinemachine;
using Unity.Netcode;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(PlayerController), typeof(WeaponController), typeof(GameMenuPresenter))]
    public class Player : NetworkBehaviour
    {
        [SerializeField] private CinemachineCamera _camera;
        [SerializeField] private WeaponData _startWeapon;

        private PlayerInput _input;
        private WeaponController _weaponController;
        private GameMenuPresenter _gameMenuPresenter;
        private PlayerController _controller;

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
            _gameMenuPresenter.enabled = IsOwner;
            _weaponController.enabled = IsOwner;
            _camera.gameObject.SetActive(IsOwner);
            _controller.SetActivityByOwnership(IsOwner);
        }

        private void Awake()
        {
            _input = new();
            _controller = GetComponent<PlayerController>();
            _weaponController = GetComponent<WeaponController>();
            _weaponController.EquipWeapon(_startWeapon);
            _gameMenuPresenter = GetComponent<GameMenuPresenter>();
        }

        private void OnEnable()
        {
            if (_gameMenuPresenter.IsVisible == false)
            {
                _input.Enable();
            }
            _input.Jumped += _controller.TryJump;
            _input.Shot += _weaponController.Use;
            _input.GameMenuOpened += _gameMenuPresenter.ShowMenu;
            _gameMenuPresenter.ActivityChanged += OnActivityChanged;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Jumped -= _controller.TryJump;
            _input.Shot -= _weaponController.Use;
            _input.GameMenuOpened -= _gameMenuPresenter.ShowMenu;
            _gameMenuPresenter.ActivityChanged += OnActivityChanged;
        }

        private void Update()
        {
            _controller.Move(_input.MovementDirection);
            _controller.Look(_input.LookingDelta);
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
    }
}
