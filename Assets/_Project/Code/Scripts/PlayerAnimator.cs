using UnityEngine;

namespace MultiplayerShooter
{
    public class PlayerAnimator
    {
        private readonly Animator _animator;

        private readonly int _forward = Animator.StringToHash("Forward");
        private readonly int _side = Animator.StringToHash("Side");
        private readonly int _jumpTrigger = Animator.StringToHash("JumpTrigger");
        private readonly int _isGrounded = Animator.StringToHash("IsGrounded");

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            _animator.SetFloat(_forward, moveDirection.y);
            _animator.SetFloat(_side, moveDirection.x);
        }

        public void SetGrounded(bool isGrounded)
        {
            _animator.SetBool(_isGrounded, isGrounded);
        }

        public void TriggerJump()
        {
            _animator.SetTrigger(_jumpTrigger);
        }
    }
}
