namespace Core
{
    public class PlayerModel 
    {
        public HealthModel Health { get; }
        public int AttackDamage { get; }
        public float AttackRange { get; }

        public PlayerModel(int maxHp, int damage, float attackRange)
        {
            Health = new HealthModel(maxHp);
            AttackDamage = damage;
            AttackRange = attackRange;
        }
    }
}