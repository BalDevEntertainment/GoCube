using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerCollisionComponent : MonoBehaviour, ICollision
    {
        public event Action<string> OnCollision = delegate { };
        private bool isEnabled = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isEnabled) {
                OnCollision(other.tag);
                //Destroy(other.gameObject);
            }
        }

        public void Disable() {
            isEnabled = false;
        }

        public void Enable() {
            isEnabled = true;
        }
    }
}