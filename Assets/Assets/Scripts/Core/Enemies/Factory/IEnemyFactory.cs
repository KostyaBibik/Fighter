using UnityEngine;

namespace Core
{
    public interface IEnemyFactory
    {
        public EnemyPresenter Create(EnemyView prefab, Vector3 pos);
    }
}