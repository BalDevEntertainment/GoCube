using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Presentation.PlayerEntity
{
    public class PlayerComponent : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            var movementComponent = GetComponent<IMovement>();
            movementComponent.BindAnimator(GetComponent<IPlayerAnimationComponent>());

            _player = new Player(GetComponent<IInput>(),
                movementComponent,
                GetComponent<ICollision>());
        }

        public void SetOnDeath(Action onDeath)
        {
            _player.OnDeath += onDeath;
        }

        private void OnDestroy()
        {
            _player.OnDestroy();
        }
    }
}