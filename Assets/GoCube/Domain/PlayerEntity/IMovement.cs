using System;

namespace GoCube.Domain.PlayerEntity
{
    public interface IMovement
    {
        event Action OnJump;
        event Action OnIdle;
        void Jump();
        void BindAnimator(IPlayerAnimationComponent getComponent);
        void Enable();
        void Disable();
        void RestoreToLastPosition();
    }
}