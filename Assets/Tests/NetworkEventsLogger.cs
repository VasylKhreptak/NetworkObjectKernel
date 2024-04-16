using System;
using FishNet.Object;
using UnityEngine;
using Zenject;

namespace Tests
{
    public class NetworkEventsLogger : NetworkBehaviour, IInitializable, IDisposable
    {
        public void Initialize() => Debug.Log("Initialize");

        public void Dispose() => Debug.Log("Dispose");

        private void Awake() => Debug.Log("Awake");

        private void Start() => Debug.Log("Start");

        private void OnEnable() => Debug.Log("OnEnable");

        private void OnDisable() => Debug.Log("OnDisable");

        private void OnDestroy() => Debug.Log("OnDestroy");

        public override void OnStartClient()
        {
            base.OnStartClient();

            Debug.Log("OnStartClient");
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            Debug.Log("OnStartServer");
        }

        public override void OnStopClient()
        {
            base.OnStopClient();

            Debug.Log("OnStopClient");
        }

        public override void OnStopServer()
        {
            base.OnStopServer();

            Debug.Log("OnStopServer");
        }
    }
}