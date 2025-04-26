using UnityEngine;

namespace Core
{
    public class PlayerMovement3D : MovementBase
    {
        protected override void Move()
        {
            var velocity = MoveDirection.Value.normalized * MoveSpeed;
            velocity.y = PlayerView.Rigidbody.velocity.y;
            PlayerView.Rigidbody.velocity = velocity;
    
            base.Move();
        }

        protected override void Rotate()
        {
            if (MoveDirection.Value == Vector3.zero)
                return;

            var lookRotation = Quaternion.LookRotation(MoveDirection.Value, Vector3.up);
            PlayerView.Transform.rotation = Quaternion.Slerp(
                PlayerView.Transform.rotation,
                lookRotation,
                Time.deltaTime * 10f
            );
        }

        protected override void StopMovement()
        {
            var velocity = PlayerView.Rigidbody.velocity;
            velocity.x = 0;
            velocity.z = 0;
            PlayerView.Rigidbody.velocity = velocity;
            
            base.StopMovement();
        }
    }
}