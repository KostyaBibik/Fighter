namespace Core
{
    public class EnemyModel
    {
        public HealthModel Health { get; }
        public int Damage { get; }

        public EnemyModel(int maxHp, int damage)
        {
            Health = new HealthModel(maxHp);
            Damage = damage;
        }
    }
}