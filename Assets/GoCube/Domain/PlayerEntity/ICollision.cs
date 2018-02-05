using System;

namespace GoCube.Domain.PlayerEntity
{
    public interface ICollision
    {
        event Action<string> OnCollision;
    }
}