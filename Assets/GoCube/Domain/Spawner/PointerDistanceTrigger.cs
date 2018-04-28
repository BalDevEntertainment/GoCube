using System;
using GoCube.Domain.GameCamera;
using UnityEngine;

namespace Assets.GoCube.Domain.Spawner {
    public class PointerDistanceTrigger : ISpawnTrigger{

        private readonly int _distanceBetweenSpawn;
        private readonly int _spawnProbabilty;
        public event Action Trigger = delegate {};

        public PointerDistanceTrigger(CameraPointer pointer, int distanceBetweenSpawn,
            int spawnProbabilty) {
            _distanceBetweenSpawn = distanceBetweenSpawn;
            pointer.DistanceChanged += OnDistanceChanged;
            _spawnProbabilty = spawnProbabilty;
        }

        private void OnDistanceChanged(int distance) {
            System.Random gen = new System.Random();
            int prob = gen.Next(100);
            if ((distance > 0 && distance % _distanceBetweenSpawn == 0) && prob < _spawnProbabilty) {
                Trigger();
            }
        }
    }
}