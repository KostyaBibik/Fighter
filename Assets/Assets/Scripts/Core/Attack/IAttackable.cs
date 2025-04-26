using UnityEngine;

namespace Core
{
    public interface IAttackable
    {
        public Vector3 Position { get; }
        public HealthModel Health { get; }
    }
}