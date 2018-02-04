using System;

namespace GoCube.Domain.PlayerEntity
{
    public class Player
    {
        public event Action OnDeath = delegate { };
        private readonly IMovement _movement;
        private readonly ICollision _collisionComponent;
        private readonly IInput _input;

        public Player(IInput inputComponent, IMovement movementComponent,
            ICollision collisionComponent)
        {
            _input = inputComponent;
            _movement = movementComponent;
            _collisionComponent = collisionComponent;
            Init();
        }

        private void Init()
        {
            _input.OnJump += Jump;
            _collisionComponent.OnCollision += Die;
        }

        public void OnDestroy()
        {
            _input.OnJump -= Jump;
            _collisionComponent.OnCollision -= Die;
        }

        private void Jump()
        {
            _movement.Jump();
        }

        private void Die()
        {
            OnDeath();
        }
    }
}