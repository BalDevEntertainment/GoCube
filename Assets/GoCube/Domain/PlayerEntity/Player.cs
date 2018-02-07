using System;

namespace GoCube.Domain.PlayerEntity
{
    public class Player
    {
        public event Action OnDeath = delegate { };
        public event Action Jumped = delegate { };

        private readonly IMovement _movement;
        private readonly ICollision _collisionComponent;
        private readonly IPlayerAnimationComponent _playerAnimationComponent;
        private readonly IInput _input;

        public Player(IInput inputComponent, IMovement movementComponent,
            ICollision collisionComponent, IPlayerAnimationComponent playerAnimationComponent)
        {
            _input = inputComponent;
            _movement = movementComponent;
            _collisionComponent = collisionComponent;
            _playerAnimationComponent = playerAnimationComponent;
            Init();
        }

        public void OnDestroy()
        {
            _input.OnJump -= Jump;
            _collisionComponent.OnCollision -= Die;
        }

        private void Init()
        {
            _input.OnJump += Jump;
            _collisionComponent.OnCollision += Die;
        }

        private void Die(string tag)
        {
            if (tag.Equals("Death"))
            {
                _playerAnimationComponent.Death(() => OnDeath.Invoke());
            }
        }

        private void Jump()
        {
            _movement.Jump();
            Jumped();
        }
    }
}