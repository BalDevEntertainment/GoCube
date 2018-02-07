using System;

namespace GoCube.Domain.Enemy {
    public interface ISpawnTrigger {
        event Action Trigger;
    }
}