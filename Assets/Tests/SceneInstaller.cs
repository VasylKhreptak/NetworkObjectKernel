using Zenject;

namespace Tests
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneTestDependency>().AsSingle();
        }
    }
}