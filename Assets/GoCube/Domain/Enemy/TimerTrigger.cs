using System;

namespace GoCube.Domain.Enemy {
    public class TimerTrigger : ISpawnTrigger{

        public event Action Trigger = delegate { };

        private readonly int interval;
        private float elapsed;

        public TimerTrigger(int intervalSeconds) {
            interval = intervalSeconds;
            elapsed = 0;
        }

        public void Update(float deltaSeconds) {
            elapsed += deltaSeconds;
            if (elapsed >= interval) {
                Trigger();
                elapsed = 0;
            }
        }

    }
}
