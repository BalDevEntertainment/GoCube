using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Presentation.PlayerEntity
{
    public class PlayerComponent : MonoBehaviour
    {
        private Player _player;
        private LineRenderer _lineRenderer;
        private IMovement movementComponent;
        private IPlayerAnimationComponent playerAnimationComponent;

        private void Awake()
        {
            movementComponent = GetComponent<IMovement>();
            playerAnimationComponent = GetComponent<IPlayerAnimationComponent>();
            movementComponent.BindAnimator(playerAnimationComponent);
        }

        private void Start()
        {
            _player = new Player(GetComponent<IInput>(),
                movementComponent,
                GetComponent<ICollision>(),
                playerAnimationComponent);
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            var destPosi = _lineRenderer.GetPosition(1);
            _lineRenderer.SetPosition(1, new Vector3(transform.Find("TargetPositionMarker").localPosition.x, destPosi.y, destPosi.z));
        }

        public void SetOnDeath(Action onDeath)
        {
            _player.OnDeath += onDeath;
        }

        private void OnDestroy()
        {
            _player.OnDestroy();
        }

        public void Revive() {
            _player.Revive();
        }

        public void EnableCollision() {
            _player.EnableCollision();
        }
    }
}