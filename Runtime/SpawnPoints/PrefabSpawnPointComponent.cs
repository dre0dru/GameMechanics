using UnityEngine;

namespace Dre0Dru.SpawnPoints
{
    public class PrefabSpawnPointComponent<TPrefab> : MonoBehaviour, ISpawnPoint<TPrefab, Transform>
    {
        [SerializeField]
        private TPrefab _prefab;

        public Transform Data => transform;
        public TPrefab SpawnedObject => _prefab;
    }
}
