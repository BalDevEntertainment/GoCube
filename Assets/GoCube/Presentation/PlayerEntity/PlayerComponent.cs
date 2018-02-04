using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Presentation.Character
{
    public class PlayerComponent : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = new Player(GetComponent<IInput>(),
                GetComponent<IMovement>(), GetComponent<ICollision>());
        }

        private void OnDestroy()
        {
            _player.OnDestroy();
        }

        public void OnDeath(Action onDeath)
        {
            _player.OnDeath += onDeath;
        }
    }
}