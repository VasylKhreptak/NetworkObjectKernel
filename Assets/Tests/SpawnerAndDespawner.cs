using FishNet;
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
        private void Spawn(NetworkConnection connection = null)
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

        private void OnGUI()
        {
            if (InstanceFinder.IsClientStarted == false)
                return;

            int buttonWidth = 80;
            int buttonHeight = 30;

            float xPosition = Screen.width - buttonWidth - 20;
            float yPosition = 20;

            if (GUI.Button(new Rect(xPosition, yPosition, buttonWidth, buttonHeight), "Spawn"))
                Spawn();

            if (GUI.Button(new Rect(xPosition, yPosition + buttonHeight + 10, buttonWidth, buttonHeight), "Despawn"))
                Despawn();
        }
    }
}