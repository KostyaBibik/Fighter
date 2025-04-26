using Core;

namespace DataBase
{
    public interface IPrefabsConfig
    {
        public EnemyView EnemyPrefab { get; }
        public HealthBarView HpBarPrefab { get; }
    }
}