using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerAdapter : MonoBehaviour
    {
        private CharacterController _characterController;
        private Vector3 _frameMovement;

        public bool IsGrounded => _characterController.isGrounded;

        public void Move(Vector3 direction) => _frameMovement += direction;

        public void SetActivityByOwnership(bool isOwner) 
        {
            enabled = isOwner;
            _characterController.enabled = true;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _characterController.enabled = true;
        }

        private void OnDisable()
        {
            _characterController.enabled = false;
        }

        private void ApplyMovement()
        {
            _characterController.Move(_frameMovement);
            _frameMovement = Vector3.zero;
        }

        private void Update()
        {
            ApplyMovement();
        }
    }
}
