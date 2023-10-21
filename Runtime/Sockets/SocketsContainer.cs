using System;
using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.Sockets
{
    [Serializable]
    public class SocketsContainer<TKey, TSocket> : ISocketsContainer<TKey, TSocket>
    {
        [SerializeField]
        private UDictionary<TKey, TSocket> _sockets;
        
        public TSocket this [TKey key] => GetSocket(key);

        public TSocket GetSocket(TKey key)
        {
            return _sockets[key];
        }

        public bool TryGetSocket(TKey key, out TSocket socket)
        {
            return _sockets.TryGetValue(key, out socket);
        }
    }
}
