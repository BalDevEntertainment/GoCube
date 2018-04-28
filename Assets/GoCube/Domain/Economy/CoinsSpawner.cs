using System;
using Assets.GoCube.Domain.Spawner;

namespace GoCube.Domain.Economy {
    public class CoinsSpawner {

        public event Action<int> NewSpawn = delegate {};

        private readonly ISpawnTrigger trigger;

        public CoinsSpawner(ISpawnTrigger trigger) {
            this.trigger = trigger;
            trigger.Trigger += Spawn;
        }

        private void Spawn() {
            if (NewSpawn != null) {
                NewSpawn(1);
            }
        }

        public void OnEnds() {
            trigger.Trigger -= Spawn;
        }

    }
}