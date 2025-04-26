using UnityEngine;

namespace Core
{
    public class SceneHandler : MonoBehaviour
    {
        [SerializeField] private Transform[] _enemySpawnmarkers;
        [SerializeField] private Transform _playerSpawnMarker;

        public Transform[] EnemySpawnMarkers => _enemySpawnmarkers;
        public Transform PlayerSpawnMarker => _playerSpawnMarker;
    }
}