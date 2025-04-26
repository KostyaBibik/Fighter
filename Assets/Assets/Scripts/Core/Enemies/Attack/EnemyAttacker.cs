using UnityEngine;

namespace Core
{
    public class EnemyAttacker : IAttacker
    {
        private readonly Transform _transform;
        private readonly int _damage;
        private readonly float _range;

        private float _lastAttackTime;
        private float _attackCooldown = 2f;
        
        public int Damage => _damage;
        public float AttackRange => _range;
        public Vector3 Position => _transform == null ? Vector3.zero : _transform.position;
        
        public EnemyAttacker(Transform transform, int damage, float range)
        {
            _transform = transform;
            _damage = damage;
            _range = range;
        }
        
        public bool CanAttack()
        {
            return Time.time - _lastAttackTime >= _attackCooldown;
        }

        public void MarkAttack()
        {
            _lastAttackTime = Time.time;
        }
    }
}