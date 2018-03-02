using System;
using UnityEngine;

namespace GoCube.Domain.GameCamera {

    public class CameraPointer : MonoBehaviour{

        public Action<int> DistanceChanged = delegate{ };
        float distanceTravelled = 0;
        Vector3 lastPosition;

        void Awake() {
            lastPosition = transform.position;
        }


        void Update() {
            var travelled = Vector3.Distance(transform.position, lastPosition);
            if ((int)lastPosition.x != (int)(transform.position.x)) {
                distanceTravelled += travelled;
                lastPosition = transform.position;
                DistanceChanged((int)distanceTravelled);
                Debug.Log((int) distanceTravelled);
            }
        }

    }
}