using Core;
using UnityEngine;

namespace DataBase
{
    [CreateAssetMenu(fileName = nameof(Prefabs2DConfig), menuName = "Game/" + nameof(Prefabs2DConfig))]
    public class Prefabs2DConfig : ScriptableObject, IPrefabsConfig
    {
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private HealthBarView _hpBarPrefab;

        public EnemyView EnemyPrefab => _enemyPrefab;
        public HealthBarView HpBarPrefab => _hpBarPrefab;
    }
}