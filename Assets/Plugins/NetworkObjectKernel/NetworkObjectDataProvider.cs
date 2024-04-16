using System;
using FishNet.Object;

namespace Plugins.NetworkObjectKernel
{
    public class NetworkObjectDataProvider : NetworkBehaviour
    {
        public event Action OnServerStarted;
        public event Action OnStoppedServer;
        public event Action OnStartedClient;
        public event Action OnStoppedClient;

        #region Networking

        public override void OnStartServer()
        {
            base.OnStartServer();

            OnServerStarted?.Invoke();
        }

        public override void OnStopServer()
        {
            base.OnStopServer();

            OnStoppedServer?.Invoke();
        }

        public override void OnStartClient()
        {
            base.OnStartClient();

            OnStartedClient?.Invoke();
        }

        public override void OnStopClient()
        {
            base.OnStopClient();

            OnStoppedClient?.Invoke();
        }

        #endregion
    }
}