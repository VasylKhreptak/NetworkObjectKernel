using UnityEngine;
using Zenject;

namespace Tests.Entities.Player
{
    public class GameObjectContextDependencyResolver : MonoBehaviour
    {
        private GameObjectContextDependency _gameObjectContextDependency;

        [Inject]
        private void Constructor(GameObjectContextDependency gameObjectContextDependency)
        {
            _gameObjectContextDependency = gameObjectContextDependency;
        }

        #region MonoBehaviour

        private void Awake() => _gameObjectContextDependency.DoSomething();

        #endregion
    }
}