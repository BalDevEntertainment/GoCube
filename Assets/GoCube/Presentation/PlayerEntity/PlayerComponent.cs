﻿using System;
using GoCube.Domain.GameEntity;
using GoCube.Domain.PlayerEntity;
using GoCube.Infraestructure.GameEntity;
using UnityEngine;

namespace GoCube.Presentation.PlayerEntity
{
    public class PlayerComponent : MonoBehaviour
    {
        private Player _player;
        private IMovement _movementComponent;
        private IPlayerAnimationComponent _playerAnimationComponent;

        private void Awake()
        {
            _movementComponent = GetComponent<IMovement>();
            _playerAnimationComponent = GetComponent<IPlayerAnimationComponent>();
            _movementComponent.BindAnimator(_playerAnimationComponent);
            _player = new Player(GetComponent<IInput>(),
                _movementComponent,
                GetComponent<ICollision>(),
                _playerAnimationComponent,
                GameObject.FindWithTag("GameManager").GetComponent<GameManagerComponent>());
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

        public void SetOnRevive(Action onRevive) {
            _player.OnRevive += onRevive;
        }

        public bool HasRevived() {
            return _player.HasRevived;
        }
    }
}