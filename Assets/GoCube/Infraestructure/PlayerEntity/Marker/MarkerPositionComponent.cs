using System;
using UnityEngine;

namespace GoCube.Infraestructure.PlayerEntity.Marker
{
    public class MarkerPositionComponent : MonoBehaviour
    {
        [SerializeField] private int _speed = 5;
        [SerializeField] private float _originDistance = 1;
        [SerializeField] private float _destinationDistance = 3;
        private readonly Action _translate;
        private readonly Action _stay;
        private MarkerDirection _direction = MarkerDirection.Right();
        private Action _currentAction;
        private Vector3 _stopedAt;

        public MarkerPositionComponent()
        {
            _translate = () => transform.Translate(_direction * _speed * Time.deltaTime, 0, 0);
            _stay = () => transform.position = _stopedAt;
            _currentAction = _translate;
        }

        public void Stop()
        {
            _stopedAt = transform.position;
            _currentAction = _stay;
        }

        public void Resume()
        {
            _currentAction = _translate;
        }

        private void Update()
        {
            _currentAction.Invoke();
            _direction = CalculateMarkerDirection();
        }

        private MarkerDirection CalculateMarkerDirection()
        {
            if (transform.localPosition.x > _destinationDistance)
            {
                return MarkerDirection.Left();
            }
            if (transform.localPosition.x < _originDistance)
            {
                return MarkerDirection.Right();
            }
            return _direction;
        }
    }
}