using DataBase;
using Zenject;

namespace Core
{
    public class EnemySpawner : IInitializable
    {
        private readonly IEnemyFactory _factory;
        private readonly SceneHandler _sceneHandler;
        private readonly IPrefabsConfig _prefabsConfig;

        public EnemySpawner(
            IEnemyFactory factory,
            SceneHandler sceneHandler,
            IPrefabsConfig prefabsConfig
        )
        {
            _factory = factory;
            _sceneHandler = sceneHandler;
            _prefabsConfig = prefabsConfig;
        }
        
        public void Initialize()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            var prefab = _prefabsConfig.EnemyPrefab;
            var markers = _sceneHandler.EnemySpawnMarkers;
            
            for (var index = 0; index < markers.Length; index++)
            {
                _factory.Create(prefab, markers[index].position);
            }
        }
    }
}