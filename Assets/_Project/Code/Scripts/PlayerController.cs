using MultiplayerShooter.SO;
using Unity.Cinemachine;
using UnityEngine;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(CharacterControllerAdapter))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private Animator _animator;
        [SerializeField] private CinemachineCamera _camera;

        private CharacterControllerAdapter _controllerAdapter;
        private PlayerAnimator _playerAnimator;
        private Movement _movement;
        private Looking _looking;
        private Jump _jump;

        public void SetActivityByOwnership(bool isOwner)
        {
            enabled = isOwner;
            _controllerAdapter.SetActivityByOwnership(isOwner);
        }

        public void TryJump()
        {
            if (_controllerAdapter.IsGrounded == true)
            {
                _playerAnimator.TriggerJump();
                _jump.Do();
            }
        }

        public void Move(Vector2 direction)
        {
            _playerAnimator.SetMoveDirection(direction);
            _movement.Move(direction);
        }

        public void Look(Vector2 delta)
        {
            _looking.Look(delta);
        }

        private void Awake()
        {
            _controllerAdapter = GetComponent<CharacterControllerAdapter>();
            _jump = new(_controllerAdapter, _data);
            _looking = new(transform, _camera.transform, _data);
            _movement = new(_controllerAdapter, transform, _data);
            _playerAnimator = new(_animator);
        }

        private void OnEnable()
        {
            _controllerAdapter.enabled = true;
        }

        private void OnDisable()
        {
            _controllerAdapter.enabled = false;
        }

        private void Update()
        {
            _playerAnimator.SetGrounded(_controllerAdapter.IsGrounded);
            HandleGravity();
        }

        private void HandleGravity()
        {
            if (_jump.IsJumping == true)
            {
                return;
            }

            if (_controllerAdapter.IsGrounded == true)
            {
                _controllerAdapter.Move(Time.deltaTime * 2f * Vector3.down);
            }
            else
            {
                _controllerAdapter.Move(Physics.gravity * Time.deltaTime);
            }
        }

    }
}
