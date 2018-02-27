using System;
using GoCube.Domain.GameEntity;

namespace GoCube.Domain.PlayerEntity
{
    public class Player
    {
        public event Action OnDeath = delegate { };
        private readonly IMovement _movement;
        private readonly ICollision _collisionComponent;
        private readonly IPlayerAnimationComponent _playerAnimationComponent;
        private readonly IGameEvents _gameEvents;
        private readonly IInput _input;

        private bool _jumped;

        public Player(IInput inputComponent, IMovement movementComponent,
            ICollision collisionComponent, IPlayerAnimationComponent playerAnimationComponent,
            IGameEvents gameEvents)
        {
            _input = inputComponent;
            _movement = movementComponent;
            _collisionComponent = collisionComponent;
            _playerAnimationComponent = playerAnimationComponent;
            _gameEvents = gameEvents;
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

        public void Revive() {
            _input.Enable();
            _collisionComponent.Enable();
        }

        public void EnableCollision() {
            _collisionComponent.Enable();
        }

        private void Die(string tag)
        {
            if (tag.Equals("Death"))
            {
                _input.Disable();
                _collisionComponent.Disable();
                _playerAnimationComponent.Death(() => OnDeath.Invoke());
            }
        }

        private void Jump()
        {
            if (!_jumped)
            {
                _gameEvents.StartGame();
                _jumped = true;
            }

            _movement.Jump();
        }
    }
}