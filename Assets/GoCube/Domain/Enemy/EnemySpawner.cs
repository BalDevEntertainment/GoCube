using System;

namespace GoCube.Domain.Enemy {

    public class EnemySpawner {

            public event Action NewSpawn = delegate {};

            public EnemySpawner(ISpawnTrigger trigger) {
                trigger.Trigger += Spawn;
            }

            private void Spawn() {
                if (NewSpawn != null) {
                    NewSpawn ();
                }
            }
    }
}