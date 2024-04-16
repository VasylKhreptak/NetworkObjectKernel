using System.Collections.Generic;
using Plugins.GameObjectKernel.Events;
using Zenject;

namespace Plugins.GameObjectKernel
{
    public class GameObjectKernel : MonoKernel
    {
        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IEnableEventHandler> _enableEventHandlers = new List<IEnableEventHandler>();

        [Inject(Optional = true, Source = InjectSources.Local)]
        private readonly List<IDisableEventHandler> _disableEventHandlers = new List<IDisableEventHandler>();

        #region MonoBehaviour

        private void OnEnable()
        {
            if (HasInitialized == false)
                return;

            Enable();
        }

        private void OnDisable() => Disable();

        #endregion

        protected override void OnAfterInitialize() => Enable();

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
    }
}