using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class EnemyRegistry
    {
        private readonly List<EnemyPresenter> _enemies = new();

        public void Register(EnemyPresenter enemy) => _enemies.Add(enemy);
        public void Unregister(EnemyPresenter enemy) => _enemies.Remove(enemy);

        public IEnumerable<EnemyPresenter> GetEnemiesInRange(Vector3 position, float range)
        {
            return _enemies.Where(e => 
                Vector3.Distance(position, e.Position) <= range);
        }
    }
}