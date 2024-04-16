using UnityEngine;
using Zenject;

namespace Tests.Entities.Player
{
    public class SceneTestDependencyResolver : MonoBehaviour
    {
        private SceneTestDependency _sceneTestDependency;

        [Inject]
        private void Constructor(SceneTestDependency sceneTestDependency)
        {
            _sceneTestDependency = sceneTestDependency;
        }

        #region MonoBehaviour

        private void Awake()
        {
            _sceneTestDependency.DoSomething();
        }

        #endregion
    }
}