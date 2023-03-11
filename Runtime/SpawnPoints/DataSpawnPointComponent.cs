using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    public class DataSpawnPointComponent<TData> : MonoBehaviour, ISpawnPoint<TData>
    {
        [SerializeField]
        private TData _data;

        public TData Data => _data;
    }
}
