using UnityEngine;

namespace Core
{
    public class PlayerAttacker : IAttacker
    {
        private readonly PlayerModel _model;
        private readonly Transform _attackerTransform;
        private float _lastAttackTime;
        private float _attackCooldown = 0.5f;

        public int Damage => _model.AttackDamage;
        public float AttackRange => _model.AttackRange;
        public Vector3 Position => _attackerTransform == null ? Vector3.zero : _attackerTransform.position;

        public bool CanAttack() => Time.time - _lastAttackTime >= _attackCooldown;

        public void MarkAttack() => _lastAttackTime = Time.time;
        
        public PlayerAttacker(Transform view, PlayerModel model)
        {
            _attackerTransform = view.transform;
            _model = model;
        }
    }
}