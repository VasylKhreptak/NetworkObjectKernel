using FishNet.Connection;
using FishNet.Object;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Tests
{
    public class SpawnerAndDespawner : NetworkBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private GameObject _prefab;

        private GameObject _instance;

        [Button, ServerRpc(RequireOwnership = false)]
        private void Spawn(NetworkConnection connection)
        {
            if (_instance != null)
                return;

            _instance = Instantiate(_prefab);
            Spawn(_instance, connection);
        }

        [Button, ServerRpc(RequireOwnership = false)]
        private void Despawn()
        {
            if (_instance == null)
                return;

            Despawn(_instance);

            _instance = null;
        }
    }
}