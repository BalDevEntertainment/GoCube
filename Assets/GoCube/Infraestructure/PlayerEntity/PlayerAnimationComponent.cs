using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerAnimationComponent : MonoBehaviour, IPlayerAnimationComponent
    {
        private Animator _animator;
        private Action _onDeathAnimationEnded = delegate {  };

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

        public void Death(Action onDeathAnimationEnded)
        {
            _onDeathAnimationEnded = onDeathAnimationEnded;
            _animator.SetTrigger("Death");
        }

        public void OnDeathAnimationEnded()
        {
            _onDeathAnimationEnded.Invoke();
        }
    }
}