using System;
using System.Collections.Generic;
using GoCube.Domain.PlayerEntity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GoCube.Infraestructure.PlayerEntity
{
    public class PlayerInputComponent : MonoBehaviour, IInput
    {
        public event Action OnJump = delegate { };

        public void Disable()
        {
            enabled = false;
        }

        public void Enable()
        {
            enabled = true;
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
            return Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began) && !IsPointerOverUiObject();
        }

        private static bool IsPointerOverUiObject() {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}