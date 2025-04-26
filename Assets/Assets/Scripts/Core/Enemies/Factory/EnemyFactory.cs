using DataBase;
using UnityEngine;
using Zenject;

namespace Core
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer _container;
        private readonly EnemyRegistry _registry;
        private readonly IPlayerProvider _playerProvider;
        private readonly IPrefabsConfig _prefabsConfig;
        private readonly EnemyConfig _enemyConfig;

        public EnemyFactory(
            DiContainer container,
            EnemyRegistry registry,
            IPlayerProvider playerProvider,
            IPrefabsConfig prefabsConfig,
            EnemyConfig enemyConfig
        )
        {
            _container = container;
            _registry = registry;
            _playerProvider = playerProvider;
            _prefabsConfig = prefabsConfig;
            _enemyConfig = enemyConfig;
        }

        public EnemyPresenter Create(EnemyView prefab, Vector3 pos)
        {
            var view = _container.InstantiatePrefabForComponent<EnemyView>(prefab);

            var hp = _enemyConfig.MaxHealth;
            var damage = _enemyConfig.Damage;
            var range = _enemyConfig.AttackRange;
            var attackCooldown = _enemyConfig.AttackCooldown;
            
            var model = new EnemyModel(hp, damage);
            var presenter = new EnemyPresenter(view, model, _registry);
            var animationController = new AnimationController(view.Animator);
            var attacker = new EnemyAttacker(view.transform, model.Damage, range);
            var player = _playerProvider.Player;

            view.transform.position = pos;
            
            var hpBar = Object.Instantiate(_prefabsConfig.HpBarPrefab, view.transform);
            var hpPresenter = new HealthBarPresenter(model.Health, hpBar);
            var attackSystem = new EnemyAttackSystem(player, model.Health, attackCooldown);
            attackSystem.SetData(attacker, animationController);
            
            return presenter;
        }
    }
}