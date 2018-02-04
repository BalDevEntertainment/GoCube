using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerAnimationComponent : MonoBehaviour, IPlayerAnimationComponent
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Jump()
        {
            _animator.SetTrigger("Jump");
        }

        public void Idle()
        {
            _animator.SetTrigger("Idle");
        }
    }
}