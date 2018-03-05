using System;
using GoCube.Domain.GameCamera;
using UnityEngine;

namespace Assets.GoCube.Domain.Spawner {
    public class PointerDistanceTrigger : ISpawnTrigger{

        private readonly int distanceBetweenSpawn;
        public event Action Trigger = delegate {};

        public PointerDistanceTrigger(CameraPointer pointer, int distanceBetweenSpawn) {
            this.distanceBetweenSpawn = distanceBetweenSpawn;
            pointer.DistanceChanged += OnDistanceChanged;
        }

        private void OnDistanceChanged(int distance) {
            System.Random gen = new System.Random();
            int prob = gen.Next(100);
            if ((distance > 0 && distance % distanceBetweenSpawn == 0) && prob < 75) {
                Trigger();
            }
        }
    }
}