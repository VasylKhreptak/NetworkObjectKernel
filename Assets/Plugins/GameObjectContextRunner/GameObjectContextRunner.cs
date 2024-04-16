using UnityEngine;
using Zenject;

namespace Plugins.GameObjectContextRunner
{
    [DefaultExecutionOrder(-9990)]
    [RequireComponent(typeof(GameObjectContext))]
    public class GameObjectContextRunner : MonoBehaviour
    {
        #region MonoBehaviour

        private void Awake() => Run();

        #endregion

        private void Run()
        {
            GameObjectContext gameObjectContext = GetComponent<GameObjectContext>();

            if (gameObjectContext.Initialized)
                return;

            DiContainer sceneContainer = ProjectContext.Instance.Container
                .Resolve<SceneContextRegistry>()
                .GetContainerForScene(gameObject.scene);

            gameObjectContext.Construct(sceneContainer);
        }
    }
}