using UnityEngine;

namespace _.Scripts.Players
{
    public class PlayerAnimator
    {
        private CharacterController _characterController;
        private Animator _animator;
        public PlayerAnimator(CharacterController characterController, Animator animator)
        {
            _characterController = characterController;
            _animator = animator;
        }

        public void Execute()
        {
            _animator.SetFloat(_animator.GetParameter(0).name, _characterController.velocity.magnitude);
        }
    }
}