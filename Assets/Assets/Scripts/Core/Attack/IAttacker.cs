using UnityEngine;

namespace Core
{
    public interface IAttacker
    {
        int Damage { get; }
        float AttackRange { get; }
        Vector3 Position { get; }

        bool CanAttack();
        void MarkAttack();
    }
}