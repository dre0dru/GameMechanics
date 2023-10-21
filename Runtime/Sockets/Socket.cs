using System;
using UnityEngine;

namespace Dre0Dru.Sockets
{
    [Serializable]
    public class Socket : ISocket
    {
        [SerializeField]
        private Transform _transform;

        public Transform Transform => _transform;

        public Socket(Transform transform)
        {
            _transform = transform;
        }

        public static implicit operator Transform(Socket socket)
        {
            return socket._transform;
        }
    }

    [Serializable]
    public class Socket<T> : Socket, ISocket<T>
    {
        [SerializeField]
        private T _data;

        public Socket(Transform transform, T data) : base(transform)
        {
            _data = data;
        }

        public T Data
        {
            get => _data;
            protected set => _data = value;
        }
    }
}
