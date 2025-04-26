using UnityEngine;

namespace DataBase
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/" + nameof(EnemyConfig), order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Base Stats")]
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _damage = 15;
        [SerializeField] private float _attackRange = 1.75f;
        [SerializeField] private float _attackCooldown = .5f;

        public int MaxHealth => _maxHealth;
        public int Damage => _damage;
        public float AttackRange => _attackRange;
        public float AttackCooldown => _attackCooldown;
    }
}