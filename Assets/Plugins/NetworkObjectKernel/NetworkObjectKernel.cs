using System.Collections.Generic;
using Plugins.GameObjectKernel.Events;
using Plugins.NetworkObjectKernel.Events;
using Zenject;

namespace Plugins.NetworkObjectKernel
{
    public class NetworkObjectKernel : MonoKernel
    {
        private NetworkObjectDataProvider _networkObjectDataProvider;

        [Inject]
        private void Constructor(NetworkObjectDataProvider networkObjectDataProvider)
        {
            _networkObjectDataProvider = networkObjectDataProvider;
        }

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IServerStartEventHandler> _serverStartEventHandlers = new List<IServerStartEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IServerStopEventHandler> _serverStopEventHandlers = new List<IServerStopEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IClientStartEventHandler> _clientStartEventHandlers = new List<IClientStartEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IClientStopEventHandler> _clientStopEventHandlers = new List<IClientStopEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IEnableEventHandler> _enableEventHandlers = new List<IEnableEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IDisableEventHandler> _disableEventHandlers = new List<IDisableEventHandler>();

        private bool _triedToStartServerBeforeInitialize;

        #region MonoBehaviour

        private void Awake()
        {
            _networkObjectDataProvider.OnServerStarted += OnServerStarted;
            _networkObjectDataProvider.OnStoppedServer += OnServerStopped;
            _networkObjectDataProvider.OnStartedClient += OnClientStarted;
            _networkObjectDataProvider.OnStoppedClient += OnClientStopped;
        }

        private void OnEnable()
        {
            if (HasInitialized == false)
                return;

            Enable();
        }

        private void OnDisable() => Disable();

        public override void OnDestroy()
        {
            base.OnDestroy();

            _networkObjectDataProvider.OnServerStarted -= OnServerStarted;
            _networkObjectDataProvider.OnStoppedServer -= OnServerStopped;
            _networkObjectDataProvider.OnStartedClient -= OnClientStarted;
            _networkObjectDataProvider.OnStoppedClient -= OnClientStopped;
        }

        #endregion

        #region Networking

        private void OnServerStarted()
        {
            if (HasInitialized == false)
            {
                _triedToStartServerBeforeInitialize = true;
                return;
            }

            TriggerServerStart();
        }

        private void OnServerStopped() => TriggerServerStop();

        private void OnClientStarted() => TriggerClientStart();

        private void OnClientStopped() => TriggerClientStop();

        #endregion

        protected override void OnAfterInitialize()
        {
            Enable();

            if (_triedToStartServerBeforeInitialize)
            {
                TriggerServerStart();
                _triedToStartServerBeforeInitialize = false;
            }
        }

        private void Enable()
        {
            foreach (IEnableEventHandler enableEventHandler in _enableEventHandlers)
            {
                enableEventHandler.OnEnable();
            }
        }

        private void Disable()
        {
            foreach (IDisableEventHandler disableable in _disableEventHandlers)
            {
                disableable.OnDisable();
            }
        }

        private void TriggerServerStart()
        {
            foreach (IServerStartEventHandler serverStartEventHandler in _serverStartEventHandlers)
            {
                serverStartEventHandler.OnServerStart();
            }
        }

        private void TriggerServerStop()
        {
            foreach (IServerStopEventHandler serverStopEventHandler in _serverStopEventHandlers)
            {
                serverStopEventHandler.OnServerStop();
            }
        }

        private void TriggerClientStart()
        {
            foreach (IClientStartEventHandler clientStartEventHandler in _clientStartEventHandlers)
            {
                clientStartEventHandler.OnClientStart();
            }
        }

        private void TriggerClientStop()
        {
            foreach (IClientStopEventHandler clientStopEventHandler in _clientStopEventHandlers)
            {
                clientStopEventHandler.OnClientStop();
            }
        }
    }
}