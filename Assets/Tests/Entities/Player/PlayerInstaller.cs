using Plugins.NetworkObjectKernel;
using Zenject;

namespace Tests.Entities.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<NetworkObjectDataProvider>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesTo<EventsTest>().AsSingle();
            Container.Bind<GameObjectContextDependency>().AsSingle();
        }
    }
}