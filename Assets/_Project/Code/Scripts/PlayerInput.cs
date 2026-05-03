using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MultiplayerShooter
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerInputActions _inputActions;

        public Vector2 MovementDirection { get; private set; }
        public Vector2 LookingDelta { get; private set; }

        public event Action Jumped;

        private void Awake()
        {
            _inputActions = new();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Player.Jump.performed += OnJump;
        }

        private void OnDisable()
        {
            _inputActions.Disable();
            _inputActions.Player.Jump.performed -= OnJump;
        }

        private void Update()
        {
            MovementDirection = _inputActions.Player.Movement.ReadValue<Vector2>();
            LookingDelta = _inputActions.Player.Looking.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext callbackContext) => Jumped.Invoke();
    }
}
