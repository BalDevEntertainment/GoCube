using System;

namespace GoCube.Domain.PlayerEntity
{
    public interface IPlayerAnimationComponent
    {
        void Jump();
        void Idle();
        void Death(Action onDeathAnimationEnded);
    }
}