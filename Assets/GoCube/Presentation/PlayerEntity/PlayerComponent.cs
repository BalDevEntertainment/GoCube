using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Presentation.PlayerEntity
{
    public class PlayerComponent : MonoBehaviour
    {
        private Player _player;
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            var movementComponent = GetComponent<IMovement>();
            var playerAnimationComponent = GetComponent<IPlayerAnimationComponent>();
            movementComponent.BindAnimator(playerAnimationComponent);

            _player = new Player(GetComponent<IInput>(),
                movementComponent,
                GetComponent<ICollision>(),
                playerAnimationComponent);
        }

        private void Start()
        {
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
    }
}