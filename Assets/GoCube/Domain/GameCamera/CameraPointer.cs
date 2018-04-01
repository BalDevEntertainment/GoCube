using System;
using UnityEngine;

namespace GoCube.Domain.GameCamera {

    public class CameraPointer : MonoBehaviour{

        public Action<int> DistanceChanged = delegate{ };
        float _distanceTravelled;
        Vector3 _lastPosition;

        void Awake() {
            _lastPosition = transform.position;
        }


        void Update() {
            var travelled = Vector3.Distance(transform.position, _lastPosition);
            if ((int)_lastPosition.x != (int)transform.position.x) {
                _distanceTravelled += travelled;
                _lastPosition = transform.position;
                DistanceChanged((int)_distanceTravelled);
            }
        }

        public void Reset() {
            _distanceTravelled = 0;
        }
    }
}