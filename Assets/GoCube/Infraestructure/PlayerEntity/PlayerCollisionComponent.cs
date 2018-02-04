using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerCollisionComponent : MonoBehaviour, ICollision
    {
        public event Action OnCollision = delegate { };

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollision();
        }
    }
}