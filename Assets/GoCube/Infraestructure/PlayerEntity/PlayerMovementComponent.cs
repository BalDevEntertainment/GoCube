using System;
using GoCube.Domain.PlayerEntity;
using GoCube.Infraestructure.PlayerEntity.Marker;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerMovementComponent : MonoBehaviour, IMovement
    {
        public MarkerPositionComponent NextPositionMarker;
        public event Action OnJump = delegate { };
        public event Action OnIdle = delegate { };

        private Vector2 _destination;
        private Rigidbody2D _rigidBody;
        private float _movingTime;
        private float _speedModifier;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _destination = _rigidBody.position;
        }

        public void Jump()
        {
            NextPositionMarker.Stop();
            _destination = new Vector2(NextPositionMarker.transform.position.x,
                transform.position.y);
            OnJump();
            _speedModifier = NextPositionMarker.DestinationDistance / transform.InverseTransformPoint(_destination.x, 0, 0).x;
            _movingTime = 0f;
        }

        public void BindAnimator(IPlayerAnimationComponent animationComponent)
        {
            OnJump += animationComponent.Jump;
            OnIdle += animationComponent.Idle;
        }

        private void Update()
        {
            if (!ShouldMove()) return;

            if (!HasReachedDestination())
            {
                _movingTime += Time.deltaTime;
                _rigidBody.MovePosition(
                    Vector2.Lerp(_rigidBody.position, _destination, _movingTime * _speedModifier));
            }
            else
            {
                OnIdle();
                _movingTime = -1f;
                NextPositionMarker.Resume();
            }
        }

        private bool ShouldMove()
        {
            return _movingTime >= 0;
        }

        private bool HasReachedDestination()
        {
            return _rigidBody.position == _destination;
        }
    }
}