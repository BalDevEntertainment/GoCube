using System;

namespace Assets.GoCube.Domain.Spawner {
    public interface ISpawnTrigger {
            event Action Trigger;
    }
}