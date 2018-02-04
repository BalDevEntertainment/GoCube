using System;

namespace GoCube.Domain.PlayerEntity
{
    public interface IInput
    {
        event Action OnJump;
    }
}