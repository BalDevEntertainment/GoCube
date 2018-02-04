using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerMovementComponent : MonoBehaviour, IMovement
    {
        public GameObject NextPositionMarker;
        public event Action OnJump = delegate { };
        public event Action OnIdle = delegate { };

        private Vector2 _destination;
        private Rigidbody2D _rigidBody;
        private float _movingTime;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _destination = _rigidBody.position;
        }

        public void Jump()
        {
            _movingTime = 0f;
            _destination = new Vector2(NextPositionMarker.transform.position.x,
                transform.position.y);
            OnJump();
        }

        public void BindAnimator(IPlayerAnimationComponent animationComponent)
        {
            OnJump += animationComponent.Jump;
            OnIdle += animationComponent.Idle;
        }

        private void Update()
        {
            if (!ShouldMove()) return;

            if (HasReachedDestination())
            {
                _movingTime += Time.deltaTime;
                _rigidBody.MovePosition(
                    Vector2.Lerp(_rigidBody.position, _destination, _movingTime));
            }
            else
            {
                OnIdle();
                _movingTime = -1f;
            }
        }

        private bool ShouldMove()
        {
            return _movingTime >= 0;
        }

        private bool HasReachedDestination()
        {
            return _rigidBody.position != _destination;
        }
    }
}