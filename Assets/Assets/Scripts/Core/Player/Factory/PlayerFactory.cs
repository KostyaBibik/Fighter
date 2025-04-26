using DataBase;
using UnityEngine;
using Zenject;

namespace Core
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly DiContainer _container;
        private readonly IPlayerProvider _playerProvider;
        private readonly IPrefabsConfig _prefabsConfig;
        private readonly PlayerConfig _playerConfig;

        public PlayerFactory(
            DiContainer container,
            IPlayerProvider playerProvider,
            IPrefabsConfig prefabsConfig,
            PlayerConfig playerConfig
        )
        {
            _container = container;
            _playerProvider = playerProvider;
            _prefabsConfig = prefabsConfig;
            _playerConfig = playerConfig;
        }
        
        public void Create(PlayerView view, Vector3 pos)
        {
            var hp = _playerConfig.MaxHealth;
            var damage = _playerConfig.Damage;
            var range = _playerConfig.AttackRange;
            var cooldown = _playerConfig.AttackCooldown;
            
            var model = new PlayerModel(hp, damage, range);
            var attacker = new PlayerAttacker(view.transform, model);
            var presenter = new PlayerPresenter(view, model, attacker);
            var animationController = new AnimationController(view.Animator);

            view.transform.position = pos;
            
            var attackSystem = _container.Resolve<PlayerAttackSystem>();
            attackSystem.SetData(attacker, animationController);
            attackSystem.SetAttackCooldown(cooldown);
            
            var hpBar = Object.Instantiate(_prefabsConfig.HpBarPrefab, view.transform);
            var hpPresenter = new HealthBarPresenter(model.Health, hpBar);
            
            var movementSystem = _container.Resolve<IMovementSystem>();
            movementSystem.SetAnimator(animationController);
            
            _playerProvider.Set(presenter);
        }
    }
}