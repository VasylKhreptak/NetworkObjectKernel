using System;
using Plugins.NetworkObjectKernel.Events;
using UnityEngine;
using Zenject;

namespace Tests.Entities.Player
{
    public class EventsTest : IInitializable, IServerStartEventHandler, IServerStopEventHandler, IClientStartEventHandler,
        IClientStopEventHandler, IDisposable
    {
        public EventsTest() => Debug.Log("Events test");

        public void Initialize() => Debug.Log("Initialize");

        public void OnServerStart() => Debug.Log("OnServerStart");

        public void OnServerStop() => Debug.Log("OnServerStop");

        public void OnClientStart() => Debug.Log("OnClientStart");

        public void OnClientStop() => Debug.Log("OnClientStop");

        public void Dispose() => Debug.Log("Dispose");
    }
}