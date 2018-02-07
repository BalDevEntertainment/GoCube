using System;
using GoCube.Domain.PlayerEntity;

namespace GoCube.Domain.Enemy {
    public class PlayerJumpSpawnTrigger : ISpawnTrigger{
        private readonly Player player;

        public event Action Trigger = delegate {};

        public PlayerJumpSpawnTrigger(Player player) {
            this.player = player;
            player.Jumped += OnPlayerJump;
        }

        private void OnPlayerJump() {
            Trigger();
        }
    }
}