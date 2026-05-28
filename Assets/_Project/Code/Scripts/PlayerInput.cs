using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MultiplayerShooter
{
    public class PlayerInput
    {
        private readonly PlayerInputActions _inputActions = new();

        public Vector2 MovementDirection => _inputActions.Player.Movement.ReadValue<Vector2>();
        public Vector2 LookingDelta => _inputActions.Player.Looking.ReadValue<Vector2>();

        public event Action Jumped;
        public event Action Shot;
        public event Action GameMenuOpened;

        public void Enable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _inputActions.Enable();
            _inputActions.Player.Jump.performed += OnJump;
            _inputActions.Player.Shoot.performed += OnShoot;
            _inputActions.Player.GameMenuOpen.performed += OnGameMenuOpen;
        }

        public void Disable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _inputActions.Disable();
            _inputActions.Player.Jump.performed -= OnJump;
            _inputActions.Player.Shoot.performed -= OnShoot;
            _inputActions.Player.GameMenuOpen.performed -= OnGameMenuOpen;
        }

        private void OnJump(InputAction.CallbackContext callbackContext) => Jumped?.Invoke();

        private void OnShoot(InputAction.CallbackContext callbackContext) => Shot?.Invoke();

        private void OnGameMenuOpen(InputAction.CallbackContext callbackContext) => GameMenuOpened?.Invoke();
    }
}
