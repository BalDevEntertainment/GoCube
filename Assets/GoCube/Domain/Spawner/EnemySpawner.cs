using System;

namespace Assets.GoCube.Domain.Spawner {
    public class EnemySpawner {

        public event Action NewSpawn = delegate {};

        private readonly ISpawnTrigger trigger;

        public EnemySpawner(ISpawnTrigger trigger) {
            this.trigger = trigger;
            trigger.Trigger += Spawn;
        }

        private void Spawn() {
            if (NewSpawn != null) {
                NewSpawn ();
            }
        }

        public void OnEnds() {
            trigger.Trigger -= Spawn;
        }
    }

}