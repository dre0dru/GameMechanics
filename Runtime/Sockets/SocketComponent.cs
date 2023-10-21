using UnityEngine;

namespace Dre0Dru.Sockets
{
    public class SocketComponent : MonoBehaviour, ISocket
    {
        public Transform Transform => transform;
    }

    public class SocketComponent<T> : SocketComponent, ISocket<T>
    {
        [SerializeField]
        private T _data;

        public T Data
        {
            get => _data;
            protected set => _data = value;
        }
    }
}
