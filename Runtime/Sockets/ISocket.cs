using UnityEngine;

namespace Dre0Dru.Sockets
{
    public interface ISocket
    {
        Transform Transform { get; }
    }

    public interface ISocket<out T> : ISocket
    {
        T Data { get; }
    }
}
