
using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class UniversalRigidbody
    {
        [SerializeField] private Rigidbody _rigidbody3D;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public Vector3 velocity
        {
            get
            {
                if (_rigidbody2D != null)
                    return new Vector3(_rigidbody2D.velocity.x, 0, _rigidbody2D.velocity.y);
                if (_rigidbody3D != null)
                    return _rigidbody3D.velocity;
                return Vector3.zero;
            }
            set
            {
                if (_rigidbody2D != null)
                    _rigidbody2D.velocity = new Vector2(value.x, value.z);
                if (_rigidbody3D != null)
                    _rigidbody3D.velocity = value;
            }
        }
    }
}