using UnityEngine;

namespace Dre0Dru.Sockets
{
    public class SocketsContainerComponent<TKey, TSocket> : MonoBehaviour, ISocketsContainer<TKey, TSocket>
    {
        [SerializeField]
        private SocketsContainer<TKey, TSocket> _socketsContainer;

        public TSocket this [TKey key] => _socketsContainer.GetSocket(key);

        public TSocket GetSocket(TKey key)
        {
            return _socketsContainer.GetSocket(key);
        }

        public bool TryGetSocket(TKey key, out TSocket socket)
        {
            return _socketsContainer.TryGetSocket(key, out socket);
        }
    }
}
