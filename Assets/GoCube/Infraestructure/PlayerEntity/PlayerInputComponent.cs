using System;
using GoCube.Domain.PlayerEntity;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerInputComponent : MonoBehaviour, IInput
    {
        public event Action OnJump = delegate { };
        public void Disable()
        {
            enabled = false;
        }

        private Player _player;

        private void Update()
        {
            if (IsScreenBeingTouched() || IsSpacePressed())
            {
                OnJump();
            }
        }

        private static bool IsSpacePressed()
        {
            return Input.GetKeyDown("space");
        }

        private static bool IsScreenBeingTouched()
        {
            return Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began);
        }
    }
}