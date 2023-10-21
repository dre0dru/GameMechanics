namespace Dre0Dru.Sockets
{
    public interface ISocketsContainer<in TKey, TSocket>
    {
        TSocket GetSocket(TKey key);
        bool TryGetSocket(TKey key, out TSocket socket);
    }
}
