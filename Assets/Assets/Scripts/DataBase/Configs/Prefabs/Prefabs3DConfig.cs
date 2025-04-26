using Core;
using UnityEngine;

namespace DataBase
{
    [CreateAssetMenu(fileName = nameof(Prefabs3DConfig), menuName = "Game/" + nameof(Prefabs3DConfig))]
    public class Prefabs3DConfig : ScriptableObject, IPrefabsConfig
    {
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private HealthBarView _hpBarPrefab;

        public EnemyView EnemyPrefab => _enemyPrefab;
        public HealthBarView HpBarPrefab => _hpBarPrefab;
    }
}